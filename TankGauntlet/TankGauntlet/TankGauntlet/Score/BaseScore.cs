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
    public class BaseScore
    {
        protected ContentManager m_ContentManager;

        protected Vector2 m_Position;
        protected SpriteFont m_SpriteFont;
        protected int m_Amount;
        protected Color m_Color;

        private Texture2D m_Texture2D;
        protected Texture2D Texture2D
        {
            get { return m_Texture2D; }
        }

        protected String m_Text;
       

        public BaseScore(ContentManager a_ContentManager, Vector2 a_Position, SpriteFont a_SpriteFont, int a_Amount, Color a_Color)
        {
            m_ContentManager = a_ContentManager;
            m_Position = a_Position;
            m_SpriteFont = a_SpriteFont;
            m_Amount = a_Amount;
            m_Color = a_Color;

            m_Text = "+" + m_Amount.ToString();
        }

        float timer = 0;
        float maxTime = 8;
        public virtual void Update(GameTime a_GameTime)
        {
            float elapsed = a_GameTime.ElapsedGameTime.Milliseconds / 100.0f;
            float speed = 4.0f;

            timer += elapsed;

            float temp = (maxTime - timer) / maxTime;
            m_Color.A = (byte)(temp * 255);

            m_Position += new Vector2(elapsed, -elapsed) * speed;

            if (timer > maxTime)
            {
                ScoreManager.Score += m_Amount;
                ScoreManager.List.Remove(this);
            }
        }

        public virtual void Draw(SpriteBatch a_SpriteBatch)
        {
            a_SpriteBatch.DrawString(m_SpriteFont, m_Text, m_Position, m_Color); 
        }
    }
}
