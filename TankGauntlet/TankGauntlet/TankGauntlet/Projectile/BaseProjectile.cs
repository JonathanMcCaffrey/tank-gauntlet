using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace TankGauntlet
{
    public class BaseProjectile
    {
        protected static Rectangle ScreenDimensions = new Rectangle(0, 0, 800, 480);

        #region Data
        protected Texture2D m_Texture2D;
        public virtual Texture2D Texture2D
        {
            get { return m_Texture2D; }
        }

        protected float m_Speed;
        protected float m_MaxSpeed = 10;
        protected float m_Direction;
        protected ContentManager m_ContentManager;

        protected SpriteFont m_DebugFont;

        public Vector2 Velocity
        {
            get { return new Vector2((float)(Math.Cos(m_Direction) * m_Speed), (float)(Math.Sin(m_Direction) * m_Speed)); }
        }

        protected Vector2 m_Position;
        public virtual Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        protected Vector2 m_Origin;
        public virtual Vector2 Origin
        {
            get { return m_Origin; }
        }

        protected Rectangle m_SourceRectangle;
        public virtual Rectangle SourceRectangle
        {
            get { return m_SourceRectangle; }
        }

        protected Color m_Color;
        public virtual Color Color
        {
            get { return m_Color; }
        }

        protected float m_Rotation;
        public virtual float Rotation
        {
            get { return m_Rotation; }
        }

        protected float m_Scale;
        public virtual float Scale
        {
            get { return m_Scale; }
        }

        protected float m_LayerDepth;
        public virtual float LayerDepth
        {
            get { return m_LayerDepth; }
        }

        protected SpriteEffects m_SpriteEffects;
        public virtual SpriteEffects SpriteEffects
        {
            get { return m_SpriteEffects; }
        }

        public virtual Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)Position.X, (int)Position.Y, SourceRectangle.Width, SourceRectangle.Height); }
        }
        #endregion

        public BaseProjectile(ContentManager a_ContentManager, Texture2D a_Texture2D, Vector2 a_Position, float a_Direction)
        {
            m_Texture2D = a_Texture2D;
            m_Position = a_Position;
            m_Direction = a_Direction - MathHelper.PiOver2;
            m_Speed = 10.0f;

            m_ContentManager = a_ContentManager;
            m_Color = Color.White;
            m_Rotation = 0;
            m_Scale = 1.0f;
            m_LayerDepth = 1.0f;
            m_SpriteEffects = SpriteEffects.None;

            CollisionManager.ProjectileList.Add(this);

            Initialize();
        }

        protected virtual void Initialize()
        {
            m_Origin = new Vector2(m_Texture2D.Width / 2.0f, m_Texture2D.Height / 2.0f);
            m_SourceRectangle = new Rectangle(0, 0, m_Texture2D.Width, m_Texture2D.Height);
        }

        public virtual void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            m_Position += Velocity;

            if (!(m_Position.X >= 0 && m_Position.Y >= 0 && m_Position.X <= 800 && m_Position.Y <= 480))
            {
                CollisionManager.ProjectileList.Remove(this);
                ProjectileManager.List.Remove(this);
            }
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(Texture2D, Position, SourceRectangle, Color, m_Direction, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
