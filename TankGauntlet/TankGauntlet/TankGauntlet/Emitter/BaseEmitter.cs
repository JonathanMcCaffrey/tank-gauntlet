using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public class BaseEmitter
    {
        #region Fields
        public List<Particle> List = new List<Particle>();

        private Vector2 m_Position = Vector2.Zero;
        private float m_RotationMin = 0;
        private float m_RotationMax = 0;
        private float m_LifeMin = 0;
        private float m_LifeMax = 0;
        private Color m_Tint = Color.White;
        private float m_SpeedMin = 0;
        private float m_SpeedMax = 0;
        private float m_Amount = 0;
        #endregion



        #region Construction
        static int randSeed = 0;
        public BaseEmitter(Color a_Tint, Vector2 a_Position)
        {
            m_Position = a_Position;
            m_RotationMin = MathHelper.ToRadians(0);
            m_RotationMax = MathHelper.ToRadians(360);
            m_Amount = 90;
            m_LifeMin = 10.8f;
            m_LifeMax = 20.6f;
            m_Tint = a_Tint;
            m_SpeedMin = 0.1f;
            m_SpeedMax = 0.8f;

            for (int loop = 0; loop < m_Amount; loop++)
            {
                float tempRotation = (float)(new Random(EmitterManager.List.Count + loop + randSeed++).NextDouble() * (m_RotationMax - m_RotationMin));
                tempRotation += m_RotationMin;

                float tempLife = (float)(new Random(EmitterManager.List.Count + loop + randSeed++).NextDouble() * (m_LifeMax - m_LifeMin));
                tempLife += m_LifeMin;

                float tempSpeed = (float)(new Random(EmitterManager.List.Count + loop + randSeed++).NextDouble() * (m_SpeedMax - m_SpeedMin));
                tempSpeed += m_SpeedMin;

                Particle tempParticle = new Particle(this);

                tempParticle.LifeTotal = tempLife;
                tempParticle.Rotation = tempRotation;
                tempParticle.Speed = tempSpeed;
                
                tempParticle.Tint = m_Tint;
                tempParticle.Position = a_Position;

                List.Add(tempParticle);
            }

            EmitterManager.List.Add(this);
        }
        #endregion

        #region Methods
        public void Update(GameTime a_GameTime)
        {
            if (List.Count == 0)
            {
                EmitterManager.List.Remove(this);
            }

            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Update(a_GameTime);
            }
        }

        public void Draw(SpriteBatch a_SpriteBatch)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Draw(a_SpriteBatch);
            }
        }
        #endregion
    }
}
