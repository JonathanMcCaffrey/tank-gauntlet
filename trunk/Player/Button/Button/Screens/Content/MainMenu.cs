using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class MainMenu : AbstractMenuScreen
    {
        #region Construction
        public MainMenu()
        {
            MenuEntries.Add("StartGame");
            MenuEntries.Add("Level Select");
        }
        #endregion

        #region Methods
        protected override void MenuSelect(int aSelectedEntry)
        {           
           switch (aSelectedEntry)
            {
                case 0:
                theScreenManager.WorldScreen = new WorldScreen();
                theScreenManager.MenuScreen = null;
                break;

                case 1:
                theScreenManager.MenuScreen = new  LevelSelect();
                break;
            }
        }
        #endregion
    }
}
