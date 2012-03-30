using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class CollisionMachine
    {
        #region Singletons
        protected CollisionManager theCollisionManager = CollisionManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ProjectileManager theProjectileManager = ProjectileManager.Get();
        #endregion

        #region Data
        protected List<AbstractEntity> mEntityList = new List<AbstractEntity>();
        protected List<AbstractProjectile> mProjectileList = new List<AbstractProjectile>();

        // Testing for tiles seperately because they cannot move.
        protected List<Tile> mTileList = new List<Tile>();


        protected float mRange = 600;

        protected Vector2 mCheckPositionOld = Vector2.Zero;
        protected Vector2 mCheckPositionCurrent = Vector2.Zero;
        protected float mCheckMaxDisplacement = 25;
        protected float CheckDisplacement
        {
            get { return Displacement(mCheckPositionOld, mCheckPositionCurrent); }
        }

        protected Vector2 mUpdatePositionOld = Vector2.Zero;
        protected Vector2 mUpdatePositionCurrent = Vector2.Zero;
        protected float mUpdateMaxDisplacement = 300;
        protected float UpdateDisplacement
        {
            get { return Displacement(mUpdatePositionOld, mUpdatePositionCurrent); }
        }
        #endregion

        #region Methods
        public virtual void Update()
        {
           
        }

        protected float Displacement(Vector2 aPosition_1, Vector2 aPosition_2)
        {
            float tempDisplacement = 0;

            tempDisplacement = (float)Math.Sqrt((aPosition_1.X - aPosition_2.X) * (aPosition_1.X - aPosition_2.X) + 
                                                (aPosition_1.Y - aPosition_2.Y) * (aPosition_1.Y - aPosition_2.Y));
            return tempDisplacement;
        }

        protected virtual void UpdateCollision()
        {
            for (int loop = 0; loop < theCollisionManager.ListEntity.Count; loop++)
            {
                if (Displacement(mUpdatePositionCurrent, theCollisionManager.ListEntity[loop].WorldPosition) < mRange)
                {
                    mEntityList.Add(theCollisionManager.ListEntity[loop]);
                }
            }

            for (int loop = 0; loop < theCollisionManager.ListProjectile.Count; loop++)
            {
                if (Math.Abs(Displacement(mUpdatePositionCurrent, theCollisionManager.ListProjectile[loop].WorldPosition)) < mRange)
                {
                    mProjectileList.Add(theCollisionManager.ListProjectile[loop]);
                }
            }
        }

        protected virtual bool CheckCollision()
        {
            return false;
        }
        #endregion
    }
}
