using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public static class ActorMananger
    {
        public static List<BaseActor> List = new List<BaseActor>();

        public static void Update(GameTime a_GameTime)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Update(a_GameTime);
            }
        }

        public static void Draw(SpriteBatch a_SpriteBatch)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Draw(a_SpriteBatch);
            }
        }

        public static void SafeAdd(BaseActor a_BaseActor)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                if (List[loop].Position == a_BaseActor.Position)
                {
                    List.Remove(List[loop]);
                }
            }

            List.Add(a_BaseActor);
        }
    }
}
