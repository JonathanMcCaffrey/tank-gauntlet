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
        BasicEffect m_Effect;

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

            m_Effect = new BasicEffect(GraphicsDevice);
            m_Effect.EnableDefaultLighting();

            m_SpriteBatch = new SpriteBatch(GraphicsDevice);
            m_SplashScreen = Content.Load<Texture2D>("Screen/SplashScreen");

            CollisionManager.ContentManager = Content;
            ScoreManager.SpriteFont = Content.Load<SpriteFont>("Font/ScoreMain");

            ActorMananger.List.Add(new BallActor(Content, new Vector2(100, 250), BallType.Yellow));
            ActorMananger.List.Add(new BallActor(Content, new Vector2(200, 250), BallType.Green));
            ActorMananger.List.Add(new BallActor(Content, new Vector2(300, 250), BallType.Blue));
            ActorMananger.List.Add(new BallActor(Content, new Vector2(400, 250), BallType.Red));
            ActorMananger.List.Add(new BallActor(Content, new Vector2(500, 250), BallType.Bomb));
            ActorMananger.List.Add(new PlayerActor(Content, new Vector2(300, 300)));

            base.Initialize();
        }

        float time = 0;
        protected override void Update(GameTime a_GameTime)
        {
            if (m_IsGameStarted)
            {
                time += a_GameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            }

            if (time > 4 && m_IsGameStarted)
            {
                ActorMananger.List.Add(new BallActor(Content, new Vector2(100, 250), BallType.Yellow));
                ActorMananger.List.Add(new BallActor(Content, new Vector2(200, 250), BallType.Green));
                ActorMananger.List.Add(new BallActor(Content, new Vector2(300, 250), BallType.Blue));
                ActorMananger.List.Add(new BallActor(Content, new Vector2(400, 250), BallType.Red));
                ActorMananger.List.Add(new BallActor(Content, new Vector2(500, 250), BallType.Bomb));

                time = 0;
            }

            Input.Update();

            if (m_IsGameStarted == false)
            {
                if (Input.Gesture.GestureType == GestureType.Tap)
                {
                    m_IsGameStarted = true;
                }
            }
            else
            {
                ActorMananger.Update(a_GameTime);
                ProjectileManager.Update(a_GameTime);
                WeaponManager.Update(a_GameTime);
                CollisionManager.Update(a_GameTime);
                ScoreManager.Update(a_GameTime);
            }

            base.Update(a_GameTime);
        }

        protected override void Draw(GameTime a_GameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            m_SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Matrix.CreateTranslation(0,0,0));
//            m_SpriteBatch.Begin(SpriteSortMode.Texture, BlendState.AlphaBlend, SamplerState.PointWrap, DepthStencilState.None, RasterizerState.CullNone, null, Matrix.CreateTranslation(0, 0, 0));

            if (m_IsGameStarted != true)
            {
                m_SpriteBatch.Draw(m_SplashScreen, Vector2.Zero, Color.White);
            }
            else
            {
                ActorMananger.Draw(m_SpriteBatch);
                ProjectileManager.Draw(m_SpriteBatch);
                WeaponManager.Draw(m_SpriteBatch);
                ScoreManager.Draw(m_SpriteBatch);
            }

            m_SpriteBatch.End();

            base.Draw(a_GameTime);
        }
    }
}
