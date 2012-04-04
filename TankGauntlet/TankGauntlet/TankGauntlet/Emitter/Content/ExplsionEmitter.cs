using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class ExplosionEmitter : BaseEmitter
    {
        #region Construction
        public ExplosionEmitter(Color a_Tint, Vector2 a_Position) : base(a_Tint, a_Position)
        {
            m_Position = a_Position;
            m_RotationMin = MathHelper.ToRadians(0);
            m_RotationMax = MathHelper.ToRadians(360);
            m_Amount = 26;
            m_LifeMin = 10.8f;
            m_LifeMax = 20.6f;
            m_Tint = a_Tint;
            m_SpeedMin = 0.5f;
            m_SpeedMax = 8.8f;

            Initialize();
        }
        #endregion
    }
}
