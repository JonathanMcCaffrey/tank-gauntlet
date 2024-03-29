﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace Button
{
    public class EnemyManager : AbstractEntityManager
    {
        #region Singletons
        protected FileManager theFileManager = FileManager.Get();
        protected InputManager theInputManager = InputManager.Get();
        protected UtilityManager theUtilityManager = UtilityManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        protected ButtonManager theButtonManager = ButtonManager.Get();
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected ScreenManager theScreenManager = ScreenManager.Get();
        #endregion

        #region Data
        private List<Enemy> mList = new List<Enemy>();
        public List<Enemy> List
        {
            get { return mList; }
        }

        private string mFilePathToGraphic = "Wooden";      
        public Texture2D Graphic
        {
            get { return theFileManager.LoadTexture2D(mFilePathToGraphic); }
        }
        public string FilePathToGraphic
        {
            get { return mFilePathToGraphic; }
            set { mFilePathToGraphic = value; }
        }

        private bool isCollidable = true;
        public bool IsCollidable
        {
            get { return isCollidable; }
            set { isCollidable = value; }
        }

        SaveMap saveFile = new SaveMap();
        LoadMap loadFile = new LoadMap();

        #endregion

        #region Construction
        private EnemyManager(Game aGame)
            : base(aGame) { }
        static EnemyManager Instance;
        static public EnemyManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new EnemyManager(aGame);

            }

            return Instance;
        }
        static public EnemyManager Get()
        {
            return Instance;
        }
        #endregion

        #region Methods
        public override void Update(GameTime aGameTime)
        {
        /*    if (theInputManager.SingleKeyPressInput(Keys.A) && !loadFile.IsAccessible) // Start save file
            {
                saveFile.On();
            }
            if (saveFile.Done)  // Finish save file
            {
                Save(saveFile.FileName);
                saveFile.Off();
            }

            if (theInputManager.SingleKeyPressInput(Keys.D) && !saveFile.IsAccessible)
            {
                loadFile.On();
            }
            if (loadFile.Done)  // Finish save file
            {
                Load(loadFile.FileName);
                loadFile.Off();
            }

            if (theInputManager.SingleKeyPressInput(Keys.S) && !saveFile.IsAccessible && !loadFile.IsAccessible)
            {
                Clear();
            }
            */
            for (int i = 0; i < mList.Count; i++)
            {
                List[i].Update();
            }
        }

        public override void Draw(GameTime aGameTime)
        {
            for (int loop = 0; loop < List.Count; loop++)
            {
                List[loop].Draw();
            }
        }

        public void Add(Enemy aEntity)
        {
            List.Add(aEntity);
        }

        public void Remove(Enemy aEntity)
        {
            List.Remove(aEntity);
        }

        public void Clear()
        {
            List.Clear();
        }

        public void Save(string aFilePath)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(aFilePath + ".xml"))
            {
                xmlWriter.WriteStartElement("Data");
                for (int loop = 0; loop < List.Count; loop++)
                {
                    xmlWriter.WriteStartElement("Button");
                  //  xmlWriter.WriteElementString("Border", List[loop].FilePathToBorder);
                    xmlWriter.WriteElementString("Graphic", List[loop].FilePathToGraphic);
                    //       xmlWriter.WriteElementString("Function", List[0].Function.ToString());
                    xmlWriter.WriteElementString("Position", List[loop].WorldPosition.ToString());
                    xmlWriter.WriteElementString("IsCollidable", List[loop].IsCollidable.ToString());
                    xmlWriter.WriteElementString("Color", List[loop].Color.ToString());
                    xmlWriter.WriteElementString("Rotation", List[loop].Rotation.ToString());
                    xmlWriter.WriteElementString("Scale", List[loop].Scale.ToString());
                    xmlWriter.WriteElementString("SpriteEffects", List[loop].SpriteEffects.ToString());
                    xmlWriter.WriteElementString("LayerDepth", List[loop].LayerDepth.ToString());
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

                xmlWriter.Close();
            }
        }

        public void Load(string aFilePath)
        {
            int ButtonsToLoad = 0;

            using (XmlReader xmlReader = XmlReader.Create(aFilePath + ".xml"))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            ButtonsToLoad++;
                            break;
                        case XmlNodeType.Text:
                            ButtonsToLoad--;
                            break;
                    }
                }

                ButtonsToLoad--;
                xmlReader.Close();
            }

            using (XmlReader xmlReader = XmlReader.Create(aFilePath + ".xml"))
            {
                xmlReader.MoveToContent();

                xmlReader.ReadStartElement("Data");

                string rawData;
                string[] organizedData;

                string[] xData;
                string[] yData;
                string[] zData;

                for (int loop = 0; loop < ButtonsToLoad; loop++)
                {
                    xmlReader.ReadStartElement("Button");

                    Enemy temporaryEnemy = new Enemy();

              //      temporaryEnemy.FilePathToBorder = xmlReader.ReadElementContentAsString("Border", "");
                    temporaryEnemy.FilePathToGraphic = xmlReader.ReadElementContentAsString("Graphic", "");

                    rawData = xmlReader.ReadElementContentAsString("Position", "");
                    organizedData = rawData.Split(' ');
                    xData = organizedData[0].Split(':');
                    yData = organizedData[1].Split(':');
                    yData[1] = yData[1].TrimEnd();  // Glitch: This is not working. C# has failed me : (
                    yData[1] = yData[1].Replace('}', ' ');  // This is another method of doing it. Rather not use it tho for the sake of consistency.
                    temporaryEnemy.WorldPosition = new Vector2((float)Convert.ToDouble(xData[1]), (float)Convert.ToDouble(yData[1]));

                    rawData = xmlReader.ReadElementContentAsString("IsCollidable", "");
                    if (rawData == "True")
                    {
                        temporaryEnemy.IsCollidable = true;
                    }
                    else
                    {
                        temporaryEnemy.IsCollidable = false;
                    }

                    rawData = xmlReader.ReadElementContentAsString("Color", "");
                    organizedData = rawData.Split(' ');
                    xData = organizedData[0].Split(':');
                    yData = organizedData[1].Split(':');
                    zData = organizedData[2].Split(':');
                    zData[1] = zData[1].TrimEnd();  // See. It works here. What the heck?
                    temporaryEnemy.Color = new Color((float)Convert.ToDouble(xData[1]), (float)Convert.ToDouble(yData[1]), (float)Convert.ToDouble(zData[1]));

                    temporaryEnemy.Rotation = xmlReader.ReadElementContentAsFloat("Rotation", "");

                    temporaryEnemy.Scale = xmlReader.ReadElementContentAsFloat("Scale", "");

                    switch (xmlReader.ReadElementContentAsString("SpriteEffects", ""))
                    {
                        case "FlipVertically":
                            temporaryEnemy.SpriteEffects = SpriteEffects.FlipVertically;
                            break;
                        case "FlipHorizontally":
                            temporaryEnemy.SpriteEffects = SpriteEffects.FlipHorizontally;
                            break;
                        case "None":
                            temporaryEnemy.SpriteEffects = SpriteEffects.None;
                            break;
                        default: break;
                    }

                    temporaryEnemy.Rotation = xmlReader.ReadElementContentAsFloat("LayerDepth", "");

                    xmlReader.ReadEndElement();

                    Add(temporaryEnemy);
                }
            }
        }

        public string Statistic()
        {
            int temporaryStatistic = mList.Count;

            return "Total: " + temporaryStatistic.ToString();
        }

        #endregion
    }
}