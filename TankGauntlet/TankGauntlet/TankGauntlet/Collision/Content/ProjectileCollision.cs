using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class ProjectileCollision : BaseCollision
    {
        BaseProjectile m_Projectile;
        BaseActor m_Parent;

        public ProjectileCollision(BaseProjectile a_Projectile,BaseActor a_Parent)
        {
            m_Projectile = a_Projectile;
            m_Parent = a_Parent;

            UpdateCollision();
        }

        public override void Update(GameTime a_GameTime)
        {
            m_CheckPositionCurrent = m_Projectile.Position;
            m_UpdatePositionCurrent = m_Projectile.Position;

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
                if (m_ActorList[loop].CollisionRectangle.Intersects(m_Projectile.CollisionRectangle))
                {
                    if (m_ActorList[loop] != m_Parent)
                    {
                        EmitterManager.List.Add(new BaseEmitter(Color.Red, m_ActorList[loop].Position));
                        
                        CollisionManager.ActorList.Remove(m_ActorList[loop]);
                        CollisionManager.ProjectileList.Remove(m_Projectile);
                        ProjectileManager.List.Remove(m_Projectile);
                        ActorMananger.List.Remove(m_ActorList[loop]);
                        m_ActorList.Remove(m_ActorList[loop]);

                        return true;
                    }
                }
            }

            return false;
        }

    }
}
