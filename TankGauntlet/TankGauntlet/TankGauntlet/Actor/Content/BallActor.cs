using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TankGauntlet
{
    public enum BallType
    {
        Bomb,
        Red,
        Green,
        Blue,
        Yellow
    }

    public class BallActor : BaseActor
    {
        private BallType m_BallType;
        public BallType BallType
        {
            get { return m_BallType; }
            set { m_BallType = value; }
        }

        protected BallCollision m_BallCollision;

        protected float m_Speed;
        public float m_Direction;

        protected SpriteFont m_DebugFont;

        public Vector2 Velocity
        {
            get { return new Vector2((float)(Math.Cos(m_Direction) * m_Speed), (float)(Math.Sin(m_Direction) * m_Speed)); }
        }

        static protected int seed = 0;
        public BallActor(Vector2 a_Position, int a_BallType)
            : base()
        {
            m_Position = a_Position;
            m_IsCollidable = true;
            m_IsDestructable = true;
            m_Speed = 30.0f;
            m_Direction = MathHelper.ToRadians((float)(new Random(seed++).NextDouble() * 360));

            m_BallCollision = new BallCollision(this);

            m_BallType = (BallType)a_BallType;
            #region Ball Texture
            switch (m_BallType)
            {
                case BallType.Bomb:
                    m_FilePathToTexture = "Sprite/Ball_Bomb";
                    break;

                case BallType.Red:
                    m_FilePathToTexture = "Sprite/Ball_Red";
                    break;

                case BallType.Green:
                   m_FilePathToTexture = "Sprite/Ball_Green";
                    break;

                case BallType.Blue:
                   m_FilePathToTexture = "Sprite/Ball_Blue";
                    break;

                case BallType.Yellow:
                    m_FilePathToTexture = "Sprite/Ball_Yellow";
                    break;
            }
            #endregion

            CollisionManager.ActorList.Add(this);
        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);

#if !WINDOWS

            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            Position += (Velocity * elapsed);

            if (m_Direction > MathHelper.ToRadians(360))
            {
                m_Direction -= MathHelper.ToRadians(360);
            }

            m_BallCollision.Update(a_GameTime);
#endif
        }

        public BallActor Clone()
        {
            return new BallActor(m_Position, (int)m_BallType);
        }
    }
}
