using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    class ProjectileCollision : CollisionMachine
    {
        #region Data
        private AbstractProjectile mProjectile;
        #endregion

        #region Construction
        public ProjectileCollision(AbstractProjectile aProjectile)
        {
            mProjectile = aProjectile;
            UpdateCollision();
        }
        #endregion

        #region Methods
        public override void Update()
        {
            mCheckPositionCurrent = mProjectile.WorldPosition;
            mUpdatePositionCurrent = mProjectile.WorldPosition;

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
                    mProjectile.WorldPosition = mProjectile.OldPosition;
                }
                else
                {
                    mProjectile.OldPosition = mProjectile.WorldPosition;
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
        }

        protected override bool CheckCollision()
        {
            for (int loop = 0; loop < mEntityList.Count; loop++)
            {
                if (mEntityList[loop].CollisionRectangle.Intersects(mProjectile.CollisionRectangle))
                {
                    if (mEntityList[loop] != mProjectile.Shooter)
                    {
                        mEntityList[loop].Damage();
                        theProjectileManager.Remove(mProjectile);
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion
    }
}
