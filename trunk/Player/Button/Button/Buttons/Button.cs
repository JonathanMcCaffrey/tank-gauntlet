using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class Button
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        #endregion

        #region Data
        protected const float BORDER_LENGTH = 4.0f;

        private AbstractEntity mEntity;
        public AbstractEntity Entity
        {
            get { return mEntity; }
            set { mEntity = value; }
        }

        protected string mFilePathToBorder = "Border";
        public Texture2D Border
        {
            get { return theFileManager.LoadTexture2D(mFilePathToBorder); }
        }
        public string FilePathToBorder
        {
            get { return mFilePathToBorder; }
            set { mFilePathToBorder = value; }
        }

        protected string mFilePathToGraphic = "Rock";
        public Texture2D Graphic
        {
            get { return theFileManager.LoadTexture2D(FilePathToGraphic); }
        }
        public string FilePathToGraphic
        {
            get { return mFilePathToGraphic; }
            set { mFilePathToGraphic = value; }
        }

        protected char mHotKey = ' ';
        public char HotKey
        {
            get { return mHotKey; }
            set { mHotKey = value; }
        }

        protected bool isCollidable = true;
        public bool IsCollidable
        {
            get { return isCollidable; }
            set { isCollidable = value; }
        }


        protected Vector2 mPosition;
        public Vector2 Position
        {
            get
            {
                if (mPosition.X - Origin.X < 0)
                {
                    mPosition.X = 0 + Origin.X;
                }
                else if (mPosition.X + Origin.X > theFileManager.GraphicsDevice.Viewport.Width)
                {
                    mPosition.X = theFileManager.GraphicsDevice.Viewport.Width - Origin.X;
                }
                if (mPosition.Y - Origin.Y < 0)
                {
                    mPosition.Y = 0 + Origin.Y;
                }
                else if (mPosition.Y + Origin.Y > theFileManager.GraphicsDevice.Viewport.Height)
                {
                    mPosition.Y = theFileManager.GraphicsDevice.Viewport.Height - Origin.Y;
                }

                return mPosition;
            }
            set { mPosition = value; }
        }

        protected Rectangle SourceRectangle
        {
            get { return theUtilityManager.GetRectangle(Graphic); }
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
            get { return theUtilityManager.GetOrigin(Border); }
        }

        protected float mScale = 1.0f;
        public float Scale
        {
            get
            {
                float MIN = 0.6f;
                float MAX = 1.4f;

                if (mScale < MIN)
                {
                    mScale = MIN;
                }
                else if (mScale > MAX)
                {
                    mScale = MAX;
                }
                return mScale;
            }
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
                if (theInputManager.mousePosition.X > mPosition.X - Origin.X &&
                    theInputManager.mousePosition.X < mPosition.X + Origin.X)
                {
                    if (theInputManager.mousePosition.Y > mPosition.Y - Origin.Y &&
                        theInputManager.mousePosition.Y < mPosition.Y + Origin.Y)
                    {
                        if (IsIconSelected) return false;

                        Color = Color.Gray;

                        return true;
                    }
                }

                Color = Color.Wheat;

                return false;
            }
        }

        protected bool IsIconSelected
        {
            get
            {
                if (theInputManager.mousePosition.X > mPosition.X - Origin.X + BORDER_LENGTH &&
                    theInputManager.mousePosition.X < mPosition.X + Origin.X - BORDER_LENGTH)
                {
                    if (theInputManager.mousePosition.Y > mPosition.Y - Origin.Y + BORDER_LENGTH &&
                        theInputManager.mousePosition.Y < mPosition.Y + Origin.Y - BORDER_LENGTH)
                    {
                        Color = Color.White;

                        return true;
                    }
                }
                return false;
            }
        }

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)mPosition.X, (int)mPosition.Y, Graphic.Width, Graphic.Height); }
        }
        #endregion

        #region Construction
        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A instance of button Should Never Exist outside of the button manager. */
        public Button()
        {
        }

        protected Button(string aFilePathToGraphic, bool aIsCollidable)
        {
            mFilePathToGraphic = aFilePathToGraphic;
            isCollidable = aIsCollidable;

            theButtonManager.Add(this);
        }

        protected Button(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            mFilePathToGraphic = aFilePathToGraphic;
            isCollidable = aIsCollidable;
            mHotKey = ((char)((int)aHotKey));

            theButtonManager.Add(this);
        }

        static public void CreateButton(string aFilePathToGraphic, bool aIsCollidable)
        {
            new Button(aFilePathToGraphic, aIsCollidable);

        }

        static public void CreateButton(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            new Button(aFilePathToGraphic, aIsCollidable, aHotKey);
        }
        #endregion

        #region Methods
        bool mLockSelect = false;
        public void Update()
        {
            DragIcon();
            SelectIcon();
            ScaleIcon();

            // Spread out buttons when needed
            for (int loop = 0; loop < theButtonManager.List.Count; loop++)
            {
                if (this == theButtonManager.List[loop]) continue;

                if (CollisionRectangle.Intersects(theButtonManager.List[loop].CollisionRectangle))
                {
                    if (mPosition.Y > theButtonManager.List[loop].Position.Y)
                    {
                        mPosition.Y++;
                    }
                    else if (mPosition.Y < theButtonManager.List[loop].Position.Y)
                    {
                        mPosition.Y--;
                    }
                    else if (mPosition.X > theButtonManager.List[loop].Position.X)
                    {
                        mPosition.X++;
                    }
                    else if (mPosition.X < theButtonManager.List[loop].Position.X)
                    {
                        mPosition.X--;
                    }
                    else if (mPosition.X > theFileManager.GraphicsDevice.Viewport.Height / 2)
                    {
                        mPosition.Y++;
                    }
                    else if (mPosition.X < theFileManager.GraphicsDevice.Viewport.Height / 2)
                    {
                        mPosition.Y--;
                    }
                }
            }
        }

        private void DragIcon()
        {
            if (IsBorderSelected && theInputManager.mouseLeftDrag)
            {
                mPosition += theInputManager.mouseTranslation;

                mLockSelect = true;
            }
            else if (mLockSelect && theInputManager.mouseLeftDrag)
            {
                mPosition += theInputManager.mouseTranslation;
            }
            else
            {
                mLockSelect = false;
            }
        }

        protected bool SelectIcon()
        {
            if (theInputManager.KeyHeldDown((Keys)HotKey))
            {
                theTileManager.FilePathToGraphic = FilePathToGraphic;
                theTileManager.IsCollidable = IsCollidable;
                return true;
            }
            if (IsIconSelected && theInputManager.mouseLeftReleased)
            {
                theTileManager.FilePathToGraphic = FilePathToGraphic;
                theTileManager.IsCollidable = IsCollidable;
                return true;
            }
            if (IsIconSelected && theInputManager.mouseLeftDrag)
            {
                Color = Color.LightGray;
            }
            if (IsIconSelected && theInputManager.mouseRightDrag)
            {
                //       theButtonManager.Remove(this);
            }

            return false;
        }

        protected void ScaleIcon()
        {
            if (IsIconSelected)
            {
                Scale += theInputManager.mouseWheel / 1000;
            }
        }

        public void Draw()
        {
            theFileManager.SpriteBatch.Draw(Graphic, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            theFileManager.SpriteBatch.Draw(Border, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);

            if (HotKey != null)
            {
                theFileManager.SpriteBatch.DrawString(theFileManager.SpriteFont, HotKey + " ", new Vector2(Position.X - 2 + Graphic.Width / 2, Position.Y - 10 + Graphic.Height / 2), Color.Orange, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
        }
        #endregion
    }
}
