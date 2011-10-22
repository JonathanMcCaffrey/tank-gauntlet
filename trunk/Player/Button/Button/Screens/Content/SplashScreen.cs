using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Button
{
    public class SplashScreen : AbstractMenuScreen
    {
        #region Data
        Texture2D mSplashImage;
        #endregion

        #region Construction
        public SplashScreen()
        {
            mSplashImage = theFileManager.LoadTexture2D("Website");
        }
        #endregion

        #region Methods
        public override void Draw(Microsoft.Xna.Framework.GameTime aGameTime)
        {
            base.Draw(aGameTime);

            Vector2 tempVector = new Vector2(theFileManager.ScreenCenter.X - mSplashImage.Width / 2, theFileManager.ScreenCenter.Y - mSplashImage.Height * 4);

            theFileManager.SpriteBatch.Draw(mSplashImage, tempVector, Color.White);
        }
        #endregion
    }
}
