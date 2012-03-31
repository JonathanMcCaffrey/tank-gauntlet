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
    public class PlayerActor : BaseActor
    {
        BaseWeapon m_Weapon;

        public PlayerActor(ContentManager a_ContentManager, Vector2 a_Position)
            : base(a_ContentManager)
        {
            m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Tank_Base");
            m_Position = a_Position;

            m_Weapon = new BaseWeapon(a_ContentManager, a_ContentManager.Load<Texture2D>("Sprite/Tank_Gun"), this);
            WeaponManager.List.Add(m_Weapon);

            Initialize();
        }

        protected override void Initialize()
        {
            base.Initialize();

            m_Origin = new Vector2(32, 64 - 18);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);

            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;

            if (Input.Gesture.GestureType == GestureType.DragComplete)
            {
                return;
            }

            if (Input.Gesture.GestureType == GestureType.FreeDrag)
            {
                if (Distance(Input.Gesture.Position, m_Position) > 100)
                {

                    Vector2 velocity = Vector2.Normalize(Input.Gesture.Position - m_Position) * 15.0f * elapsed;

                    m_Position += velocity;

                    if (velocity.X != 0 || velocity.Y != 0)
                    {
                        m_Rotation = (float)Math.Atan2(velocity.X, -velocity.Y);
                    }


                    if (Input.OldTouchCollection.Count > 0 && Input.CurrentTouchCollection.Count > 0)
                    {
                        if (Input.OldTouchCollection[0].State == TouchLocationState.Moved && Input.CurrentTouchCollection[0].State == TouchLocationState.Moved)
                        {
                            ActorMananger.List.Add(new LockOnActor(m_ContentManager, m_ContentManager.Load<Texture2D>("Sprite/LockOn_GoTo"), Input.CurrentTouchCollection[0].Position));
                        }
                    }
                }
            }

        }

        public float Distance(Vector2 a_Position, Vector2 a_Desination)
        {
            return (float) Math.Sqrt((a_Position.X - a_Desination.X) * (a_Position.X - a_Desination.X) + 
                    (a_Position.Y - a_Desination.Y) * (a_Position.Y - a_Desination.Y));

        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }
        
    }
}
