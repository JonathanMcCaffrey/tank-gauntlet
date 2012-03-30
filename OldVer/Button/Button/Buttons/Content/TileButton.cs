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

        protected TileButton(AbstractEntity aEntity, Keys aHotKey)
        {
            mEntity = aEntity;
            mHotKey = ((char)((int)aHotKey));

            theButtonManager.Add(this);
        }

        static public void Create(AbstractEntity aEntity, Keys aHotKey)
        {
            new TileButton(aEntity, aHotKey);
        }
        #endregion
    }
}
