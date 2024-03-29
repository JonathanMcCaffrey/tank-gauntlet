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

        protected Vector2 m_Position = Vector2.Zero;
        protected float m_RotationMin = 0;
        protected float m_RotationMax = 0;
        protected float m_LifeMin = 0;
        protected float m_LifeMax = 0;
        protected Color m_Tint = Color.White;
        protected float m_SpeedMin = 0;
        protected float m_SpeedMax = 0;
        protected float m_Amount = 0;

        static Random rand = new Random(randSeed++);
        #endregion

        #region Construction
        static int randSeed = 0;
        public BaseEmitter(Color a_Tint, Vector2 a_Position)
        {
            m_Position = a_Position;
            m_RotationMin = MathHelper.ToRadians(0);
            m_RotationMax = MathHelper.ToRadians(360);
            m_Amount = 9;
            m_LifeMin = 10.8f;
            m_LifeMax = 20.6f;
            m_Tint = a_Tint;
            m_SpeedMin = 0.1f;
            m_SpeedMax = 2.8f;

            Initialize();

            EmitterManager.List.Add(this);
        }

        protected void Initialize()
        {
            for (int loop = 0; loop < m_Amount; loop++)
            {
                float tempRotation = (float)(rand.NextDouble() * (m_RotationMax - m_RotationMin));
                tempRotation += m_RotationMin;

                float tempLife = (float)(rand.NextDouble() * (m_LifeMax - m_LifeMin));
                tempLife += m_LifeMin;

                float tempSpeed = (float)(rand.NextDouble() * (m_SpeedMax - m_SpeedMin));
                tempSpeed += m_SpeedMin;

                Particle tempParticle = new Particle(this);

                tempParticle.LifeTotal = tempLife;
                tempParticle.Rotation = tempRotation;
                tempParticle.Speed = tempSpeed;

                tempParticle.Tint = m_Tint;
                tempParticle.Position = m_Position;

                List.Add(tempParticle);
            }  
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
