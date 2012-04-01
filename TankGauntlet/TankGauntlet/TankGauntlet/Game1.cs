using System;
using System.Collections.Generic;
using System.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

#if WINDOWS
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System.Windows.Forms;
#endif

namespace TankGauntlet
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager m_GraphicsDeviceManager;
        SpriteBatch m_SpriteBatch;

        Texture2D m_SplashScreen;
        BasicEffect m_Effect;

        bool m_IsGameStarted;

        public static int Level = 1;

        public static Game1 Game;
        public Game1()
        {
            Game = this;

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
            Audio.Song = Content.Load<Song>("Audio/Song");

#if !WINDOWS
            List<Data.BaseActor> tempList = Content.Load<List<Data.BaseActor>>("Level/1");

            Vector2 playerPosition = Vector2.Zero;

            for (int loop = 0; loop < tempList.Count; loop++)
            {
                if (tempList[loop] is Data.TileActor)
                {
                    ActorManager.List.Add(new TileActor(tempList[loop].FilePathToTexture, tempList[loop].Position, tempList[loop].IsCollidable, tempList[loop].IsDestructable));
                }

                if (tempList[loop] is Data.BallActor)
                {
                    Data.BallActor temp = (Data.BallActor)tempList[loop];
                    ActorManager.List.Add(new BallActor(temp.Position, (int)temp.BallType));
                }

                if (tempList[loop] is Data.AreaActor)
                {
                    Data.AreaActor temp = (Data.AreaActor)tempList[loop];
                    ActorManager.List.Add(new AreaActor(temp.Position, (int)temp.AreaType));

                    if (temp.AreaType == Data.AreaType.Start)
                    {
                        playerPosition = temp.Position;
                    }
                }
            }
            PlayerActor player = new PlayerActor("Sprite/Tank_Base", playerPosition);
            ActorManager.List.Add(player);
            File.Player = player;
#endif


            base.Initialize();
        }

        public static void NextLevel()
        {
            try
            {
                List<Data.BaseActor> tempList = Game.Content.Load<List<Data.BaseActor>>("Level/" + (++Game1.Level).ToString());

                ActorManager.List.Clear();
                CollisionManager.ActorList.Clear();
                CollisionManager.ProjectileList.Clear();

                Vector2 playerPosition = Vector2.Zero;



                for (int loop = 0; loop < tempList.Count; loop++)
                {
                    if (tempList[loop] is Data.TileActor)
                    {
                        ActorManager.List.Add(new TileActor(tempList[loop].FilePathToTexture, tempList[loop].Position, tempList[loop].IsCollidable, tempList[loop].IsDestructable));
                    }

                    if (tempList[loop] is Data.BallActor)
                    {
                        Data.BallActor temp = (Data.BallActor)tempList[loop];
                        ActorManager.List.Add(new BallActor(temp.Position, (int)temp.BallType));
                    }

                    if (tempList[loop] is Data.AreaActor)
                    {
                        Data.AreaActor temp = (Data.AreaActor)tempList[loop];
                        ActorManager.List.Add(new AreaActor(temp.Position, (int)temp.AreaType));

                        if (temp.AreaType == Data.AreaType.Start)
                        {
                            playerPosition = temp.Position;
                            Camera.Position = temp.Position;
                        }
                    }
                }

                ActorManager.List.Add(File.Player);
                File.Player.Position = playerPosition;
                File.Player.OldPosition = playerPosition;
            }
            catch
            {
                Game1.Game.m_IsGameStarted = false;
            }
        }

#if WINDOWS
        BaseActor selectedTile;
#endif

        protected override void Update(GameTime a_GameTime)
        {
            Input.Update();

            if (m_IsGameStarted == false)
            {
                if (Input.Gesture.GestureType == GestureType.Tap)
                {
                    MediaPlayer.Play(Audio.Song);
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Volume = 0.2f;

                    m_IsGameStarted = true;
                }

                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Space))
                {
                    m_IsGameStarted = true;
                }
            }
            else
            {
                ActorManager.Update(a_GameTime);
                ProjectileManager.Update(a_GameTime);
                EmitterManager.Update(a_GameTime);
                WeaponManager.Update(a_GameTime);
                CollisionManager.Update(a_GameTime);
                ScoreManager.Update(a_GameTime);

#if WINDOWS
                if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Q))
                {
                    selectedTile = new TileActor("Sprite/Tile_CopperFloor", Input.MousePosition - Camera.Position, false, false);
                }
                if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.W))
                {
                    selectedTile = new TileActor("Sprite/Tile_Copper", Input.MousePosition - Camera.Position, true, false);
                }

                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.E))
                {
                    selectedTile = new TileActor("Sprite/Tile_CopperWall", Input.MousePosition - Camera.Position, true, false);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.A))
                {
                    selectedTile = new TileActor("Sprite/Tile_MetalFloor", Input.MousePosition - Camera.Position, false, false);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.S))
                {
                    selectedTile = new TileActor("Sprite/Tile_Metal", Input.MousePosition - Camera.Position, true, false);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.D))
                {
                    selectedTile = new TileActor("Sprite/Tile_MetalWall", Input.MousePosition - Camera.Position, true, false);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.R))
                {
                    selectedTile = new TileActor("Sprite/Tile_RockWall", Input.MousePosition - Camera.Position, true, true);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.T))
                {
                    selectedTile = new AreaActor(Input.MousePosition - Camera.Position, (int)AreaType.Start);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.G))
                {
                    selectedTile = new AreaActor(Input.MousePosition - Camera.Position, (int)AreaType.Finish);
                }
                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.F))
                {
                    selectedTile = new BallActor(Input.MousePosition - Camera.Position, (int)BallType.Bomb);
                }

                if (selectedTile != null)
                {
                    selectedTile.Position = Input.MousePosition - Camera.Position;
                }

                if (selectedTile is TileActor && Input.MouseLeftDrag)
                {
                    ActorManager.SafeAdd(((TileActor)selectedTile).Clone());
                }


                if (selectedTile is BallActor && Input.MouseLeftPressed)
                {
                    ActorManager.SafeAdd(((BallActor)selectedTile).Clone());
                }

                if (selectedTile is AreaActor && Input.MouseLeftPressed)
                {
                    ActorManager.SafeAdd(((AreaActor)selectedTile).Clone());
                }


                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.F2))
                {
                    SaveFileDialog save = new SaveFileDialog();
                    save.Filter = "ASCII file (*.xml)|*.xml";
                    save.ShowDialog();

                    string path = save.FileName;
                    if (path == string.Empty) { return; }

                    List<Data.BaseActor> List = new List<Data.BaseActor>();
                    for (int loop = 0; loop < ActorManager.List.Count; loop++)
                    {
                        if (ActorManager.List[loop] is TileActor)
                        {
                            TileActor data = (TileActor)ActorManager.List[loop];
                            Data.TileActor temp = new Data.TileActor(data.FilePathToTexture, data.Position, data.IsCollidable, data.IsDestructable);
                            List.Add(temp);
                        }

                        if (ActorManager.List[loop] is BallActor)
                        {
                            BallActor data = (BallActor)ActorManager.List[loop];
                            Data.BallActor temp = new Data.BallActor(data.Position, (int)data.BallType);
                            List.Add(temp);
                        }

                        if (ActorManager.List[loop] is AreaActor)
                        {
                            AreaActor data = (AreaActor)ActorManager.List[loop];
                            Data.AreaActor temp = new Data.AreaActor(data.Position, (int)data.AreaType);
                            List.Add(temp);
                        }
                    }

                    XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                    xmlWriterSettings.Indent = true;

                    XmlWriter xmlWriter = XmlWriter.Create(path, xmlWriterSettings);
                    IntermediateSerializer.Serialize(xmlWriter, List, null);
                    xmlWriter.Close();
                }

                if (Input.SingleKeyPressInput(Microsoft.Xna.Framework.Input.Keys.F3))
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "ASCII file (*.xml)|*.xml";
                    open.ShowDialog();

                    string path = open.FileName;
                    if (path == string.Empty) { return; }

                    XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();

                    XmlReader xmlReader = XmlReader.Create(path, xmlReaderSettings);
                    List<Data.BaseActor> tempList = IntermediateSerializer.Deserialize<List<Data.BaseActor>>(xmlReader, null);
                    xmlReader.Close();

                    for (int loop = 0; loop < tempList.Count; loop++)
                    {
                        if (tempList[loop] is Data.TileActor)
                        {
                            ActorManager.List.Add(new TileActor(tempList[loop].FilePathToTexture, tempList[loop].Position, tempList[loop].IsCollidable, tempList[loop].IsDestructable));
                        }

                        if (tempList[loop] is Data.BallActor)
                        {
                            Data.BallActor temp = (Data.BallActor)tempList[loop];
                            ActorManager.List.Add(new BallActor(temp.Position, (int)temp.BallType));
                        }

                        if (tempList[loop] is Data.AreaActor)
                        {
                            Data.AreaActor temp = (Data.AreaActor)tempList[loop];
                            ActorManager.List.Add(new AreaActor(temp.Position, (int)temp.AreaType));
                        }
                    }
                }
#endif
            }

#if WINDOWS
            float speed = 5;

            if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Down))
            {
                Camera.Position += new Vector2(0, -speed);
            }
            if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Up))
            {
                Camera.Position += new Vector2(0, speed);
            }
            if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Right))
            {
                Camera.Position += new Vector2(-speed, 0);
            }
            if (Input.MulitKeyPressInput(Microsoft.Xna.Framework.Input.Keys.Left))
            {
                Camera.Position += new Vector2(speed, 0);
            }
#endif

            base.Update(a_GameTime);
        }

        protected override void Draw(GameTime a_GameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            m_SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, Camera.Matrix);

            if (m_IsGameStarted != true)
            {
                m_SpriteBatch.Draw(m_SplashScreen, Vector2.Zero - Camera.Position, Color.White);
            }
            else
            {
                ActorManager.Draw(m_SpriteBatch);
                ProjectileManager.Draw(m_SpriteBatch);
                EmitterManager.Draw(m_SpriteBatch);
                WeaponManager.Draw(m_SpriteBatch);
                ScoreManager.Draw(m_SpriteBatch);
#if WINDOWS
                if (selectedTile != null)
                {
                    m_SpriteBatch.Draw(Content.Load<Texture2D>(selectedTile.FilePathToTexture), Input.MousePosition - Camera.Position, selectedTile.SourceRectangle, Color.White, selectedTile.Rotation, selectedTile.Origin, selectedTile.Scale, selectedTile.SpriteEffects, selectedTile.LayerDepth);
                }
#endif
            }

            m_SpriteBatch.End();

            base.Draw(a_GameTime);
        }
    }
}
