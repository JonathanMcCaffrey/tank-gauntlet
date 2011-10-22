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

        public override Vector2 WorldPosition
        {
            get
            {
                return mWorldPosition;
            }
        }
        #endregion

        #region Construction
        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A instance of button Should Never Exist outside of the button manager. */
        public Enemy()
        {
        }

        private Enemy(Vector2 aCoordinate)
        {
        //    FilePathToGraphic = theEnemyManager.FilePathToGraphic;

            FilePathToGraphic = "Tank";
            //  Function = aFunction;  // Added functionality from Enemy manager!
         //   IsCollidable = theEnemyManager.IsCollidable;

            mWorldPosition = aCoordinate;

            mHostileStateMachine = new HostileStateMachine(this);

            theEnemyManager.Add(this);

            CollideWithEnemy();
        }

        static public void CreateEnemy(Vector2 aCoordinate)
        {
            new Enemy(aCoordinate);
        }
        #endregion

        #region Methods
        public override void Update()
        {
            base.Update();

        //    mHostileStateMachine.Update();

            mWorldPosition += Velocity;

           // DeleteEnemy();
        }

        public override void Draw()
        {
            theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }

        private void CollideWithEnemy()
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