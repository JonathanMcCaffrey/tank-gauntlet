using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public static class CollisionManager
    {
        public static BaseActor Player;
        public static List<BaseActor> ActorList = new List<BaseActor>();
        public static List<BaseProjectile> ProjectileList = new List<BaseProjectile>();
        public static ContentManager ContentManager;


        public static void Update(GameTime a_GameTime)
        {
            for (int projectileLoop = 0; projectileLoop < ProjectileList.Count; projectileLoop++)
            {
                for (int actorLoop = 0; actorLoop < ActorList.Count; actorLoop++)
                {
                    if (ProjectileList[projectileLoop].CollisionRectangle.Intersects(ActorList[actorLoop].CollisionRectangle))
                    {
                        ScoreManager.List.Add(new BaseScore(ContentManager, ProjectileList[projectileLoop].Position, ContentManager.Load<SpriteFont>("Font/Score"), 10, Color.Green));

                        ProjectileManager.List.Remove(ProjectileList[projectileLoop]);
                        ActorMananger.List.Remove(ActorList[actorLoop]);

                        ProjectileList.Remove(ProjectileList[projectileLoop]);
                        ActorList.Remove(ActorList[actorLoop]);

                     

                        return;
                    }
                }
            }


        }
    }
}
