using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public abstract class AbstractGameScreen
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        protected ProjectileManager theProjectileManager = ProjectileManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        protected CollisionManager theCollisionManager = CollisionManager.Get();
        #endregion

        #region Data
        private Texture2D mBackgroundTexture;
        public Texture2D BackgroundTexture
        {
            get { return mBackgroundTexture; }
            set { mBackgroundTexture = value; }
        }

        private SpriteBatch mSpriteBatch;
        public SpriteBatch SpriteBatch
        {
            get { return mSpriteBatch; }
        }

        private GraphicsDevice mGraphicsDevice;
        public GraphicsDevice GraphicsDevice
        {
            get { return mGraphicsDevice; }
        }

        private Color mBackgroundColor = Color.White;
        public Color BackgroundColor
        {
            get { return mBackgroundColor; }
            set { mBackgroundColor = value; }
        }

        #endregion

        #region Construction
        public AbstractGameScreen()
        {
            mSpriteBatch = theFileManager.SpriteBatch;
            mGraphicsDevice = theFileManager.GraphicsDevice;

            mBackgroundTexture = theFileManager.LoadTexture2D(@"Background");
        }
        #endregion

        #region Methods
        protected virtual void Initialize() { }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime aGameTime)
        {
        }
        public virtual void Draw(GameTime aGameTime)
        {
            theFileManager.SpriteBatch.Draw(BackgroundTexture, Vector2.Zero, BackgroundColor);
        }
        #endregion
    }
}
