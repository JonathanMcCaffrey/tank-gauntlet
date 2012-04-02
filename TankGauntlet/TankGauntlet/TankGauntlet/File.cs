using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace TankGauntlet
{
    public static class File
    {
        public static ContentManager ContentManager;
        public static PlayerActor Player;
        public static Random Random = new Random();


        public static float Distance(Vector2 a_Position, Vector2 a_Desination)
        {
            return (float)Math.Sqrt((a_Position.X - a_Desination.X) * (a_Position.X - a_Desination.X) +
                    (a_Position.Y - a_Desination.Y) * (a_Position.Y - a_Desination.Y));

        }
    }
}
