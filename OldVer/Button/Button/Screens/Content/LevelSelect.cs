using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class LevelSelect : AbstractMenuScreen
    {
        #region Construction
        public LevelSelect()
        {
            for (int loop = 0; loop < 10; loop++)
            {
                String levelName = "Level: " + (loop + 1);

                MenuEntries.Add(levelName);
            }
        }
        #endregion

        #region Methods
        protected override void MenuSelect(int aSelectedEntry)
        {
            switch (aSelectedEntry)
            {
                default:

                    string filePath = "Level_" + (aSelectedEntry + 1) + ".xml";
                    theScreenManager.WorldScreen = new WorldScreen(filePath);
                    theScreenManager.MenuScreen = null;
                    break;
            }
        }
        #endregion
    }
}
