using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Button
{
    public class UtilityManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Construction
        private UtilityManager(Game aGame) : base(aGame) { }
        static UtilityManager Instance;
        static public UtilityManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new UtilityManager(aGame);
            }

            return Instance;
        }
        static public UtilityManager Get()
        {
            return Instance;
        }
        #endregion

        #region Methods
        public Rectangle GetRectangle(Texture2D aTexture2D)
        {
            Rectangle temporaryRectangle = new Rectangle(0, 0, (int)aTexture2D.Width, (int)aTexture2D.Height);

            return temporaryRectangle;
        }

        public Rectangle GetRectangle(GraphicsDevice aGraphicsDevice)
        {
            Rectangle temporaryRectangle = new Rectangle(0, 0, (int)aGraphicsDevice.Viewport.Width, (int)aGraphicsDevice.Viewport.Height);

            return temporaryRectangle;
        }

        public float GetMagnitude()
        {

            return 0;
        }

        public float Square(float aFloat)
        {
            float tempFloat = aFloat;

            tempFloat = tempFloat * tempFloat;

            return tempFloat;
        }

        public float SquareRoot(float aFloat)
        {
            float tempFloat = aFloat;

            if (tempFloat < 0) tempFloat *= -1;

            if (tempFloat > 0)
            {

            }

            tempFloat = tempFloat * tempFloat;

            return tempFloat;
        }

        public Rectangle SkimRectangle(Rectangle aRectangle, int aScale)
        {
            Rectangle temporaryRectangle = aRectangle;
            temporaryRectangle.X += aScale;
            temporaryRectangle.Y += aScale;
            temporaryRectangle.Width -= aScale;
            temporaryRectangle.Height -= aScale;

            return temporaryRectangle;
        }

        public Vector2 GetOrigin(Texture2D aTexture2D)
        {
            Vector2 temporaryOrigin = new Vector2(aTexture2D.Width / 2, aTexture2D.Height / 2);

            return temporaryOrigin;
        }

        public Vector2 GetOrigin(Rectangle aRectangle)
        {
            Vector2 temporaryOrigin = new Vector2(aRectangle.Width / 2, aRectangle.Height / 2);

            return temporaryOrigin;
        }

        public Vector2 GetViewport(GraphicsDevice aGraphicsDevice)
        {
            Vector2 temporaryViewport = new Vector2(aGraphicsDevice.Viewport.Width, aGraphicsDevice.Viewport.Height);

            return temporaryViewport;
        }

        public Vector2 GetScreenmCenter(GraphicsDevice aGraphicsDevice)
        {
            Vector2 temporaryScreenmCenter = new Vector2(aGraphicsDevice.Viewport.Width / 2, aGraphicsDevice.Viewport.Height / 2);

            return temporaryScreenmCenter;
        }

        public Vector3 GetRotatedVector(Vector3 aVector)
        {
            Vector3 temporaryVector = new Vector3(aVector.Z, aVector.Y, aVector.X);

            return temporaryVector;
        }

        public Vector3 GetFinalTranslation(Vector3 aTranslation, Vector3 aLoop, Vector3 aTile, Vector3 aDimension, bool ismCentered)
        {
            Vector3 temporaryVector = Vector3.Zero;

            temporaryVector = new Vector3(aTranslation.X + aLoop.X * aDimension.X, aTranslation.Y + aLoop.Y * aDimension.Y, aTranslation.Z + aLoop.Z * aDimension.Z);

            if (ismCentered)
            {
                temporaryVector = new Vector3((temporaryVector.X - (aTile.X * aDimension.X) / 2), 0, (temporaryVector.Z - (aTile.Z * aDimension.Z) / 2));
            }

            return temporaryVector;
        }

        public Vector3 GetTranslation(Vector3 aTranslation, Vector3 aTile, Vector3 aDimension, bool ismCentered)
        {
            Vector3 temporaryVector = aTranslation;

            if (!ismCentered)
            {
                return temporaryVector;
            }
            else
            {
                return temporaryVector = new Vector3((aTranslation.X - (aTile.X * aDimension.X) / 2), 0, (aTranslation.Z - (aTile.Z * aDimension.Z) / 2));
            }
        }

        public Vector3 GetFinalTranslation(Vector3 aTranslation, Vector3 aLoop, Vector3 aDimensions)
        {
            Vector3 temporaryVector = new Vector3((aTranslation.X + (aLoop.X * aDimensions.X)), (aTranslation.Y + (aLoop.Y * aDimensions.Y)), (aTranslation.Z + (aLoop.Z * aDimensions.Z)));

            return temporaryVector;
        }

        public Rectangle GetCollisionBox(Vector3 aLowest, Vector3 aHeighest, Vector3 aTranslation, Vector3 aTile)
        {
            Rectangle temporaryRectangle = new Rectangle(
                                                        (int)aLowest.X + (int)aTranslation.X,
                                                        (int)aLowest.Z + (int)aTranslation.Z,
                                                        ((int)aHeighest.X - (int)aLowest.X) * (int)aTile.X,
                                                        ((int)aHeighest.Z - (int)aLowest.Z) * (int)aTile.Z);

            return temporaryRectangle;
        }

        public BoundingBox GetBoundingBox(Vector3 aLowest, Vector3 aHighest, Vector3 aTranslation, Vector3 aTile)
        {
            BoundingBox temporaryBox = new BoundingBox(aLowest * aTile + aTranslation, aHighest * aTile + aTranslation);

            return temporaryBox;
        }

        public BoundingSphere GetBoundingSphere(Vector3 aLowest, Vector3 aHighest, Vector3 aTranslation, Vector3 aTile)
        {
            Vector3 temporaryRadius = new Vector3((aHighest.X - aLowest.X) / 2, (aHighest.Y - aLowest.Y) / 2, (aHighest.Z - aLowest.Z) / 2) * aTile;
            BoundingSphere temporarySphere = new BoundingSphere(aTranslation, (temporaryRadius.X + temporaryRadius.Y + temporaryRadius.Z) / 3);

            return temporarySphere;
        }

        public float GetFloat(Color aColor)
        {
            return ((aColor.R + aColor.B + aColor.G) / (3.0f * 255.0f)) * (aColor.A / 255.0f);
        }

        #endregion
    }
}