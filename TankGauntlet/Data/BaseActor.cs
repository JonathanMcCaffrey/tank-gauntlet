using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Data
{
    public class BaseActor
    {
        protected string m_FilePathToModel;
        public string FilePathToModel
        {
            get { return m_FilePathToModel; }
            set { m_FilePathToModel = value; }
        }

        protected bool m_IsCollidable;
        public bool IsCollidable
        {
            get { return m_IsCollidable; }
            set { m_IsCollidable = value; }
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
    }
}
