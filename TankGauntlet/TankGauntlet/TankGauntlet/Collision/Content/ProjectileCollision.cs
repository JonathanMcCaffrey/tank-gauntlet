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

        public ProjectileCollision(BaseProjectile a_Projectile, BaseActor a_Parent)
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
                        if (m_ActorList[loop].IsDestructable)
                        {
                            if (m_Parent is PlayerActor)
                            {
                                if (m_ActorList[loop] is BallActor)
                                {
                                    ScoreManager.List.Add(new BaseScore(m_ActorList[loop].Position, 10, Color.Green));
                                }
                            }

                            EmitterManager.List.Add(new BaseEmitter(Color.Red, m_ActorList[loop].Position));
                            EmitterManager.List.Add(new BaseEmitter(Color.Red, m_Projectile.Position));

                            CollisionManager.ActorList.Remove(m_ActorList[loop]);


                            if (m_ActorList[loop] is TileActor)
                            {
                                ScoreManager.List.Add(new BaseScore(m_ActorList[loop].Position, 25, Color.Green));
                                m_ActorList[loop].FilePathToTexture = "Sprite/Tile_RockFloor";
                                m_ActorList[loop].IsCollidable = false;
                                m_ActorList[loop].IsDestructable = false;
                            }
                            else
                            {
                                ActorManager.List.Remove(m_ActorList[loop]);
                            }

                            m_ActorList.Remove(m_ActorList[loop]);
                        }
                        else
                        {
                            EmitterManager.List.Add(new BaseEmitter(Color.Orange, m_Projectile.Position));
                        }

                        CollisionManager.ProjectileList.Remove(m_Projectile);
                        ProjectileManager.List.Remove(m_Projectile);

                        return true;
                    }
                }
            }

            return false;
        }

    }
}
