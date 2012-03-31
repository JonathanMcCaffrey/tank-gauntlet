using Microsoft.Xna.Framework;

namespace TankGauntlet
{
    public static class Camera
    {
        public static Vector2 Position = Vector2.Zero;

        public static Matrix Matrix
        {
            get { return Matrix.CreateTranslation(Position.X, Position.Y, 0); }
        }
    }
}
