using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Button
{
    /** Singleton that handles all game states.*/
    public class ScreenManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Data
        private AbstractGameScreen mMenuScreen;
        public AbstractGameScreen MenuScreen
        {
            get { return mMenuScreen; }
            set { mMenuScreen = value; }
        }

        private AbstractGameScreen mNextMenuScreen;
        public AbstractGameScreen NextMenuScreen
        {
            get { return mNextMenuScreen; }
            set { mNextMenuScreen = value; }
        }

        private AbstractGameScreen mWorldScreen;
        public AbstractGameScreen WorldScreen
        {
            get { return mWorldScreen; }
            set { mWorldScreen = value; }
        }

        private AbstractGameScreen mNextWorldScreen;
        public AbstractGameScreen NextWorldScreen
        {
            get { return mNextWorldScreen; }
            set { mNextWorldScreen = value; }
        }

        #endregion

        #region Construction
        private ScreenManager(Game aGame)
            : base(aGame) { }
        static ScreenManager ScreenManagerInstance;
        static public ScreenManager Get(Game aGame)
        {
            if (null == ScreenManagerInstance)
            {
                ScreenManagerInstance = new ScreenManager(aGame);
            }

            return ScreenManagerInstance;
        }
        static public ScreenManager Get()
        {
            return ScreenManagerInstance;
        }
        #endregion

        #region Loading
        protected override void LoadContent()
        {
            base.LoadContent();
        }
        #endregion

        #region GameLoop
        public override void Update(GameTime aGameTime)
        {
            if (mMenuScreen != null)
            {
                mMenuScreen.Update(aGameTime);
            }
            else if (mWorldScreen != null)
            {
                mWorldScreen.Update(aGameTime);
            }
        }

        public override void Draw(GameTime aGameTime)
        {
            if (mMenuScreen != null)
            {
                mMenuScreen.Draw(aGameTime);
            }
            else if (mWorldScreen != null)
            {
                mWorldScreen.Draw(aGameTime);
            }
        }
        #endregion

        #region ScreenList
        public void SetBattleScreen(AbstractGameScreen aAbstractScreen)
        {
            mMenuScreen = aAbstractScreen;
            mMenuScreen.LoadContent();
        }

        public void SetWorldScreen(AbstractGameScreen aAbstractScreen)
        {
            mWorldScreen = aAbstractScreen;
            mWorldScreen.LoadContent();
        }

        public AbstractGameScreen GetHighState()
        {
            return mMenuScreen;
        }

        public AbstractGameScreen GetLowState()
        {
            return mWorldScreen;
        }

        public void RemoveBattleScreen()
        {
            mMenuScreen = null;
        }

        public string Statistic()
        {
            return "State: " + mMenuScreen.ToString();
        }
        #endregion
    }
}
