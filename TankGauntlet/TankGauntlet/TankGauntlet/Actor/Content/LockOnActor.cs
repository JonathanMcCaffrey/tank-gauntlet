using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class LockOnActor : BaseActor
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

        public LockOnActor(ContentManager a_ContentManager, Texture2D a_Texture2D, Vector2 a_Position)
            : base(a_ContentManager)
        {
            m_Texture2D = a_Texture2D;
            m_Position = a_Position;

            Initialize();
        }

        float timer = 0;
        float maxTime = 8;
        public override void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            float speed = 4.0f;
            timer += elapsed;

            float temp = (maxTime - timer) / maxTime;

            m_Color.A -= 10;

            if (timer > maxTime)
            {
                ActorMananger.List.Remove(this);
            }
        }
    }
}
