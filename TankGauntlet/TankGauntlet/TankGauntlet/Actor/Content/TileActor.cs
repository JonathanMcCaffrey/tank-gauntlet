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

        public TileActor(string a_FilePathToModel, Vector2 a_Position, bool a_IsCollidable, bool a_IsDestructable)
            : base()
        {
            m_FilePathToTexture = a_FilePathToModel;
            m_Position = a_Position;
            m_IsCollidable = a_IsCollidable;
            m_IsDestructable = a_IsDestructable;

            if (m_IsCollidable)
            {
                CollisionManager.ActorList.Add(this);
            }
        }

        public TileActor Clone()
        {
            return new TileActor(m_FilePathToTexture, m_Position, m_IsCollidable, m_IsDestructable);
        }
    }
}
