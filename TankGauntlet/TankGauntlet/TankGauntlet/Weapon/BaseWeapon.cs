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
        protected ContentManager m_ContentManager;

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

        public BaseWeapon(ContentManager a_ContentManager, Texture2D a_Texture2D, BaseActor a_BaseActor)
        {
            m_ContentManager = a_ContentManager;
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
                        ActorMananger.List.Add(new LockOnActor(m_ContentManager, m_ContentManager.Load<Texture2D>("Sprite/LockOn_Bullet"), Input.CurrentTouchCollection[0].Position));

                        Vector2 direction = Input.CurrentTouchCollection[0].Position - Parent.Position;
                        m_Rotation = (float)Math.Atan2(direction.X, -direction.Y);

                        ProjectileManager.List.Add(new BaseProjectile(m_ContentManager, m_ContentManager.Load<Texture2D>("Sprite/Projectile_Bullet"), m_Parent.Position, m_Rotation));
          
                }
            }
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.Draw(Texture2D, Parent.Position, Parent.SourceRectangle, Parent.Color, m_Rotation, Parent.Origin, Parent.Scale, Parent.SpriteEffects, Parent.LayerDepth);
        }
    }
}
