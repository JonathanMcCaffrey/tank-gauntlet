using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class WorldScreen : AbstractGameScreen
    {
        #region Data
        Texture2D mBackgroundTexture;
        #endregion

        #region Construction
        public WorldScreen()
        {
            mBackgroundTexture = theFileManager.LoadTexture2D("GameBackground");

            theEnemyManager.Clear();
            EnemyTurret.CreateEnemy(Vector2.Zero);
         //   Enemy.CreateEnemy(Vector2.Zero);
        }

        public WorldScreen(string aFilePath)
        {
            mBackgroundTexture = theFileManager.LoadTexture2D("GameBackground");
            theTileManager.Clear();
            theTileManager.Load(aFilePath);
        }

        #endregion

        #region Methods
        public override void Update(GameTime aGameTime)
        {
            base.Update(aGameTime);

            theCollisionManager.Reset();

            theTileManager.Update(aGameTime);
            thePlayerManager.Update(aGameTime);
            theButtonManager.Update(aGameTime);
            theEnemyManager.Update(aGameTime);
            theProjectileManager.Update(aGameTime);
        }

        public override void Draw(GameTime aGameTime)
        {
            Console.WriteLine(aGameTime.ElapsedGameTime.Ticks);

            for (int loopX = 0; loopX < (theFileManager.GraphicsDevice.Viewport.Width / mBackgroundTexture.Width) + 1; loopX ++)
            {
                for (int loopY = 0; loopY < (theFileManager.GraphicsDevice.Viewport.Height / mBackgroundTexture.Height) + 1; loopY ++)
                {
                    int posX = mBackgroundTexture.Width * loopX;
                    int posY = mBackgroundTexture.Height * loopY;

                    SpriteBatch.Draw(mBackgroundTexture, new Vector2(posX, posY), Color.Wheat);
                }
            }

            theTileManager.Draw(aGameTime);
            theButtonManager.Draw(aGameTime);
            theProjectileManager.Draw(aGameTime);
            theEnemyManager.Draw(aGameTime);
            thePlayerManager.Draw(aGameTime);
        }
        #endregion
    }
}
