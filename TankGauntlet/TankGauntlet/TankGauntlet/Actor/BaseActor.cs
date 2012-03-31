using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BaseActor
    {
        #region Data

        protected string m_FilePathToModel;
        public string FilePathToModel
        {
            get { return m_FilePathToModel; }
            set { m_FilePathToModel = value; }
        }

      /*  [ContentSerializerIgnore]
        protected Texture2D m_Texture2D;
        public virtual Texture2D Texture2D
        {
            get { return m_Texture2D; }
        }*/
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
            m_Color = Color.White;
            m_Rotation = 0;
            m_Scale = 1.0f;
            m_LayerDepth = 1.0f;
            m_SpriteEffects = SpriteEffects.None;
        }

        protected virtual void Initialize()
        {
            m_Origin = new Vector2(File.ContentManager.Load<Texture2D>(m_FilePathToModel).Width / 2.0f, File.ContentManager.Load<Texture2D>(m_FilePathToModel).Height / 2.0f);
            m_SourceRectangle = new Rectangle(0, 0, File.ContentManager.Load<Texture2D>(m_FilePathToModel).Width, File.ContentManager.Load<Texture2D>(m_FilePathToModel).Height);
        }

        public virtual void Update(GameTime a_GameTime)
        {
            /* if (CollisionRectangle.Contains(new Point((int)Input.Gesture.Position.X, (int)Input.Gesture.Position.Y)))
             {
                 Manager.ActorList.Remove(this);
             }*/
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(File.ContentManager.Load<Texture2D>(m_FilePathToModel), Position, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
