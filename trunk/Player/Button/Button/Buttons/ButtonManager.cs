using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Button
{
    /** Singleton that handles all game files. */
    public class ButtonManager : DrawableGameComponent
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
        private AbstractEntityManager mEntityManager = null;
        public AbstractEntityManager EntityManager
        {
            get { return mEntityManager; }
            set { mEntityManager = value; }
        }


        private List<Button> mList = new List<Button>();
        public List<Button> List
        {
            get { return mList; }
        }
        #endregion

        #region Construction
        protected ButtonManager(Game aGame)
            : base(aGame) { }
        static ButtonManager Instance;
        static public ButtonManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new ButtonManager(aGame);
            }

            return Instance;
        }
        static public ButtonManager Get()
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

        public override void Draw(GameTime aGameTime)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Draw();
            }
        }

        public void Add(Button aEntity)
        {
            List.Add(aEntity);
        }

        public void Remove(Button aEntity)
        {
            List.Remove(aEntity);
        }

        public void Clear()
        {
            List.Clear();
        }
   
        public string Statistic()
        {
            int temporaryStatistic = mList.Count;

            return "Total: " + temporaryStatistic.ToString();
        }

        public void SetTile(AbstractEntity aEntity)
        {

        }

        public void GenerateEntity(Vector2 aWorldPosition)
        {
            if (mEntityManager != null)
            {
                mEntityManager.Generate(aWorldPosition);
            }
        }
        #endregion
    }
}