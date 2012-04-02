using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Data
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

        public TurretActor() { }
        public TurretActor(Vector2 a_Position, int a_TurretType)
            : base()
        {
            m_Position = a_Position;
            m_IsCollidable = true;
            m_IsDestructable = true;

            m_FilePathToTexture = "Sprite/Turret_Base";
        }
    }
}
