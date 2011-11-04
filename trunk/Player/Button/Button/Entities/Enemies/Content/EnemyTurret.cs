using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class EnemyTurret : Enemy
    {
        #region Data
        float mHealthSize = 3;
        float mHealthLeft = 3;

        Texture2D TurretGun
        {
            get { return theFileManager.LoadTexture2D("Turret_Gun"); }
        }

        HostileStateMachine mHostileStateMachine;
        public HostileStateMachine HostileStateMachine
        {
            get { return mHostileStateMachine; }
            set { mHostileStateMachine = value; }
        }

      
        #endregion

        #region Construction
        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A instance of button Should Never Exist outside of the button manager. */
        public EnemyTurret()
        {
        }

        private EnemyTurret(Vector2 aCoordinate)
        {
            //    FilePathToGraphic = theEnemyManager.FilePathToGraphic;

            FilePathToGraphic = "Turret_Base";
            //  Function = aFunction;  // Added functionality from Enemy manager!
            //   IsCollidable = theEnemyManager.IsCollidable;

            mWorldPosition = aCoordinate;

            mHostileStateMachine = new HostileStateMachine(this);

            theEnemyManager.Add(this);

            CollideWithEnemy();
            CollideWithTile();
        }

        public override void Create(Vector2 aCoordinate)
        {
            new EnemyTurret(aCoordinate);
        }

        static public EnemyTurret MakeNew()
        {
            return new EnemyTurret();
        }
        #endregion

        #region Methods
        public override void Update()
        {
            if (IsOnScreen)
            {
                Velocity = Vector2.Zero;

                mHostileStateMachine.Update();
            }
        }

        public override void Draw()
        {
            if (IsOnScreen)
            {
                theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, GunDirection, Origin, Scale, SpriteEffects, LayerDepth);
                theFileManager.SpriteBatch.Draw(TurretGun, ScreenPosition, SourceRectangle, Color, (Rotation + MathHelper.PiOver4) + MathHelper.Pi, Origin, Scale, SpriteEffects, LayerDepth);
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