using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class Player : AbstractEntity
    {
        #region Data
        float mHealthSize = 10;
        float mHealthLeft = 10;
        float mScore = 0;
        float mAmmoSize = 20;
        float mAmmoLeft = 20;

        Texture2D Tank_Gun
        {
            get { return theFileManager.LoadTexture2D("Tank_Gun"); }
        }

        public override Vector2 WorldPosition
        {
            get
            {
                return mWorldPosition;
            }
        }

        private Vector2 mScreenPosition = Vector2.Zero;
        public override Vector2 ScreenPosition
        {
            get
            {
                float SKIM = 150;

                if (mScreenPosition.X - Origin.X < 0 + SKIM)
                {
                    mScreenPosition.X = 0 + Origin.X + SKIM;
                }
                if (mScreenPosition.X + Origin.X > theFileManager.GraphicsDevice.Viewport.Width - SKIM)
                {
                    mScreenPosition.X = theFileManager.GraphicsDevice.Viewport.Width - Origin.X - SKIM;
                }

                if (mScreenPosition.Y - Origin.Y < 0 + SKIM)
                {
                    mScreenPosition.Y = 0 + Origin.Y + SKIM;
                }
                if (mScreenPosition.Y + Origin.Y > theFileManager.GraphicsDevice.Viewport.Height - SKIM)
                {
                    mScreenPosition.Y = theFileManager.GraphicsDevice.Viewport.Height - Origin.Y - SKIM;
                }

                return mScreenPosition;
            }
            //    set { mScreenPosition = value; }
        }

        public override bool IsOnScreen
		{
            get
            {
			    bool tempBoolean = false;
			
			    if (ScreenPosition.X > 0 && ScreenPosition.X < 1024 && 
				    ScreenPosition.Y > 0 && ScreenPosition.Y  < 1024)
			    {
				    tempBoolean = true;
			    }
			
			    return tempBoolean;
            }
		}

        private CollisionMachine mCollisionMachine;

        private float mSpeed = 4.0f;
        public float Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; }
        }

        public override Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y - 5, Graphic.Width, Graphic.Height - 55); }
        }
        #endregion

        #region Construction
        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A instance of button Should Never Exist outside of the button manager. */
        public Player()
        {
            Initialize();
        }

        private Player(string aFilePathToGraphic, Vector2 aScreenCoordinate, Vector2 aWorldCoordinate)
        {
            //    mFilePathToGraphic = aFilePasthToGraphic;
            mScreenPosition = aScreenCoordinate;
            mWorldPosition = aWorldCoordinate;

           thePlayerManager.Add(this);

           Initialize();
        }

        private void Initialize()
        {
            mCollisionMachine = new EntityCollision(this);
            mManager = thePlayerManager;
            mFilePathToGraphic = "Tank_Base";
            mName = "player";
        }

        static public void CreatePlayer(string aFilePathToGraphic, Vector2 aScreenCoordinate, Vector2 aWorldCoordinate)
        {
            new Player(aFilePathToGraphic, aScreenCoordinate, aWorldCoordinate);
        }
        #endregion

        #region Methods
        public override void Update()
        {
            base.Update();

            Movement();
            Gun();
        }

        private void Movement()
        {
            Vector2 positionPostWorldCollision = WorldPosition;
            Vector2 positionPostScreenCollision = ScreenPosition;
         //   Velocity = Vector2.Zero;

            mWorldPosition = positionPostWorldCollision;

            bool isMoving = false;

            if (theInputManager.MulitKeyPressInput(Keys.Up))
            {
                Velocity += new Vector2(0, -Speed / 20);
                mRotation = (float)Math.Atan2(Velocity.X, -Velocity.Y);
                isMoving = true;
            }
            if (theInputManager.MulitKeyPressInput(Keys.Down))
            {
                Velocity += new Vector2(0, Speed / 20);
                mRotation = (float)Math.Atan2(Velocity.X, -Velocity.Y);
                isMoving = true;
            }
            if (theInputManager.MulitKeyPressInput(Keys.Right))
            {
                Velocity += new Vector2(Speed / 20, 0);
                mRotation = (float)Math.Atan2(Velocity.X, -Velocity.Y);
                isMoving = true;
            }
            if (theInputManager.MulitKeyPressInput(Keys.Left))
            {
                Velocity += new Vector2(-Speed / 20, 0);
                mRotation = (float)Math.Atan2(Velocity.X, -Velocity.Y);
                isMoving = true;
            }

            if (mVelocity.X > Speed) mVelocity.X = Speed;
            if (mVelocity.X < -Speed) mVelocity.X = -Speed;
            if (mVelocity.Y > Speed) mVelocity.Y = Speed;
            if (mVelocity.Y < -Speed) mVelocity.Y = -Speed;
            

            if (isMoving == false)
            {
                Velocity *= 0.85f;
            }
            Velocity.Normalize();


            mWorldPosition.X += Velocity.X;
            mScreenPosition.X += Velocity.X;
            if (CollideWithTile() || CollideWithPlayer())
            {
             /*   mWorldPosition.X = positionPostWorldCollision.X;
                mScreenPosition.X = positionPostScreenCollision.X;
                mOldPosition = mWorldPosition;*/
            }

            mCollisionMachine.Update();

            mWorldPosition.Y += Velocity.Y;
            mScreenPosition.Y += Velocity.Y;
            if (CollideWithTile() || CollideWithPlayer())
            {
              /*  mWorldPosition.Y = positionPostWorldCollision.Y;
                mScreenPosition.Y = positionPostScreenCollision.Y;
                mOldPosition = mWorldPosition;*/
            }

            mCollisionMachine.Update();
        }



        private bool CollideWithTile()
        {
            for (int loop = 0; loop < theTileManager.List.Count; loop++)
            {
                if (theTileManager.List[loop].IsCollidable == false) continue;

                if (CollisionRectangle.Intersects(theTileManager.List[loop].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CollideWithPlayer()
        {
            for (int loop = 0; loop < thePlayerManager.List.Count; loop++)
            {
                if (thePlayerManager.List[loop] == this) continue;

                if (CollisionRectangle.Intersects(thePlayerManager.List[loop].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }


        void Gun()
        {
            Vector2 tempVector;
            tempVector = mScreenPosition - theInputManager.mousePosition;
            tempVector.Normalize();
            mGunDirection = (float)Math.Atan2(tempVector.Y, tempVector.X) - MathHelper.PiOver2;

            if (theInputManager.mouseLeftDrag)
            {
                TankShell.CreateProjectile(ScreenPosition, WorldPosition, this);
            }
        }

        public override void Draw()
        {
            if (IsOnScreen)
            {
                theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin + new Vector2(0, 10), Scale, SpriteEffects, LayerDepth);
                theFileManager.SpriteBatch.Draw(Tank_Gun, ScreenPosition, SourceRectangle, Color, GunDirection, Origin + new Vector2(0, 20), Scale, SpriteEffects, LayerDepth);
            }
        }

        public override void Damage()
        {
            mHealthLeft--;

            mColor = new Color(1.0f, mHealthLeft / mHealthSize, mHealthLeft / mHealthSize);
        }
        #endregion
    }
}
