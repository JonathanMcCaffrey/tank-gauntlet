using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class AbstractProjectile
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
    //    protected ObjectManager theObjectManager = ObjectManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        protected ProjectileManager theProjectileManager = ProjectileManager.Get();
        #endregion

        #region Data
        protected AbstractEntity mShooter;
        public AbstractEntity Shooter
        {
            get { return mShooter; }
        }

        protected ProjectileManager mManager;
        protected ProjectileManager Manager
        {
            get
            {
                if (mManager == null) mManager = ProjectileManager.Get();
                return mManager;
            }
        }
        protected string mName;

        const float BORDER_LENGTH = 4.0f;
        protected string mFilePathToGraphic = "Bullet";
        public Texture2D Graphic
        {
            get { return theFileManager.LoadTexture2D(FilePathToGraphic); }
        }
        public string FilePathToGraphic
        {
            get            {                return mFilePathToGraphic;            }
            set { mFilePathToGraphic = value; }
        }

        protected Vector2 mWorldPosition = Vector2.Zero;
        public virtual Vector2 WorldPosition
        {
            get { return mWorldPosition; }
            set { mWorldPosition = value; }
        }

        private Vector2 mOldPosition = Vector2.Zero;
        public Vector2 OldPosition
        {
            get { return mOldPosition; }
            set { mOldPosition = value; }
        }

        protected Vector2 mStartinPosition = Vector2.Zero;
        public virtual Vector2 StartinPosition
        {
            get { return mStartinPosition; }
        }

        protected float mSpeed = 10;
        public float Speed
        {
            get { return mSpeed; }
            set { mSpeed = value; }
        }

        protected Vector2 mVelocity = Vector2.Zero;
        public virtual Vector2 Velocity
        {
            get { return mVelocity * Speed; }
            set { mVelocity = value; }
        }

        private float mMaxDistance = 200;
        protected float MaxDistance
        {
            get { return mMaxDistance; }
            set { mMaxDistance = value; }
        }


        public virtual Vector2 ScreenPosition
        {
            get
            {
                return WorldPosition - thePlayerManager.List[0].WorldPosition;
            }
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

        protected CollisionMachine mCollisionMachine;
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
        #endregion

        #region Construction
        public AbstractProjectile() { }

        protected AbstractProjectile(Vector2 aCoordinate)
        {
            mWorldPosition = aCoordinate;

            mCollisionMachine = new ProjectileCollision(this);


            Manager.Add(this);
        }

        static public void CreateProjectile(Vector2 aCoordinate)
        {
            new AbstractProjectile(aCoordinate);
        }
        #endregion

        public virtual bool IsOnScreen
        {
            get
            {
                bool tempBoolean = false;

                if (ScreenPosition.X > 0 && ScreenPosition.X < 1024 &&
                    ScreenPosition.Y > 0 && ScreenPosition.Y < 1024)
                {
                    tempBoolean = true;
                }

                return tempBoolean;
            }
        }

        #region Methods
        static int x = 0;
        public virtual void Update()
        {
            mOldPosition = mWorldPosition;

            float j = (float)Math.Sqrt((WorldPosition.X - StartinPosition.X) * (WorldPosition.X - StartinPosition.X) + (WorldPosition.Y - StartinPosition.Y) * (WorldPosition.Y - StartinPosition.Y));

            if (j > MaxDistance)
            {
                theProjectileManager.Remove(this);
            }

            WorldPosition += Velocity;

            mCollisionMachine.Update();

            Collision();

            x++;
        }

        public void Collision()
        {
        /*    for (int loop = 0; loop < theTileManager.List.Count; loop++)
            {
                if (theTileManager.List[loop].IsCollidable)
                {
                    if (this.CollisionRectangle.Intersects(theTileManager.List[loop].CollisionRectangle))
                    {
                        theProjectileManager.Remove(this);
                    }
                }
            }

            for (int loop = 0; loop < thePlayerManager.List.Count; loop++)
            {
                if (thePlayerManager.List[loop] == mShooter) continue;
                if (thePlayerManager.List[loop].IsCollidable == false) continue;

                if (this.CollisionRectangle.Intersects(thePlayerManager.List[loop].CollisionRectangle))
                {
                    theProjectileManager.Remove(this);
                    thePlayerManager.List[loop].Damage();
                }
            }

            for (int loop = 0; loop < theEnemyManager.List.Count; loop++)
            {
                if (theEnemyManager.List[loop] == mShooter) continue;
                if (theEnemyManager.List[loop].IsCollidable == false) continue;

                if (this.CollisionRectangle.Intersects(theEnemyManager.List[loop].CollisionRectangle))
                {
                    theProjectileManager.Remove(this);
                    theEnemyManager.List[loop].Damage();
                }
            }*/
        }

        public virtual void Draw()
        {
            if (IsOnScreen)
            {
                theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
        }
        #endregion
    }
}