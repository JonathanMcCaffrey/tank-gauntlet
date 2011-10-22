using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace Button
{
    /** Singleton that handles all game cameras. */
    public class CameraManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region Data
        List<Camera> mCameraList = new List<Camera>();

        public int Count
        {
            get { return mCameraList.Count; }
        }
        #endregion

        #region Construction
        private CameraManager(Game aGame)
            : base(aGame) { }
        static CameraManager CameraManagerInstance;
        static public CameraManager Get(Game aGame)
        {
            if (null == CameraManagerInstance)
            {
                CameraManagerInstance = new CameraManager(aGame);
            }

            return CameraManagerInstance;
        }
        static public CameraManager Get()
        {
            return CameraManagerInstance;
        }
        #endregion

        #region GameLoop
        public override void Update(GameTime aGameTime)
        {
            base.Update(aGameTime);

            for (int i = 0; i < mCameraList.Count; i++)
            {
                mCameraList[i].Update();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            for (int i = 0; i < mCameraList.Count; i++)
            {
                mCameraList[i].Draw();
            }
        }
        #endregion

        #region CameraList
        public void Add(Camera aAbstractCamera)
        {
            mCameraList.Add(aAbstractCamera);
        }

        public void Remove(Camera aAbstractCamera)
        {
            mCameraList.Remove(aAbstractCamera);
        }

        public Camera GetCamera(int aIndex)
        {
            return mCameraList[aIndex];
        }
        #endregion
    }
}