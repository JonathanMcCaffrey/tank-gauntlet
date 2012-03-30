using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BaseActor
    {
        #region Data
        protected Texture2D m_Texture2D;
        public virtual Texture2D Texture2D
        {
            get { return m_Texture2D; }
        }

        protected bool m_IsCollidable;
        protected bool IsCollidable
        {
            get { return m_IsCollidable; }
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

        protected ContentManager m_ContentManager;
        #endregion

        public BaseActor(ContentManager a_ContentManager)
        {
            m_ContentManager = a_ContentManager;
            m_Position = Vector2.Zero;
            m_IsCollidable = false;
            m_Color = Color.White;
            m_Rotation = 0;
            m_Scale = 1.0f;
            m_LayerDepth = 1.0f;
            m_SpriteEffects = SpriteEffects.None;
        }

        protected void Initialize()
        {
            m_Origin = new Vector2(m_Texture2D.Width / 2.0f, m_Texture2D.Height / 2.0f);
            m_SourceRectangle = new Rectangle(0, 0, m_Texture2D.Width, m_Texture2D.Height);
        }

        public virtual void Update(GameTime a_GameTime)
        {
            if (CollisionRectangle.Contains(new Point((int)Input.Gesture.Position.X, (int)Input.Gesture.Position.Y)))
            {
                Manager.ActorList.Remove(this);
            }
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(Texture2D, Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
