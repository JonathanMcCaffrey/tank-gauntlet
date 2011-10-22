using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class AbstractEntity
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected ObjectManager theObjectManager = ObjectManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        #endregion

        #region Data
        protected AbstractEntityManager mManager;
        public AbstractEntityManager Manager
        {
            get { return mManager; }
        }
        protected string mName;

        const float BORDER_LENGTH = 4.0f;
        protected string mFilePathToGraphic = "IconOne";
        public Texture2D Graphic
        {
            get { return theFileManager.LoadTexture2D(FilePathToGraphic); }
        }
        public string FilePathToGraphic
        {
            get
            {
                if (mFilePathToGraphic == null)
                {
                    mFilePathToGraphic = theTileManager.FilePathToGraphic;
                }

                return mFilePathToGraphic;
            }
            set { mFilePathToGraphic = value; }
        }

        protected Vector2 mWorldPosition = Vector2.Zero;
        public virtual Vector2 WorldPosition
        {
            get
            {
                if (mWorldPosition.X % Graphic.Width < 32)
                {
                    if (mWorldPosition.X % Graphic.Width != 0)
                    {
                        float x = mWorldPosition.X % Graphic.Width;

                        mWorldPosition.X -= x;
                    }
                }
                else
                {
                    if (mWorldPosition.X % Graphic.Width != 0)
                    {
                        float x = Graphic.Width - (mWorldPosition.X % Graphic.Width);

                        mWorldPosition.X += x;
                    }
                }

                if (mWorldPosition.Y % Graphic.Width < 32)
                {
                    if (mWorldPosition.Y % Graphic.Height != 0)
                    {
                        float y = mWorldPosition.Y % Graphic.Height;

                        mWorldPosition.Y -= y;
                    }
                }
                else
                {
                    if (mWorldPosition.Y % Graphic.Height != 0)
                    {
                        float y = Graphic.Height - (mWorldPosition.Y % Graphic.Height);

                        mWorldPosition.Y += y;
                    }
                }

                return mWorldPosition;
            }
            set
            {
                mWorldPosition = value;
            }
        }

        protected Vector2 mOldPosition = Vector2.Zero;
        public Vector2 OldPosition
        {
            get { return mOldPosition; }
            set { mOldPosition = value; }
        }

        protected Vector2 mVelocity = Vector2.Zero;
        public virtual Vector2 Velocity
        {
            get { return mVelocity; }
            set { mVelocity = value; }
        }

        public virtual Vector2 ScreenPosition
        {
            get
            {
                return WorldPosition - thePlayerManager.List[0].WorldPosition;
            }
        }

		public virtual bool IsOnScreen
		{
            get
            {
                bool tempBoolean = false;

                if (ScreenPosition.Y > 0 && ScreenPosition.X < 1024 &&
                    ScreenPosition.Y > 0 && ScreenPosition.Y < 1024)
                {
                    tempBoolean = true;
                }

                return tempBoolean;
            }
		}

        protected float mGunDirection = 0;
        public float GunDirection
        {
            get { return mGunDirection; }
        }


        protected Rectangle SourceRectangle
        {
            get { return theUtilityManager.GetRectangle(Graphic); }
        }

        protected bool isCollidable = true;
        public bool IsCollidable
        {
            get { return isCollidable; }
            set { isCollidable = value; }
        }

        public virtual Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)ScreenPosition.X, (int)ScreenPosition.Y, Graphic.Width, Graphic.Height); }
        }

        protected Color mColor = Color.White;
        public Color Color
        {
            get { return mColor; }
            set { mColor = value; }
        }

        protected float mRotation = 0.0f;
        public float Rotation
        {
            get { return mRotation; }
            set { mRotation = value; }
        }

        protected Vector2 Origin
        {
            get { return theUtilityManager.GetOrigin(Graphic); }
        }

        protected float mScale = 1.0f;
        public float Scale
        {
            get { return mScale; }
            set { mScale = value; }
        }

        protected SpriteEffects mSpriteEffects = SpriteEffects.None;
        public SpriteEffects SpriteEffects
        {
            get { return mSpriteEffects; }
            set { mSpriteEffects = value; }
        }

        protected float mLayerDepth = 0;
        public float LayerDepth
        {
            get { return mLayerDepth; }
            set { mLayerDepth = value; }
        }

        protected bool IsBorderSelected
        {
            get
            {
                if (theInputManager.mousePosition.X > mWorldPosition.X - Origin.X &&
                    theInputManager.mousePosition.X < mWorldPosition.X + Origin.X)
                {
                    if (theInputManager.mousePosition.Y > mWorldPosition.Y - Origin.Y &&
                        theInputManager.mousePosition.Y < mWorldPosition.Y + Origin.Y)
                    {
                        if (IsSelected) return false;

                        Color = Color.Gray;

                        return true;
                    }
                }

                Color = Color.Wheat;

                return false;
            }
        }

        protected bool IsSelected
        {
            get
            {
                if (theInputManager.mousePosition.X > mWorldPosition.X - Origin.X + BORDER_LENGTH &&
                    theInputManager.mousePosition.X < mWorldPosition.X + Origin.X - BORDER_LENGTH)
                {
                    if (theInputManager.mousePosition.Y > mWorldPosition.Y - Origin.Y + BORDER_LENGTH &&
                        theInputManager.mousePosition.Y < mWorldPosition.Y + Origin.Y - BORDER_LENGTH)
                    {
                        Color = Color.White;

                        return true;
                    }
                }
                return false;
            }
        }
        #endregion

        #region Construction and Intialization
        public AbstractEntity()
        {
        }

        protected AbstractEntity(Vector2 aCoordinate)
        {
            FilePathToGraphic = theTileManager.FilePathToGraphic;
            IsCollidable = theTileManager.IsCollidable;

            mWorldPosition = aCoordinate;

            mManager.Add(this);
        }

        static public void CreateEntity(Vector2 aCoordinate)
        {
            new AbstractEntity(aCoordinate);
        }
        #endregion

        #region Methods
        public virtual void Update()
        {
            mOldPosition = mWorldPosition;
        }

        public virtual void Draw()
        {
            theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }

        public virtual void Damage() { }
        #endregion
    }
}