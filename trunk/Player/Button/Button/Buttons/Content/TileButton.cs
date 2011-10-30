using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class TileButton : GenericButton
    {
         #region Construction
        public TileButton()
        {
        }

        protected TileButton(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            mEntityManager = theTileManager;
            mFilePathToGraphic = aFilePathToGraphic;
            isCollidable = aIsCollidable;
            mHotKey = ((char)((int)aHotKey));

            theButtonManager.Add(this);
        }

        static public void Create(string aFilePathToGraphic, bool aIsCollidable)
        {
            new TileButton(aFilePathToGraphic, aIsCollidable, Keys.Escape);
        }

        static public void Create(string aFilePathToGraphic, bool aIsCollidable, Keys aHotKey)
        {
            new TileButton(aFilePathToGraphic, aIsCollidable, aHotKey);
        }
        #endregion
    }
}
