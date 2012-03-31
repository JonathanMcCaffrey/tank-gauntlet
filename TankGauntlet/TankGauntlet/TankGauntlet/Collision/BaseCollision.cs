using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class BaseCollision
    {
        #region Data
        protected List<BaseActor> m_ActorList = new List<BaseActor>();
        protected List<BaseProjectile> m_ProjectileList = new List<BaseProjectile>();
        protected List<TileActor> m_TileList = new List<TileActor>();

        protected float m_Range = 600;

        protected Vector2 m_CheckPositionOld = Vector2.Zero;
        protected Vector2 m_CheckPositionCurrent = Vector2.Zero;
        protected float m_CheckMaxDisplacement = 25;
        protected float CheckDisplacement
        {
            get { return Displacement(m_CheckPositionOld, m_CheckPositionCurrent); }
        }

        protected Vector2 m_UpdatePositionOld = Vector2.Zero;
        protected Vector2 m_UpdatePositionCurrent = Vector2.Zero;
        protected float m_UpdateMaxDisplacement = 100;
        protected float UpdateDisplacement
        {
            get { return Displacement(m_UpdatePositionOld, m_UpdatePositionCurrent); }
        }
        #endregion

        #region Methods
        public virtual void Update(GameTime a_GameTime)
        {

        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {

        }

        protected virtual void UpdateCollision()
        {
            for (int loop = 0; loop < CollisionManager.ActorList.Count; loop++)
            {
                if (Displacement(m_UpdatePositionCurrent, CollisionManager.ActorList[loop].Position) < m_Range)
                {
                    m_ActorList.Add(CollisionManager.ActorList[loop]);
                }
            }

            for (int loop = 0; loop < CollisionManager.ProjectileList.Count; loop++)
            {
                if (Math.Abs(Displacement(m_UpdatePositionCurrent, CollisionManager.ProjectileList[loop].Position)) < m_Range)
                {
                    m_ProjectileList.Add(CollisionManager.ProjectileList[loop]);
                }
            }
        }

        protected float Displacement(Vector2 aPosition_1, Vector2 aPosition_2)
        {
            float tempDisplacement = 0;

            tempDisplacement = (float)Math.Sqrt((aPosition_1.X - aPosition_2.X) * (aPosition_1.X - aPosition_2.X) +
                                                (aPosition_1.Y - aPosition_2.Y) * (aPosition_1.Y - aPosition_2.Y));
            return tempDisplacement;
        }

        protected virtual bool CheckCollision()
        {
            return false;
        }
        #endregion
    }
}
