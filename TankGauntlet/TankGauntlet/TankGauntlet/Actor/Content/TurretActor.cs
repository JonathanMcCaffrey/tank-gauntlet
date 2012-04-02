using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public enum TurretType
    {
        Standard
    }

    public class TurretActor : BaseActor
    {
        private TurretType m_TurretType;
        public TurretType TurretType
        {
            get { return m_TurretType; }
            set { m_TurretType = value; }
        }

        private TurretWeapon m_Weapon;
        public TurretWeapon Weapon
        {
            get { return m_Weapon; }
            set { m_Weapon = value; }
        }

        #region Properties
        public override Vector2 Position
        {
            get
            {
                if (m_Position.X % SourceRectangle.Width < 32)
                {
                    if (m_Position.X % SourceRectangle.Width != 0)
                    {
                        m_Position.X -= m_Position.X % SourceRectangle.Width;
                    }
                }
                else
                {
                    if (m_Position.X % SourceRectangle.Width != 0)
                    {
                        m_Position.X += SourceRectangle.Width - (m_Position.X % SourceRectangle.Width);
                    }
                }

                if (m_Position.Y % SourceRectangle.Width < 32)
                {
                    if (m_Position.Y % SourceRectangle.Height != 0)
                    {
                        m_Position.Y -= m_Position.Y % SourceRectangle.Height;
                    }
                }
                else
                {
                    if (m_Position.Y % SourceRectangle.Height != 0)
                    {
                        m_Position.Y += SourceRectangle.Height - (m_Position.Y % SourceRectangle.Height);
                    }
                }

                return base.Position;
            }

        }
        #endregion

        static protected int seed = 0;
        public TurretActor(Vector2 a_Position, int a_TurretType)
            : base()
        {
            m_Position = a_Position;
            m_IsCollidable = true;
            m_IsDestructable = true;

            m_FilePathToTexture = "Sprite/Turret_Base";
            m_Weapon = new TurretWeapon(File.ContentManager.Load<Texture2D>("Sprite/Turret_Gun"), this);

#if !WINDOWS
            WeaponManager.List.Add(m_Weapon);

            CollisionManager.ActorList.Add(this);
#endif
        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);
        }

        public TurretActor Clone()
        {
            return new TurretActor(m_Position, (int)m_TurretType);
        }
    }
}
