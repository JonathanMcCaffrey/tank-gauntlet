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
    public class PlayerManager : AbstractEntityManager
    {
        #region Data
        protected List<Player> mList = new List<Player>();
        public List<Player> List
        {
            get { return mList; }
        }
        #endregion

        #region Construction
        private PlayerManager(Game aGame)
            : base(aGame) { }
        static PlayerManager Instance;
        static public PlayerManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new PlayerManager(aGame);
            }

            return Instance;
        }
        static public PlayerManager Get()
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

        public void Add(Player aEntity)
        {
            List.Add(aEntity);
        }

        public void Remove(Player aEntity)
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

        #endregion
    }
}