using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TankGauntlet
{
    public class BaseState
    {
        public BaseActor m_Actor;

        public float m_Velocity;
        public float m_MaxSpeed = 10;
        public float m_Direction;

        public Vector2 Velocity
        {
            get { return new Vector2((float)(Math.Cos(m_Direction) * m_Velocity), (float)(Math.Sin(m_Direction) * m_Velocity)); }
        }
             

        public BaseState()
        {
            m_Velocity = 10;
            m_Direction = MathHelper.ToRadians(90);
        }

        public void Update(GameTime a_GameTime)
        {
            m_Actor.m_Position += Velocity * a_GameTime.ElapsedGameTime.Seconds;
        }
    }
}
