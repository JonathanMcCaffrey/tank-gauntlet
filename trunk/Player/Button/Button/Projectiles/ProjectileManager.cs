using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Button
{
    /** Singleton that handles all game files. */
    public class ProjectileManager : DrawableGameComponent
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        #endregion

        #region Data
        private List<AbstractProjectile> mList = new List<AbstractProjectile>();
        public List<AbstractProjectile> List
        {
            get { return mList; }
        }
        #endregion

        #region Construction
        private ProjectileManager(Game aGame)
            : base(aGame) { }
        static ProjectileManager Instance;
        static public ProjectileManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new ProjectileManager(aGame);
            }

            return Instance;
        }
        static public ProjectileManager Get()
        {
            return Instance;
        }
        #endregion

        #region Methods
        public override void Update(GameTime aGameTime)
        {
            for (int i = 0; i < mList.Count; i++)
            {
                List[i].Update();
            }
        }

        public void Draw(GameTime aGameTime)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Draw();
            }
        }

        public void Add(AbstractProjectile aProjectile)
        {
            List.Add(aProjectile);
        }

        public void Remove(AbstractProjectile aProjectile)
        {
            List.Remove(aProjectile);
        }

        public void Clear()
        {
            List.Clear();
        }

        #endregion
    }
}