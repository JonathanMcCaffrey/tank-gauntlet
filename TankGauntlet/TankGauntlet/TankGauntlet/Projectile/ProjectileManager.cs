using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public static class ProjectileManager
    {
        public static List<BaseProjectile> List = new List<BaseProjectile>();

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
    }
}
