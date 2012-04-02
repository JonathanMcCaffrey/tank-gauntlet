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
        PlayerCollision m_PlayerCollision;

        private Vector2 m_Give;
        public Vector2 Give
        {
            get {
                m_Give = Vector2.Clamp(m_Give, -EigthDimensions, EigthDimensions);


                return m_Give; }
            set { m_Give = value; }
        }

        public PlayerActor(string a_FilePathToMode, Vector2 a_Position)
            : base()
        {
            m_FilePathToTexture = a_FilePathToMode;
            m_Position = a_Position;

            m_IsCollidable = true;
            m_IsDestructable = true;

            m_PlayerCollision = new PlayerCollision(this);
            m_Weapon = new BaseWeapon(File.ContentManager.Load<Texture2D>("Sprite/Tank_Gun"), this);
            WeaponManager.List.Add(m_Weapon);
            CollisionManager.ActorList.Add(this);

            m_Origin = new Vector2(32, 64 - 18);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);

            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;

            Camera.Position = -Position + new Vector2(ScreenDimensions.Width / 2, ScreenDimensions.Height / 2) + Give;

            if (Input.Gesture.GestureType == GestureType.FreeDrag || Input.Gesture.GestureType ==  GestureType.Hold)
            {
                if (File.Distance(Input.Gesture.Position - Camera.Position, m_Position) > 100)
                {
                    Vector2 velocity = Vector2.Normalize(Input.Gesture.Position - Camera.Position - m_Position) * 15.0f * elapsed;

                    m_Position += velocity;

                    Give -= velocity;

                    if (velocity.X != 0 || velocity.Y != 0)
                    {
                        Rotation = (float)Math.Atan2(velocity.X, -velocity.Y);
                    }


                    if (Input.OldTouchCollection.Count > 0 && Input.CurrentTouchCollection.Count > 0)
                    {
                        if (Input.OldTouchCollection[0].State == TouchLocationState.Moved && Input.CurrentTouchCollection[0].State == TouchLocationState.Moved)
                        {
                            ActorManager.List.Add(new LockOnActor("Sprite/LockOn_GoTo", Input.CurrentTouchCollection[0].Position - Camera.Position));
                        }
                    }
                }
            }

            m_PlayerCollision.Update(a_GameTime);

        }


        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }
        
    }
}
