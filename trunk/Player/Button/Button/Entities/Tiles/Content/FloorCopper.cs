using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class FloorCopper : Tile
    {
        public static void Create(Vector2 aCoordinate)
        {
            Tile newTile = new Tile(aCoordinate);
            newTile.FilePathToGraphic = "WoodenFloor";
            newTile.IsCollidable = false;
        }
    }
}
