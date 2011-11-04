using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class WallMetal : Tile
    {
        public WallMetal()
        {
            IsCollidable = false;
            FilePathToGraphic = "Metal";
        }

        public override void Create(Vector2 aCoordinate)
        {
            Tile newTile = new Tile(aCoordinate);
            newTile.FilePathToGraphic = "Metal";
            newTile.IsCollidable = true;
        }
    }
}
