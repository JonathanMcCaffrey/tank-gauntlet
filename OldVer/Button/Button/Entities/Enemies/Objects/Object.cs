using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class Object : AbstractEntity
    {
        /* This is only public for serialization. Do Not Use This Constructor. Only use the Create Button method. */
        /* A Object of button Should Never Exist outside of the button manager. */
        public Object()
        {
        }

        private Object(Vector2 aCoordinate)
        {
            FilePathToGraphic = theObjectManager.FilePathToGraphic;
            //  Function = aFunction;  // Added functionality from Object manager!
            IsCollidable = theObjectManager.IsCollidable;

            mWorldPosition = aCoordinate;

            theObjectManager.Add(this);

            CollideWithObject();
        }

        static public void CreateObject(Vector2 aCoordinate)
        {
            new Object(aCoordinate);
        }

        public override void Update()
        {
            base.Update();
           // DeleteObject();
        }

        public override void Draw()
        {
            theFileManager.SpriteBatch.Draw(Graphic, ScreenPosition, SourceRectangle, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }

        private void CollideWithObject()
        {
            for (int loop = 0; loop < theObjectManager.List.Count; loop++)
            {
                if (theObjectManager.List[loop] == this) continue;

                if (ScreenPosition == theObjectManager.List[loop].ScreenPosition)
                {
                    theObjectManager.Remove(theObjectManager.List[loop]);
                }
            }
        }

        private void DeleteObject()
        {
            if (theInputManager.mouseLeftDrag)
            {
                if (CollisionRectangle.X < theInputManager.mousePosition.X &&
                    CollisionRectangle.X + Graphic.Width > theInputManager.mousePosition.X &&
                    CollisionRectangle.Y < theInputManager.mousePosition.Y &&
                    CollisionRectangle.Y + Graphic.Height > theInputManager.mousePosition.Y)
                {
                    theObjectManager.Remove(this);
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
    }
}