using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class PlayerFactory
    {
        const float BORDER_LENGTH = 4.0f;

        private string mFilePathToSheet = "Glissa";
        public Texture2D SpriteSheet
        {
            get { return FileManager.GetManager().LoadTexture2D(mFilePathToSheet); }
        }

        public int Width
        {
            get { return SpriteSheet.Width / 3; }
        }
        public int Height
        {
            get { return SpriteSheet.Height / 4; }
        }

        private IFunctionality mFunction;
        public IFunctionality Function
        {
            get { return mFunction; }
            set { mFunction = value; }
        }

        private Vector2 mWorldPosition = Vector2.Zero;
        public Vector2 WorldPosition
        {
            get { return mWorldPosition; }
            set { mWorldPosition = value; }
        }

        private Vector2 mScreenPosition = Vector2.Zero;
        public Vector2 ScreenPosition
        {
            get
            {
                float skim = 50;

                if (mScreenPosition.X - Origin.X - skim < 0)
                {
                    mScreenPosition.X = 0 + Origin.X + skim;
                }
                if (mScreenPosition.X + Origin.X + skim > FileManager.GetManager().GraphicsDevice.Viewport.Width)
                {
                    mScreenPosition.X = FileManager.GetManager().GraphicsDevice.Viewport.Width - Origin.X - skim;
                }

                if (mScreenPosition.Y - Origin.Y - skim < 0)
                {
                    mScreenPosition.Y = 0 + Origin.Y + skim;
                }
                if (mScreenPosition.Y + Origin.Y + skim > FileManager.GetManager().GraphicsDevice.Viewport.Height)
                {
                    mScreenPosition.Y = FileManager.GetManager().GraphicsDevice.Viewport.Height - Origin.Y - skim;
                }

                return mScreenPosition;
            }
            set { mScreenPosition = value; }
        }

        private Vector2 mVelocity = Vector2.Zero;
        public Vector2 Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        private float mSpeed = 4.0f;
        public float Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; }
        }

        public Rectangle CollisionRectangle
        {
            get
            {
                return new Rectangle((int)mScreenPosition.X - (int)(Width / 2), (int)mScreenPosition.Y - (int)(Height / 2), (int)(Width), (int)(Height));
            }
        }

        private Color mColor = Color.White;
        public Color Color
        {
            get { return mColor; }
            set { mColor = value; }
        }

        private float mRotation = 0.0f;
        public float Rotation
        {
            get { return mRotation; }
            set { mRotation = value; }
        }

        private float mScale = 1.0f;
        public float Scale
        {
            get { return mScale; }
        }

        public Vector2 Origin
        {
            get { return UtilityManager.GetManager().GetOrigin(CollisionRectangle); }
        }

        private SpriteEffects mSpriteEffects = SpriteEffects.None;
        public SpriteEffects SpriteEffects
        {
            get { return mSpriteEffects; }
            set { mSpriteEffects = value; }
        }

        private float mLayerDepth = 0;
        public float LayerDepth
        {
            get { return mLayerDepth; }
            set { mLayerDepth = value; }
        }

        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A instance of button Should Never Exist outside of the button manager. */
        public PlayerFactory()
        {
            /* I should probably code this to crash if it does not go quickly out of scope. Lulz. */
        }

        private PlayerFactory(string aFilePathToGraphic, IFunctionality aFunction, Vector2 aScreenCoordinate, Vector2 aWorldCoordinate)
        {
            //    mFilePathToGraphic = aFilePathToGraphic;
            Function = aFunction;

            ScreenPosition = aScreenCoordinate;
            WorldPosition = aWorldCoordinate;

            PlayerManager.GetManager().Add(this);
        }

        static public void CreatePlayer(string aFilePathToGraphic, IFunctionality aFunction, Vector2 aScreenCoordinate, Vector2 aWorldCoordinate)
        {
            new PlayerFactory(aFilePathToGraphic, aFunction, aScreenCoordinate, aWorldCoordinate);
        }

        //   bool mLockSelect = false;
        public void Update()
        {
            Movement();
            CollideWithMonsters();
            //    DeletePlayer();
        }

        private void Movement()
        {
            Vector2 positionPostWorldCollision = WorldPosition;
            Vector2 positionPostScreenCollision = ScreenPosition;
            Velocity = Vector2.Zero;

            float cycleSpeed = 0.2f;

            WorldPosition = positionPostWorldCollision;

            if (InputManager.GetManager().keyUp)
            {
                Velocity = new Vector2(0, -Speed);

                seedX += cycleSpeed;
                seedY = 3;
            }

            if (InputManager.GetManager().keyDown)
            {
                seedX += cycleSpeed;
                seedY = 0;

                Velocity = new Vector2(0, Speed);
            }
            if (InputManager.GetManager().keyRight)
            {
                seedX += cycleSpeed;
                seedY = 2;

                Velocity = new Vector2(Speed, 0);
            }
            if (InputManager.GetManager().keyLeft)
            {
                seedX += cycleSpeed;
                seedY = 1;

                Velocity = new Vector2(-Speed, 0);
            }

            mWorldPosition.X += Velocity.X;
            mScreenPosition.X += Velocity.X;
            if (CollideWithTile() || CollideWithPlayer())
            {
                mWorldPosition.X = positionPostWorldCollision.X;
                mScreenPosition.X = positionPostScreenCollision.X;
            }

            mWorldPosition.Y += Velocity.Y;
            mScreenPosition.Y += Velocity.Y;
            if (CollideWithTile() || CollideWithPlayer())
            {
                mWorldPosition.Y = positionPostWorldCollision.Y;
                mScreenPosition.Y = positionPostScreenCollision.Y;
            }
        }

        private bool CollideWithTile()
        {
            for (int loop = 0; loop < TileManager.GetManager().List.Count; loop++)
            {
                if (TileManager.GetManager().List[loop].IsCollidable == false) continue;

                if (CollisionRectangle.Intersects(TileManager.GetManager().List[loop].CollisionRectangle))
                {
                    Color = Color.Red;
                    return true;
                }
            }
            Color = Color.Green;
            return false;
        }

        private bool CollideWithPlayer()
        {
            for (int loop = 0; loop < PlayerManager.GetManager().List.Count; loop++)
            {
                if (PlayerManager.GetManager().List[loop] == this) continue;

                if (CollisionRectangle.Intersects(PlayerManager.GetManager().List[loop].CollisionRectangle))
                {
                    Color = Color.Yellow;
                    return true;
                }
            }
            Color = Color.Green;
            return false;
        }

        private bool CollideWithMonsters()
        {
            for (int loop = 0; loop < MonsterManager.GetManager().List.Count; loop++)
            {
                if (CollisionRectangle.Intersects(MonsterManager.GetManager().List[loop].CollisionRectangle))
                {
                    MonsterManager.GetManager().List[loop].Color = Color.Red;

                    if (ScreenManager.GetManager().BattleScreen == null)
                    {
                        ScreenManager.GetManager().BattleScreen = new BattleScreen();
                    }
                }
            }

            return false;
        }

        private void DeletePlayer()
        {
            if (InputManager.GetManager().mouseRightPressed)
            {
                if (CollisionRectangle.X < InputManager.GetManager().mousePosition.X &&
                    CollisionRectangle.X + CollisionRectangle.Width > InputManager.GetManager().mousePosition.X &&
                    CollisionRectangle.Y < InputManager.GetManager().mousePosition.Y &&
                    CollisionRectangle.Y + CollisionRectangle.Height > InputManager.GetManager().mousePosition.Y)
                {
                    PlayerManager.GetManager().Remove(this);
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

        float seedX = 0;        // Seeds are for a cheap way to do animation.
        float seedY = 0;
        public void Draw()
        {
            if (seedX > 3) seedX = 0;
            if (seedY > 4) seedY = 0;

            int tempStartWidth = (int)seedX * (Width);
            int tempStartHeight = (int)seedY * (Height);

            Rectangle temporaryRectangle = new Rectangle(tempStartWidth, tempStartHeight, Width, Height);

            FileManager.GetManager().SpriteBatch.Draw(SpriteSheet, ScreenPosition, temporaryRectangle, Color.White, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
