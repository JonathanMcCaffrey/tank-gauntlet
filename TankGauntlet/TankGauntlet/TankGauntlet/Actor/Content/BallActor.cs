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
        protected BallState m_BaseState;

        public BallActor(ContentManager a_ContentManager, Vector2 a_Position, BallType a_BallType)
            : base(a_ContentManager)
        {
            m_Position = a_Position;
            m_IsCollidable = true;

            m_BallType = a_BallType;
            #region Ball Texture
            switch (m_BallType)
            {
                case BallType.Bomb:
                    m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Ball_Bomb");
                    break;

                case BallType.Red:
                    m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Ball_Red");
                    break;

                case BallType.Green:
                    m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Ball_Green");
                    break;

                case BallType.Blue:
                    m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Ball_Blue");
                    break;

                case BallType.Yellow:
                    m_Texture2D = a_ContentManager.Load<Texture2D>("Sprite/Ball_Yellow");
                    break;
            }
            #endregion

            m_BaseState = new BallState(this, a_ContentManager);

            CollisionManager.ActorList.Add(this);

            Initialize();
        }

        public override void Draw(SpriteBatch a_SpriteBatch)
        {
            base.Draw(a_SpriteBatch);

            m_BaseState.Draw(a_SpriteBatch);
        }

        public override void Update(GameTime a_GameTime)
        {
            base.Update(a_GameTime);

            m_BaseState.Update(a_GameTime);
        }
    }
}
