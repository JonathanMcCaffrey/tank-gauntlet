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
        static Random rand = new Random();

        public BallCollision(BallActor a_Actor)
        {
            m_Actor = a_Actor;
            m_CheckMaxDisplacement = 25;
            m_UpdateMaxDisplacement = 25;
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
                if (File.Distance(m_ActorList[loop].Position, m_Actor.Position) < 64)
                {
                    if (m_ActorList[loop] != m_Actor)
                    {
                        if (m_ActorList[loop] is PlayerActor)
                        {
                            ScoreManager.List.Add(new BaseScore(m_ActorList[loop].Position, -105, Color.Red));

                            EmitterManager.List.Add(new ExplosionEmitter(Color.Orange, m_ActorList[loop].Position));
                            EmitterManager.List.Add(new BaseEmitter(Color.Red, m_ActorList[loop].Position));
                            EmitterManager.List.Add(new ExplosionEmitter(Color.Black, m_ActorList[loop].Position));

                            m_ActorList.Remove(m_Actor);
                            ActorManager.List.Remove(m_Actor);
                            CollisionManager.ActorList.Remove(m_Actor);
                        }

                        return true;
                    }
                }
            }

            return false;
        }

    }
}
