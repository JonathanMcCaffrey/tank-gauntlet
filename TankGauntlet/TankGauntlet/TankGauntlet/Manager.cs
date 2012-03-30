using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public static class Manager
    {
        public static List<BaseActor> ActorList = new List<BaseActor>();

        public static void Update(GameTime a_GameTime)
        {
            for (int loop = 0; loop < ActorList.Count; loop++)
            {
                ActorList[loop].Update(a_GameTime);
            }
        }

        public static void Draw(SpriteBatch a_SpriteBatch)
        {
            for (int loop = 0; loop < ActorList.Count; loop++)
            {
                ActorList[loop].Draw(a_SpriteBatch);
            }
        }
    }
}
