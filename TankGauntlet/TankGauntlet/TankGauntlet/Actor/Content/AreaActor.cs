using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public enum AreaType
    {
        Start,
        Finish
    }

    public class AreaActor : BaseActor
    {
        private AreaType m_AreaType;
        public AreaType AreaType
        {
            get { return m_AreaType; }
            set { m_AreaType = value; }
        }

        #region Properties
        public override Vector2 Position
        {
            get
            {
                if (m_Position.X % SourceRectangle.Width < 32)
                {
                    if (m_Position.X % SourceRectangle.Width != 0)
                    {
                        m_Position.X -= m_Position.X % SourceRectangle.Width;
                    }
                }
                else
                {
                    if (m_Position.X % SourceRectangle.Width != 0)
                    {
                        m_Position.X += SourceRectangle.Width - (m_Position.X % SourceRectangle.Width);
                    }
                }

                if (m_Position.Y % SourceRectangle.Width < 32)
                {
                    if (m_Position.Y % SourceRectangle.Height != 0)
                    {
                        m_Position.Y -= m_Position.Y % SourceRectangle.Height;
                    }
                }
                else
                {
                    if (m_Position.Y % SourceRectangle.Height != 0)
                    {
                        m_Position.Y += SourceRectangle.Height - (m_Position.Y % SourceRectangle.Height);
                    }
                }

                return base.Position;
            }

        }
        #endregion

        public AreaActor(Vector2 a_Position, int a_AreaType)
            : base()
        {
            m_AreaType = (AreaType)a_AreaType;

            if (m_AreaType == AreaType.Start)
            {
                m_FilePathToTexture = "Sprite/Area_Start";
            }
            if (m_AreaType == AreaType.Finish)
            {
                m_FilePathToTexture = "Sprite/Area_Finish";
                CollisionManager.ActorList.Add(this);
            }
            m_Position = a_Position;

            m_SourceRectangle = new Rectangle(0, 0, 192, 192);
            m_Origin = new Vector2(96, 96);
        }

        public AreaActor Clone()
        {
            return new AreaActor(m_Position, (int)m_AreaType);
        }
    }
}
