using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (m_Position.X % m_SourceRectangle.Width < 32)
                {
                    if (m_Position.X % m_SourceRectangle.Width != 0)
                    {
                        m_Position.X -= m_Position.X % m_SourceRectangle.Width;
                    }
                }
                else
                {
                    if (m_Position.X % m_SourceRectangle.Width != 0)
                    {
                        m_Position.X += m_SourceRectangle.Width - (m_Position.X % m_SourceRectangle.Width);
                    }
                }

                if (m_Position.Y % m_SourceRectangle.Width < 32)
                {
                    if (m_Position.Y % m_SourceRectangle.Height != 0)
                    {
                        m_Position.Y -= m_Position.Y % m_SourceRectangle.Height;
                    }
                }
                else
                {
                    if (m_Position.Y % m_SourceRectangle.Height != 0)
                    {
                        m_Position.Y += m_SourceRectangle.Height - (m_Position.Y % m_SourceRectangle.Height);
                    }
                }

                return base.Position;
            }

        }
        #endregion

        public TileActor(ContentManager a_ContentManager, Texture2D a_Texture2D, Vector2 a_Position, bool a_IsCollidable)
            : base(a_ContentManager)
        {
            m_Texture2D = a_Texture2D;
            m_Position = a_Position;
            m_IsCollidable = a_IsCollidable;

            Initialize();
        }
    }
}
