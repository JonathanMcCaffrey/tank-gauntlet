using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    class EntityCollision : CollisionMachine
    {
        #region Data
        private AbstractEntity mEntity;
        #endregion

        #region Construction
        public EntityCollision(AbstractEntity aEntity)
        {
            mEntity = aEntity;
            UpdateCollision();
        }
        #endregion

        #region Methods
        public override void Update()
        {
            mCheckPositionCurrent = mEntity.WorldPosition;
            mUpdatePositionCurrent = mEntity.WorldPosition;

            if (UpdateDisplacement > mUpdateMaxDisplacement)
            {
                mUpdatePositionOld = mUpdatePositionCurrent;
                UpdateCollision();
            }
            if (CheckDisplacement > mCheckMaxDisplacement)
            {
                mCheckPositionOld = mCheckPositionCurrent;
                if (CheckCollision())
                {
                    mEntity.WorldPosition = mEntity.OldPosition;
                }
                else
                {
                    mEntity.OldPosition = mEntity.WorldPosition;
                }
            }
        }

        protected override void UpdateCollision()
        {
            mEntityList.Clear();
            for (int loop = 0; loop < theCollisionManager.ListEntity.Count; loop++)
            {
                if (Displacement(mUpdatePositionCurrent, theCollisionManager.ListEntity[loop].WorldPosition) < mRange)
                {
                    mEntityList.Add(theCollisionManager.ListEntity[loop]);
                }
            }

            mProjectileList.Clear();
            for (int loop = 0; loop < theCollisionManager.ListProjectile.Count; loop++)
            {
                if (Math.Abs(Displacement(mUpdatePositionCurrent, theCollisionManager.ListProjectile[loop].WorldPosition)) < mRange)
                {
                    mProjectileList.Add(theCollisionManager.ListProjectile[loop]);
                }
            }
        }

        protected override bool CheckCollision()
        {
            for (int loop = 0; loop < mEntityList.Count; loop++)
            {
                if (mEntityList[loop].CollisionRectangle.Intersects(mEntity.CollisionRectangle))
                {
                    if (mEntityList[loop] != mEntity)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion
    }
}
