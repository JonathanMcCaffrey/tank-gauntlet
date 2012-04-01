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
    public class BaseWeapon
    {
        private float m_Rotation = 0;

        private Texture2D m_Texture2D;
        protected Texture2D Texture2D
        {
            get { return m_Texture2D; }
        }
        private BaseActor m_Parent;
        protected BaseActor Parent
        {
            get { return m_Parent; }
        }

        public BaseWeapon(Texture2D a_Texture2D, BaseActor a_BaseActor)
        {
            m_Texture2D = a_Texture2D;
            m_Parent = a_BaseActor;
        }

        public virtual void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;

            if (Input.OldTouchCollection.Count > 0 && Input.CurrentTouchCollection.Count > 0)
            {
                if (Input.OldTouchCollection[0].State == TouchLocationState.Released && Input.CurrentTouchCollection[0].State == TouchLocationState.Pressed)
                {
                    ActorManager.List.Add(new LockOnActor("Sprite/LockOn_Bullet", Input.CurrentTouchCollection[0].Position - Camera.Position));

                    Vector2 direction = Input.CurrentTouchCollection[0].Position - Parent.Position - Camera.Position;
                        m_Rotation = (float)Math.Atan2(direction.X, -direction.Y);

                        ProjectileManager.List.Add(new BaseProjectile(File.ContentManager.Load<Texture2D>("Sprite/Projectile_Bullet"), m_Parent, m_Parent.Position, m_Rotation));
          
                }
            }
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(Texture2D, Parent.Position, Parent.SourceRectangle, Parent.Color, m_Rotation, Parent.Origin, Parent.Scale, Parent.SpriteEffects, Parent.LayerDepth);
        }
    }
}
