using System;

namespace TankGauntlet
{
#if WINDOWS || XBOX
    static class Program
    {
#if WINDOWS
        [STAThread]
#endif
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Run();
            }
        }
    }
#endif
}

