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
    public class AbstractEntityManager : DrawableGameComponent
    {
        #region Data
        protected List<AbstractEntity> mList = new List<AbstractEntity>();
        public virtual List<AbstractEntity> List
        {
            get { return mList; }
        }
        #endregion

        #region Construction
        protected AbstractEntityManager(Game aGame)
            : base(aGame) { }
        static AbstractEntityManager Instance;
        static public AbstractEntityManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new AbstractEntityManager(aGame);
            }

            return Instance;
        }
        static public AbstractEntityManager Get()
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

        public void Add(AbstractEntity aEntity)
        {
            List.Add(aEntity);
        }

        public void Remove(AbstractEntity aEntity)
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