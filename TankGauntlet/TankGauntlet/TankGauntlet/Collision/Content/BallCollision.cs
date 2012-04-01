using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class BallCollision : BaseCollision
    {
        BallActor m_Actor;

        public BallCollision(BallActor a_Actor)
        {
            m_Actor = a_Actor;
            UpdateCollision();
        }

        public override void Update(GameTime a_GameTime)
        {
            m_CheckPositionCurrent = m_Actor.Position;
            m_UpdatePositionCurrent = m_Actor.Position;

            if (UpdateDisplacement > m_UpdateMaxDisplacement)
            {
                m_UpdatePositionOld = m_UpdatePositionCurrent;
                UpdateCollision();
            }
            if (CheckDisplacement > m_CheckMaxDisplacement)
            {
                m_CheckPositionOld = m_CheckPositionCurrent;
                if (CheckCollision())
                {
                    m_Actor.m_Direction += MathHelper.ToRadians(180);
                }
            }
        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }

        protected override bool CheckCollision()
        {
            for (int loop = 0; loop < m_ActorList.Count; loop++)
            {
                if (m_ActorList[loop].CollisionRectangle.Intersects(m_Actor.CollisionRectangle))
                {
                    if (m_ActorList[loop] != m_Actor)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

    }
}
