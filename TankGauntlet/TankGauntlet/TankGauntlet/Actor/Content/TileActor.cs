using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class TileActor : BaseActor
    {
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

        public TileActor(string a_FilePathToModel, Vector2 a_Position, bool a_IsCollidable)
            : base()
        {
            m_FilePathToModel = a_FilePathToModel;
            m_Position = a_Position;
            m_IsCollidable = a_IsCollidable;

            Initialize();
        }

        public TileActor Clone()
        {
            return new TileActor(m_FilePathToModel, m_Position, m_IsCollidable);
        }
    }
}
