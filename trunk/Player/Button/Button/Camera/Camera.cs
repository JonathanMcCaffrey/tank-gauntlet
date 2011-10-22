using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    /** The abstraction for all game cameras. */
    public class Camera
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected CameraManager theCameraManager = CameraManager.Get();
        #endregion

        #region Data
        private GraphicsDevice mGraphicsDevice;
        public GraphicsDevice GraphicsDevice
        {
            get { return mGraphicsDevice; }
            set { mGraphicsDevice = value; }
        }

        private Vector3 mCameraPosition = Vector3.Zero;
        public Vector3 CameraPosition
        {
            get { return mCameraPosition; }
            set { mCameraPosition = value; }
        }

        private Vector3 mCameraTarget = Vector3.One;
        public Vector3 CameraTarget
        {
            get { return mCameraTarget; }
            set { mCameraTarget = value; }
        }

        private Vector3 mCameraUp = Vector3.Up;
        public Vector3 CameraUp
        {
            get { return mCameraUp; }
            set { mCameraUp = value; }
        }

        public Matrix mScale = Matrix.Identity;

        public Matrix WorldMatrix
        {
            get { return mScale * Matrix.CreateTranslation(mCameraPosition); }
        }

        public Matrix ViewMatrix
        {
            get { return Matrix.CreateLookAt(mCameraPosition, mCameraTarget, mCameraUp); }
        }

        public Matrix ProjectionMatrix
        {
            get { return Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, theFileManager.GraphicsDevice.Viewport.AspectRatio, 10, 10000); }
        }

        public float Rotation
        {
            get { return MathHelper.ToDegrees((float)Math.Atan2((mCameraTarget.X - mCameraPosition.X), (mCameraTarget.Z - mCameraPosition.Z))); }
        }
        #endregion

        #region Construction and Intialization
        public Camera()
        {
            GraphicsDevice = theFileManager.GraphicsDevice;

            theCameraManager.Add(this);

            CameraTarget = new Vector3(0, 0, 0);
        }

        static public void CreateCamera()
        {
           new Camera();
        }
        #endregion

        #region Methods
        public void Update()
        {
           
        }

        public void Draw()
        {
            foreach (EffectPass pass in theFileManager.BasicEffect.CurrentTechnique.Passes)
            {
                theFileManager.BasicEffect.View = this.ViewMatrix;
                theFileManager.BasicEffect.Projection = this.ProjectionMatrix;
                theFileManager.BasicEffect.World = this.WorldMatrix;
                theFileManager.BasicEffect.VertexColorEnabled = true;

                pass.Apply();
            }
        }
        #endregion
    }
}