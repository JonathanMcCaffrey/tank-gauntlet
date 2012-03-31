using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public class BallState : BaseState
    {
        public BallState(BaseActor a_Actor, ContentManager a_ContentManager)
            : base(a_Actor, a_ContentManager)
        {
            m_Parent = a_Actor;
            m_Speed = 30.0f;
            m_Direction = MathHelper.ToRadians((float)(new Random(seed++).NextDouble() * 360));
        }

        public override void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            Vector2 projectedLocation = m_Parent.Position + (Velocity * elapsed);

            if (m_Direction > MathHelper.ToRadians(360))
            {
                m_Direction -= MathHelper.ToRadians(360);
            }

            if (projectedLocation.X >= 0 && projectedLocation.Y >= 0 && projectedLocation.X <= 800 && projectedLocation.Y <= 480)
            {
                m_Parent.Position = projectedLocation;
            }
            else
            {
                m_Direction += (float)MathHelper.ToRadians(180) + (float)(new Random(seed++).NextDouble() * MathHelper.ToRadians(90));
            }
        }
    }
}
