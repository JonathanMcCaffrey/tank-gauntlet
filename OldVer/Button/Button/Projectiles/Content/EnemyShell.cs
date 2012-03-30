using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    class EnemyShell : AbstractProjectile
    {
        #region Construction
        private EnemyShell(Vector2 aVelocity, Vector2 aWorldCoordinate, AbstractEntity aShooter)
        {
            mCollisionMachine = new ProjectileCollision(this);
            mVelocity = aVelocity;
            WorldPosition = aWorldCoordinate;
            mShooter = aShooter;

            Speed = 20;
            MaxDistance = 3000;
            FilePathToGraphic = "Bullet";

            Manager.Add(this);
        }

        static public void CreateProjectile(Vector2 aVelocity, Vector2 aWorldCoordinate, AbstractEntity aShooter)
        {
            new EnemyShell(aVelocity, aWorldCoordinate, aShooter);
        }
        #endregion
    }
}
