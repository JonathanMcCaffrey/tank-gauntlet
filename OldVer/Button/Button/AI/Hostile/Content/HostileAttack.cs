using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class HostileAttack : HostileState
    {
        #region Data
        private HostileStateMachine mHostileStateMachine;
        private Enemy mEnemy;
        private Player mPlayer;
        private ProjectileManager theProjectileManager = ProjectileManager.Get();
        #endregion

        #region Construction
        public HostileAttack(HostileStateMachine aHostileStateMachine)
        {
            mHostileStateMachine = aHostileStateMachine;
            mEnemy = aHostileStateMachine.Enemy;
            mPlayer = (Player)thePlayerManager.List[0];
        }
        #endregion

        #region Methods
        public override void Update()
        {
            Vector2 velocity = -mEnemy.WorldPosition + (mPlayer.WorldPosition + mPlayer.ScreenPosition);
            velocity.Normalize();

            mEnemy.Velocity = velocity;

            mEnemy.Rotation = (float)Math.Atan2(velocity.X, -velocity.Y);

            EnemyShell.CreateProjectile(new Vector2(velocity.X, velocity.Y), mEnemy.WorldPosition, mEnemy);

            velocity = -mEnemy.WorldPosition + (mPlayer.WorldPosition + mPlayer.ScreenPosition) + new Vector2(50, 50);
            velocity.Normalize();

            EnemyShell.CreateProjectile(new Vector2(velocity.X, velocity.Y), mEnemy.WorldPosition, mEnemy);

            velocity = -mEnemy.WorldPosition + (mPlayer.WorldPosition + mPlayer.ScreenPosition) + new Vector2(-50, -50);
            velocity.Normalize();

            EnemyShell.CreateProjectile(new Vector2(velocity.X, velocity.Y), mEnemy.WorldPosition, mEnemy);


            /*
			float distance = SquareRoot(Square(mEnemy.WorldPosition.X - mPlayer.WorldPosition.X + mPlayer.ScreenPosition.X) +
                Square(mEnemy.WorldPosition.Y - mPlayer.WorldPosition.Y + mPlayer.ScreenPosition.Y));
			
			if (distance < 150)
			{
                mEnemy.HostileStateMachine.State = new HostileSeek(mHostileStateMachine);
			}*/

        }
        #endregion
    }
}
