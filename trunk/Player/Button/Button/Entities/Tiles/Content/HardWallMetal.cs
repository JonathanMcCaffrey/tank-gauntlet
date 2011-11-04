using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class HardWallMetal : Tile
    {
        public HardWallMetal()
        {
            IsCollidable = false;
            FilePathToGraphic = "MetalWall";
        }

        public override void Create(Vector2 aCoordinate)
        {
            Tile newTile = new Tile(aCoordinate);
            newTile.FilePathToGraphic = "MetalWall";
            newTile.IsCollidable = true;
        }
    }
}
