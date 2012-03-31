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
        protected BallType m_BallType;
        protected BallCollision m_BallCollision;

        protected float m_Speed;
        protected float m_MaxSpeed = 10;
        private float m_Direction;
        public float Direction
        {
            get { return m_Direction; }
            set { m_Direction = value; }
        }

        protected SpriteFont m_DebugFont;

        public Vector2 Velocity
        {
            get { return new Vector2((float)(Math.Cos(m_Direction) * m_Speed), (float)(Math.Sin(m_Direction) * m_Speed)); }
        }

        static protected int seed = 0;
        public BallActor(Vector2 a_Position, BallType a_BallType)
            : base()
        {
            m_Position = a_Position;
            m_IsCollidable = true;
            m_Speed = 30.0f;
            m_Direction = MathHelper.ToRadians((float)(new Random(seed++).NextDouble() * 360));

            m_BallCollision = new BallCollision(this);

            m_BallType = a_BallType;
            #region Ball Texture
            switch (m_BallType)
            {
                case BallType.Bomb:
                    m_FilePathToModel = "Sprite/Ball_Bomb";
                    break;

                case BallType.Red:
                    m_FilePathToModel = "Sprite/Ball_Red";
                    break;

                case BallType.Green:
                   m_FilePathToModel = "Sprite/Ball_Green";
                    break;

                case BallType.Blue:
                   m_FilePathToModel = "Sprite/Ball_Blue";
                    break;

                case BallType.Yellow:
                    m_FilePathToModel = "Sprite/Ball_Yellow";
                    break;
            }
            #endregion

            CollisionManager.ActorList.Add(this);

            Initialize();
        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);

            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            Vector2 projectedLocation = Position + (Velocity * elapsed);

            if (m_Direction > MathHelper.ToRadians(360))
            {
                m_Direction -= MathHelper.ToRadians(360);
            }

            if (projectedLocation.X >= 0 && projectedLocation.Y >= 0 && projectedLocation.X <= 800 && projectedLocation.Y <= 480)
            {
                Position = projectedLocation;
            }
            else
            {
                m_Direction += (float)MathHelper.ToRadians(180) + (float)(new Random(seed++).NextDouble() * MathHelper.ToRadians(90));
            }

            m_BallCollision.Update(a_GameTime);
        }
    }
}
