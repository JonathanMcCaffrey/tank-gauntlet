using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class TileData
    {
        /* protected Texture2D m_Texture2D;
         public virtual Texture2D Texture2D
         {
             get { return m_Texture2D; }
         }*/

        protected bool m_IsCollidable = false;
        protected bool IsCollidable
        {
            get { return m_IsCollidable; }
        }
        protected Vector2 m_Position = Vector2.Zero;
        public virtual Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }
        protected Vector2 m_Origin = Vector2.Zero;
        public virtual Vector2 Origin
        {
            get { return m_Origin; }
        }
        protected Rectangle m_SourceRectangle = Rectangle.Empty;
        public virtual Rectangle SourceRectangle
        {
            get { return m_SourceRectangle; }
        }
        protected Color m_Color = Color.Tomato;
        public virtual Color Color
        {
            get { return m_Color; }
        }
        protected float m_Rotation = 0;
        public virtual float Rotation
        {
            get { return m_Rotation; }
        }
        protected float m_Scale = 1.0f;
        public virtual float Scale
        {
            get { return m_Scale; }
        }
        protected float m_LayerDepth = 1.0f;
        public virtual float LayerDepth
        {
            get { return m_LayerDepth; }
        }
        protected SpriteEffects m_SpriteEffects = SpriteEffects.None;
        public virtual SpriteEffects SpriteEffects
        {
            get { return m_SpriteEffects; }
        }
    }
}
