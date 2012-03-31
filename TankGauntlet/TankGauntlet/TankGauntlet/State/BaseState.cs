using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BaseState
    {
        protected static Rectangle ScreenDimensions = new Rectangle(0, 0, 800, 480);

        protected BaseActor m_Parent;

        protected float m_Speed;
        protected float m_MaxSpeed = 10;
        protected float m_Direction;

        protected ContentManager m_ContentManager;

        protected SpriteFont m_DebugFont;

        public Vector2 Velocity
        {
            get { return new Vector2((float)(Math.Cos(m_Direction) * m_Speed), (float)(Math.Sin(m_Direction) * m_Speed)); }
        }

        static protected int seed = 0;
        public BaseState(BaseActor a_Actor, ContentManager a_ContentManager)
        {
            m_Parent = a_Actor;
            m_Speed = 0;
            m_Direction = 0;

            m_ContentManager = a_ContentManager;
            m_DebugFont = m_ContentManager.Load<SpriteFont>("Font/Debug");
        }

        public virtual void Update(GameTime a_GameTime)
        {
            
        }


        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
          /*  a_SpriteBatch.DrawString(m_DebugFont,
                "Direction:" + MathHelper.ToDegrees(m_Direction).ToString() + "\nm_Speed:" + m_Speed.ToString(),
                m_Parent.Position,
                Color.White);*/
        }

    }
}
