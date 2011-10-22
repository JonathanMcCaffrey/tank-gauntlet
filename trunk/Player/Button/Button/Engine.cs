using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNA3DGizmo
{
    public static class Engine
    {

        public static List<SceneEntity> Entities = new List<SceneEntity>();

        public static Matrix View;
        public static Matrix Projection;
        public static Vector3 CameraPosition;

        public static GraphicsDevice Graphics;

        public static void SetupEngine(GraphicsDevice graphics)
        {
            Graphics = graphics;
        }

        public static void Update()
        {
            foreach (SceneEntity entity in Entities)
            {
                entity.Update();
            }
        }

        public static void Draw()
        {
            foreach (SceneEntity entity in Entities)
            {
                entity.Draw();
            }
        }
    }
}
