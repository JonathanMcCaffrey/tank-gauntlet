using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace TankGauntlet
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager m_GraphicsDeviceManager;
        SpriteBatch m_SpriteBatch;

        Texture2D m_SplashScreen;

        bool m_IsGameStarted;

        public Game1()
        {
            m_GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            TargetElapsedTime = TimeSpan.FromTicks(333333);
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        protected override void Initialize()
        {
            Input.Initiailize();

            m_IsGameStarted = false;

            m_SpriteBatch = new SpriteBatch(GraphicsDevice);
            m_SplashScreen = Content.Load<Texture2D>("Screen/SplashScreen");

            base.Initialize();
        }

        protected override void Update(GameTime a_GameTime)
        {
            Input.Update();

            if (a_GameTime.TotalGameTime.TotalMilliseconds % 500 == 0)
            {
                Manager.ActorList.Add(new BaseActor(Content));
            }

            if (m_IsGameStarted == false)
            {
                if (Input.Gesture.GestureType == GestureType.Tap)
                {
                    m_IsGameStarted = true;
                }
            }
            else
            {
                Manager.Update(a_GameTime);
            }

            base.Update(a_GameTime);
        }

        protected override void Draw(GameTime a_GameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            m_SpriteBatch.Begin();

            if (m_IsGameStarted != true)
            {
                m_SpriteBatch.Draw(m_SplashScreen, Vector2.Zero, Color.White);
            }
            else
            {
                Manager.Draw(m_SpriteBatch);
            }

            m_SpriteBatch.End();

            base.Draw(a_GameTime);
        }
    }
}
