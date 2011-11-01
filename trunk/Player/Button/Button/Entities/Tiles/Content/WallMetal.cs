using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class WallMetal : Tile
    {
        public static void Create(Vector2 aCoordinate)
        {
            Tile newTile = new Tile(aCoordinate);
            newTile.FilePathToGraphic = "Metal";
            newTile.IsCollidable = true;
        }
    }
}
