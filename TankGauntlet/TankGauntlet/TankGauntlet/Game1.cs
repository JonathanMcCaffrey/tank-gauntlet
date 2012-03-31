using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
//using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

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

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Input.Initiailize();

            m_IsGameStarted = false;

            m_Effect = new BasicEffect(GraphicsDevice);
            m_Effect.EnableDefaultLighting();

            m_SpriteBatch = new SpriteBatch(GraphicsDevice);
            m_SplashScreen = Content.Load<Texture2D>("Screen/SplashScreen");

            File.ContentManager = Content;
            ScoreManager.SpriteFont = Content.Load<SpriteFont>("Font/ScoreMain");
            EmitterManager.Sprite = Content.Load<Texture2D>("Pixel");


            List<Data.BaseActor> tempList = Content.Load<List<Data.BaseActor>>("Level/1");

            for(int loop = 0; loop < tempList.Count; loop++)
            {
                 ActorMananger.List.Add(new TileActor(tempList[loop].FilePathToModel, tempList[loop].Position, tempList[loop].IsCollidable));
            }
           

         /*   ActorMananger.List.Add(new BallActor(new Vector2(100, 250), BallType.Yellow));
            ActorMananger.List.Add(new BallActor(new Vector2(200, 250), BallType.Green));
            ActorMananger.List.Add(new BallActor(new Vector2(300, 250), BallType.Blue));
            ActorMananger.List.Add(new BallActor(new Vector2(400, 250), BallType.Red));
            ActorMananger.List.Add(new BallActor(new Vector2(500, 250), BallType.Bomb));*/
            ActorMananger.List.Add(new PlayerActor("Sprite/Tank_Base", new Vector2(300, 300)));
            
            base.Initialize();
        }

        float time = 0;

        TileActor selectedTile;
        int tileType = 0;
        protected override void Update(GameTime a_GameTime)
        {
            if (m_IsGameStarted)
            {
                time += a_GameTime.ElapsedGameTime.Milliseconds / 1000.0f;
            }

            /*  if (time > 4 && m_IsGameStarted)
              {
                  ActorMananger.List.Add(new BallActor(new Vector2(100, 250), BallType.Yellow));
                  ActorMananger.List.Add(new BallActor( new Vector2(200, 250), BallType.Green));
                  ActorMananger.List.Add(new BallActor(new Vector2(300, 250), BallType.Blue));
                  ActorMananger.List.Add(new BallActor( new Vector2(400, 250), BallType.Red));
                  ActorMananger.List.Add(new BallActor( new Vector2(500, 250), BallType.Bomb));

                  time = 0;
              }*/

            Input.Update();

            if (m_IsGameStarted == false)
            {
                if (Input.Gesture.GestureType == GestureType.Tap)
                {
                    m_IsGameStarted = true;
                }

                if (Input.SingleKeyPressInput(Keys.Space))
                {
                    m_IsGameStarted = true;
                }
            }
            else
            {
                ActorMananger.Update(a_GameTime);
                ProjectileManager.Update(a_GameTime);
                EmitterManager.Update(a_GameTime);
                WeaponManager.Update(a_GameTime);
                CollisionManager.Update(a_GameTime);
                ScoreManager.Update(a_GameTime);

             /*   switch (tileType)
                {
                    case 0:
                        selectedTile = new TileActor("Sprite/Tile_CopperFloor", Input.MousePosition - Camera.Position, false);
                        break;
                    case 1:
                        selectedTile = new TileActor("Sprite/Tile_Copper", Input.MousePosition - Camera.Position, true);
                        break;
                    case 2:
                        selectedTile = new TileActor("Sprite/Tile_CopperWall", Input.MousePosition - Camera.Position, true);
                        break;
                    case 3:
                        selectedTile = new TileActor("Sprite/Tile_MetalFloor", Input.MousePosition - Camera.Position, false);
                        break;
                    case 4:
                        selectedTile = new TileActor("Sprite/Tile_Metal", Input.MousePosition - Camera.Position, true);
                        break;
                    case 5:
                        selectedTile = new TileActor("Sprite/Tile_MetalWall", Input.MousePosition - Camera.Position, true);
                        break;
                }

                   if (Input.MouseLeftDrag)
                   {
                       ActorMananger.SafeAdd(selectedTile.Clone());
                   }
                if (Input.MouseWheel != 0)
                {
                    tileType += (Input.MouseWheel > 0) ? 1 : -1;
                }
                if (tileType > 6)
                {
                    tileType = 0;
                }


                if (Input.SingleKeyPressInput(Keys.F2))
                {
                    List<BaseActor> List = ActorMananger.List;

                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    XmlWriter xmlWriter = XmlWriter.Create("Test.xml", xmlWriterSettings);
                    IntermediateSerializer.Serialize(xmlWriter, List, null);
                    xmlWriter.Close();
                }*/
            }

         /*   float speed = 5;

            if (Input.MulitKeyPressInput(Keys.W))
            {
                Camera.Position += new Vector2(0, -speed);
            }
            if (Input.MulitKeyPressInput(Keys.S))
            {
                Camera.Position += new Vector2(0, speed);
            }
            if (Input.MulitKeyPressInput(Keys.A))
            {
                Camera.Position += new Vector2(-speed, 0);
            }
            if (Input.MulitKeyPressInput(Keys.D))
            {
                Camera.Position += new Vector2(speed, 0);
            }

            if (Input.MouseLeftPressed)
            {

            }*/

            base.Update(a_GameTime);
        }

        protected override void Draw(GameTime a_GameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            m_SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Camera.Matrix);

            if (m_IsGameStarted != true)
            {
                m_SpriteBatch.Draw(m_SplashScreen, Vector2.Zero, Color.White);
            }
            else
            {
                ActorMananger.Draw(m_SpriteBatch);
                ProjectileManager.Draw(m_SpriteBatch);
                EmitterManager.Draw(m_SpriteBatch);
                WeaponManager.Draw(m_SpriteBatch);
                ScoreManager.Draw(m_SpriteBatch);

               /* if (selectedTile != null)
                {
                    m_SpriteBatch.Draw(Content.Load<Texture2D>(selectedTile.FilePathToModel), Input.MousePosition - Camera.Position, selectedTile.SourceRectangle, Color.White, selectedTile.Rotation, selectedTile.Origin, selectedTile.Scale, selectedTile.SpriteEffects, selectedTile.LayerDepth);
                }*/
            }

            m_SpriteBatch.End();

            base.Draw(a_GameTime);
        }
    }
}
