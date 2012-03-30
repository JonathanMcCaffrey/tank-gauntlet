using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Button
{
    public class FloorMetal : Tile
    {
        public FloorMetal()
        {
            IsCollidable = false;
            FilePathToGraphic = "MetalFloor";
        }

        public override void Create(Vector2 aCoordinate)
        {
            Tile newTile = new Tile(aCoordinate);
            newTile.FilePathToGraphic = "MetalFloor";
            newTile.IsCollidable = false;
        }
    }
}
