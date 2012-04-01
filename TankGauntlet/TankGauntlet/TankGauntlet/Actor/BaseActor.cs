using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BaseActor
    {
        protected Rectangle ScreenDimensions = new Rectangle(0, 0, 800, 480);
        protected Vector2 HalfDimensions = new Vector2(400, 240);
        protected Vector2 QuarterDimensions = new Vector2(200, 120);
        protected Vector2 EigthDimensions = new Vector2(100, 60);

        #region Data

        protected string m_FilePathToTexture;
        public string FilePathToTexture
        {
            get { return m_FilePathToTexture; }
            set { m_FilePathToTexture = value; }
        }

        protected bool m_IsCollidable;
        public bool IsCollidable
        {
            get { return m_IsCollidable; }
            set { m_IsCollidable = value; }
        }
        protected bool m_IsDestructable;
        public bool IsDestructable
        {
            get { return m_IsDestructable; }
            set { m_IsDestructable = value; }
        }

        protected Vector2 m_Position;
        public virtual Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        protected Vector2 m_OldPosition;
        public virtual Vector2 OldPosition
        {
            get { return m_OldPosition; }
            set { m_OldPosition = value; }
        }

        protected Vector2 m_Origin;
        public virtual Vector2 Origin
        {
            get { return m_Origin; }
            set { m_Origin = value; }
        }

        protected Rectangle m_SourceRectangle;
        public Rectangle SourceRectangle
        {
            get { return m_SourceRectangle; }
            set { m_SourceRectangle = value; }
        }
        
        protected Color m_Color;
        public Color Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
       
        protected float m_Rotation;
        public float Rotation
        {
            get { return m_Rotation; }
            set { m_Rotation = value; }
        }
        
        protected float m_Scale;
        public float Scale
        {
            get { return m_Scale; }
            set { m_Scale = value; }
        }

        private float m_LayerDepth;
        public float LayerDepth
        {
            get { return m_LayerDepth; }
            set { m_LayerDepth = value; }
        }

        private SpriteEffects m_SpriteEffects;
        public SpriteEffects SpriteEffects
        {
            get { return m_SpriteEffects; }
            set { m_SpriteEffects = value; }
        }

        public virtual Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, SourceRectangle.Width, SourceRectangle.Height); }
        }
        #endregion

        public BaseActor()
        {
            m_Position = Vector2.Zero;
            m_IsCollidable = false;
            m_IsDestructable = false;
            m_Color = Color.White;
            m_Rotation = 0;
            m_Scale = 1.0f;
            m_LayerDepth = 1.0f;
            m_SpriteEffects = SpriteEffects.None;
            m_Origin = new Vector2(32, 32);
            m_SourceRectangle = new Rectangle(0, 0, 64, 64);
        }

        public virtual void Update(GameTime a_GameTime)
        {
#if WINDOWS
            if (Input.MouseRightDrag)
            {
                if (CollisionRectangle.Contains(new Point((int)(Input.MousePosition.X - Camera.Position.X), (int)(Input.MousePosition.Y - Camera.Position.Y))))
                {
                    ActorManager.List.Remove(this);
                }
            }
#endif
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(File.ContentManager.Load<Texture2D>(m_FilePathToTexture), Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
