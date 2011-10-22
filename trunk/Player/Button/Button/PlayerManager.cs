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
    public class PlayerManager : DrawableGameComponent
    {
        #region Data
        private List<PlayerFactory> mList = new List<PlayerFactory>();
        public List<PlayerFactory> List
        {
            get { return mList; }
        }
        #endregion

        #region Construction
        private PlayerManager(Game aGame)
            : base(aGame) { }
        static PlayerManager Instance;
        static public PlayerManager GetManager(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new PlayerManager(aGame);
            }

            return Instance;
        }
        static public PlayerManager GetManager()
        {
            return Instance;
        }
        #endregion

        #region GameLoop
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
        #endregion

        #region Methods
        public void Add(PlayerFactory aActor)
        {
            List.Add(aActor);
        }

        public void Remove(PlayerFactory aActor)
        {
            List.Remove(aActor);
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