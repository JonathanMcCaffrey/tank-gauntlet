using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Data
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

        public BallActor() { }
        public BallActor(Vector2 a_Position, int a_BallType)
            : base()
        {
            m_Position = a_Position;
            m_IsCollidable = true;
            m_IsDestructable = true;

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
        }
    }
}
