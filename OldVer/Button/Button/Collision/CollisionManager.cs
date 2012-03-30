using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class CollisionManager : GameComponent
    {
        #region Singletons
        private EnemyManager theEnemyManager = EnemyManager.Get();
        private TileManager theTileManager = TileManager.Get();
        private PlayerManager thePlayerManager = PlayerManager.Get();
        private ProjectileManager theProjectileManager = ProjectileManager.Get();
        #endregion

        #region Data
        private List<AbstractEntity> mListEntity = new List<AbstractEntity>();
        public List<AbstractEntity> ListEntity
        {
            get { return mListEntity; }
            set { mListEntity = value; }
        }
        private List<AbstractProjectile> mListProjectile = new List<AbstractProjectile>();
        public List<AbstractProjectile> ListProjectile
        {
            get { return mListProjectile; }
            set { mListProjectile = value; }
        }

        #endregion

        #region Construction
        private CollisionManager(Game aGame)
            : base(aGame) { }
        static CollisionManager Instance;
        static public CollisionManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new CollisionManager(aGame);
            }

            return Instance;
        }
        static public CollisionManager Get()
        {
            return Instance;
        }
        #endregion

        #region Methods
        public void Reset()
        {
            mListEntity.Clear();
            mListProjectile.Clear();

            // Entities
            for (int loop = 0; loop < theEnemyManager.List.Count; loop++)
            {
                if (theEnemyManager.List[loop].IsCollidable == true)
                {
                    mListEntity.Add(theEnemyManager.List[loop]);
                }
            }
            for (int loop = 0; loop < theTileManager.List.Count; loop++)
            {
                if (theTileManager.List[loop].IsCollidable == true)
                {
                    mListEntity.Add(theTileManager.List[loop]);
                }
            }
            for (int loop = 0; loop < thePlayerManager.List.Count; loop++)
            {
                if (thePlayerManager.List[loop].IsCollidable == true)
                {
                    mListEntity.Add(thePlayerManager.List[loop]);
                }
            }
          
            //Projectiles
            for (int loop = 0; loop < mListProjectile.Count; loop++)
            {
                mListProjectile.Add(theProjectileManager.List[loop]);
            }
        }
        #endregion
    }
}
