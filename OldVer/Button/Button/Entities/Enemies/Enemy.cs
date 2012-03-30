using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class Enemy : AbstractEntity
    {
        #region Data
        float mHealthSize = 40;
        float mHealthLeft = 40;

        HostileStateMachine mHostileStateMachine;
        public HostileStateMachine HostileStateMachine
        {
            get { return mHostileStateMachine; }
            set { mHostileStateMachine = value; }
        }

        bool mHasGun = false;
        Texture2D Gun
        {
            get { return theFileManager.LoadTexture2D("Turret_Gun"); }
        }

        #endregion

        #region Construction
        public Enemy()
        {
        }

        private Enemy(Vector2 aCoordinate)
        {
            FilePathToGraphic = theEnemyManager.FilePathToGraphic;
            IsCollidable = theEnemyManager.IsCollidable;
            IsCollidable = true;

            mWorldPosition = aCoordinate;

            mHostileStateMachine = new HostileStateMachine(this);

            theEnemyManager.Add(this);

            mManager = theEnemyManager;

            CollideWithEnemy();
            CollideWithTile();
        }

        static public void CreateEnemy(Vector2 aCoordinate)
        {
            new Enemy(aCoordinate);
        }
        #endregion

        #region Methods
        public override void Update()
        {
            if (IsOnScreen)
            {
                base.Update();

                mHostileStateMachine.Update();

                mWorldPosition += Velocity;
            }
        }

        public override void Draw()
        {
            if (IsOnScreen)
            {
                theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, GunDirection, Origin, Scale, SpriteEffects, LayerDepth);
                theFileManager.SpriteBatch.Draw(Gun, ScreenPosition, SourceRectangle, Color, (Rotation + MathHelper.PiOver4) + MathHelper.Pi, Origin, Scale, SpriteEffects, LayerDepth);
            }
        }

        protected void CollideWithEnemy()
        {
            for (int loop = 0; loop < theEnemyManager.List.Count; loop++)
            {
                if (theEnemyManager.List[loop] == this) continue;

                if (ScreenPosition == theEnemyManager.List[loop].ScreenPosition)
                {
                    theEnemyManager.Remove(theEnemyManager.List[loop]);
                }
            }
        }

        protected void CollideWithTile()
        {
            for (int loop = 0; loop < theTileManager.List.Count; loop++)
            {
                if (ScreenPosition == theTileManager.List[loop].ScreenPosition)
                {
                    if (theTileManager.List[loop].IsCollidable)
                    {
                        theEnemyManager.Remove(this);
                    }
                }
            }
        }

        private void DeleteEnemy()
        {
            if (theInputManager.mouseLeftDrag)
            {
                if (CollisionRectangle.X < theInputManager.mousePosition.X &&
                    CollisionRectangle.X + Graphic.Width > theInputManager.mousePosition.X &&
                    CollisionRectangle.Y < theInputManager.mousePosition.Y &&
                    CollisionRectangle.Y + Graphic.Height > theInputManager.mousePosition.Y)
                {
                    theEnemyManager.Remove(this);
                }
            }
        }

        public bool Collision(Rectangle aCollisionRectangle)
        {
            if (CollisionRectangle.Intersects(aCollisionRectangle))
            {
                return true;
            }

            return false;
        }

        public override void Damage()
        {
            mHealthLeft--;

            mColor = new Color(1.0f, mHealthLeft / mHealthSize, mHealthLeft / mHealthSize);

            if (mHealthLeft == 0)
            {
                theEnemyManager.Remove(this);
            }
        }
        #endregion
    }
}