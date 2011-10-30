using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class Tile : AbstractEntity
    {
        #region Construction
        public Tile()
        {
            Initialize();
        }

        public Tile(Vector2 aCoordinate)
        {
            FilePathToGraphic = theTileManager.FilePathToGraphic;
            IsCollidable = theTileManager.IsCollidable;

            mWorldPosition = aCoordinate;

            theTileManager.Add(this);

            Initialize();
        }

        static public void CreateTile(Vector2 aCoordinate)
        {
            new Tile(aCoordinate);    
        }

        private void Initialize()
        {
            mManager = theTileManager;
            mFilePathToGraphic = theTileManager.FilePathToGraphic;
            mName = "tile";

            CollideWithTile();
        }
        #endregion

        #region Methods
        public override void Update()
        {
            base.Update();

           // DeleteTile();
        }

        public override void Draw()
        {
            if (IsOnScreen)
            {
                theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
            }
        }

        private void CollideWithTile()
        {
            for (int loop = 0; loop < theTileManager.List.Count; loop++)
            {
                if (theTileManager.List[loop] == this) continue;

                if (ScreenPosition == theTileManager.List[loop].ScreenPosition)
                {
                    theTileManager.Remove(theTileManager.List[loop]);
                }
            }
        }

        private void DeleteTile()
        {
            if (theInputManager.mouseLeftDrag)
            {
                if (CollisionRectangle.X < theInputManager.mousePosition.X &&
                    CollisionRectangle.X + Graphic.Width > theInputManager.mousePosition.X &&
                    CollisionRectangle.Y < theInputManager.mousePosition.Y &&
                    CollisionRectangle.Y + Graphic.Height > theInputManager.mousePosition.Y)
                {
                    theTileManager.Remove(this);
                }
            }
        }

        public bool Collision(Rectangle aCollisionRectangle)
        {
            if (CollisionRectangle.Intersects(aCollisionRectangle))
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}