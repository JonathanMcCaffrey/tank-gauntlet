using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;

namespace TankGauntlet
{
    public class TurretWeapon : BaseWeapon
    {
        private const float LookRange = 800.0f;
        private const float ShootRange = 400.0f;


        public TurretWeapon(Texture2D a_Texture2D, BaseActor a_BaseActor)
            : base(a_Texture2D, a_BaseActor)
        {
        }

        float timer = 0;
        public override void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            timer += elapsed;

            Vector2 shootDirection = File.Player.Position - m_Parent.Position;
            m_Rotation += ((float)Math.Atan2(shootDirection.X, -shootDirection.Y) - m_Rotation) * elapsed * 0.1f;

            if (timer > 15.0f)
            {
                if (File.Distance(File.Player.Position, m_Parent.Position) < ShootRange)
                {
                    ProjectileManager.List.Add(new BaseProjectile(File.ContentManager.Load<Texture2D>("Sprite/Projectile_Bullet"), m_Parent, m_Parent.Position, m_Rotation));
                }

                timer = 0;
            }
        }
    }
}
