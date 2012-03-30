using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class Sprite
    {
        private string mFilePathToSheet = "IconOne";
        public Texture2D SpriteSheet
        {
            get { return FileManager.GetManager().LoadTexture2D(mFilePathToSheet); }
        }


        private Sprite(string aFilePathToSheet)
        {
            mFilePathToSheet = aFilePathToSheet;
        }
    }
}
