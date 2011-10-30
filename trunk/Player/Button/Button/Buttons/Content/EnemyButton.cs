using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class EnemyButton : GenericButton
    {
         #region Construction
        public EnemyButton()
        {
        }

        protected EnemyButton(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            mEntityManager = theTileManager;
            mFilePathToGraphic = aFilePathToGraphic;
            isCollidable = aIsCollidable;
            mHotKey = ((char)((int)aHotKey));

            theButtonManager.Add(this);
        }

        static public void Create(string aFilePathToGraphic, bool aIsCollidable)
        {
            new EnemyButton(aFilePathToGraphic, aIsCollidable, Keys.Escape);
        }

        static public void Create(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            new EnemyButton(aFilePathToGraphic, aIsCollidable, aHotKey);
        }
        #endregion
    }
}
