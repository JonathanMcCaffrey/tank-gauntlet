using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BaseActor
    {
        public Texture2D m_Texture2D;
        public Vector2 m_Position;
        protected Vector2 m_Origin;
        protected int m_Id;
        protected Rectangle m_SourceRectangle;
        protected Color m_Color;
        protected float m_Rotation;
        protected float m_Scale;
        protected float m_LayerDepth;
        protected SpriteEffects m_SpriteEffects;

        public Rectangle CollisionRectangle
        {
            get { return new Rectangle((int)m_Position.X, (int)m_Position.Y, m_SourceRectangle.Width, m_SourceRectangle.Height); } 
        }

        protected static int idSeed = 0;
        public BaseActor() { }
        public BaseActor(ContentManager a_ContentManager)
        {
            m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/MetalWall");
            m_Position = Vector2.Zero; 
            m_Origin = new Vector2(m_Texture2D.Width / 2.0f, m_Texture2D.Height / 2.0f);
            m_Id = idSeed++;
            m_SourceRectangle = new Rectangle(0,0, m_Texture2D.Width, m_Texture2D.Height);
            m_Color = Color.White;
            m_Rotation = 0; 
            m_Scale = 1.0f; 
            m_LayerDepth = 1.0f;
            m_SpriteEffects = SpriteEffects.None;
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
            a_SpriteBatch.Draw(m_Texture2D, m_Position, m_SourceRectangle, m_Color, m_Rotation, m_Origin, m_Scale, m_SpriteEffects, m_LayerDepth);
        }
    }
}
