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

        protected EnemyButton(AbstractEntity aEntity, Keys aHotKey)
        {
            mEntity = aEntity;
            mHotKey = ((char)((int)aHotKey));

            theButtonManager.Add(this);
        }

        static public void Create(AbstractEntity aEntity, Keys aHotKey)
        {
            new EnemyButton(aEntity, aHotKey);
        }
        #endregion
    }
}
