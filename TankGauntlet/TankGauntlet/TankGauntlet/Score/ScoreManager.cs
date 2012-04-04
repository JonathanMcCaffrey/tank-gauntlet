using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class ScoreManager
    {
        public static List<BaseScore> List = new List<BaseScore>();

        public static float Score = 0;

        public static SpriteFont SpriteFont;
        private static Vector2 Position = new Vector2(630, 20);

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

            if (Score >= 0)
            {
                a_SpriteBatch.DrawString(SpriteFont, "Score: " + Score.ToString(), Position - Camera.Position, Color.Green);
            }
            else
            {
                a_SpriteBatch.DrawString(SpriteFont, "Score: " + Score.ToString(), Position - Camera.Position, Color.Red);
            }
           
        }
    }
}
