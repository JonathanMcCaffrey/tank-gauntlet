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

        public LockOnActor(string a_FilePathToModel, Vector2 a_Position)
            : base()
        {
            m_FilePathToTexture = a_FilePathToModel;
            m_Position = a_Position;
        }

        float timer = 0;
        float maxTime = 8;
        public override void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            timer += elapsed;

            float temp = (maxTime - timer) / maxTime;

            m_Color.A -= 10;

            if (timer > maxTime)
            {
                ActorManager.List.Remove(this);
            }
        }
    }
}
