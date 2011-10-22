using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    class TankShell : AbstractProjectile
    {
        #region Construction
        private TankShell(Vector2 aScreenCoordinate, Vector2 aWorldCoordinate, AbstractEntity aShooter)
        {
            mCollisionMachine = new ProjectileCollision(this);
            WorldPosition = aWorldCoordinate + aScreenCoordinate;
            mStartinPosition = WorldPosition;
            mShooter = aShooter;

            Speed = 20;
            MaxDistance = 3000;
            FilePathToGraphic = "Bullet";
            Velocity = thePlayerManager.List[0].Velocity;

            float e = thePlayerManager.List[0].GunDirection;

            Velocity = new Vector2((float)Math.Sin(e), -(float)Math.Cos(e));


            Velocity.Normalize();

            Manager.Add(this);
        }

        static public void CreateProjectile(Vector2 aScreenCoordinate, Vector2 aWorldCoordinate, AbstractEntity aShooter)
        {
            new TankShell(aScreenCoordinate, aWorldCoordinate, aShooter);
        }
        #endregion
    }
}
