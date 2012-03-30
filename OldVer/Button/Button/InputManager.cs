using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Button
{
    public class InputManager : Microsoft.Xna.Framework.GameComponent
    {
        #region Fields
        private KeyboardState mCurrentKeyboardState;
        private KeyboardState mLastKeyboardState;
        private MouseState mCurrentMouseState;
        private MouseState mLastMouseState;
        private GamePadState mCurrentGamePadState = GamePad.GetState(PlayerIndex.One);
        private GamePadState mLastGamePadState = GamePad.GetState(PlayerIndex.One);
       

        #endregion

        #region Mouse
        public Vector2 mouseTranslation
        {
            get { return new Vector2(mCurrentMouseState.X - mLastMouseState.X, mCurrentMouseState.Y - mLastMouseState.Y); }
        }

        public Vector2 mousePosition
        {
            get { return new Vector2(mCurrentMouseState.X, mCurrentMouseState.Y); }
        }

        public bool mouseLeftPressed
        {
            get { return (mCurrentMouseState.LeftButton == ButtonState.Pressed && mLastMouseState.LeftButton == ButtonState.Released); }
        }

        public bool mouseRightReleased
        {
            get { return (mCurrentMouseState.RightButton == ButtonState.Released && mLastMouseState.RightButton == ButtonState.Pressed); }
        }

        public bool mouseRightDrag
        {
            get { return (mCurrentMouseState.RightButton == ButtonState.Pressed && mLastMouseState.RightButton == ButtonState.Pressed); }
        }

        public bool mouseRightPressed
        {
            get { return (mCurrentMouseState.RightButton == ButtonState.Pressed && mLastMouseState.RightButton == ButtonState.Released); }
        }

        public bool mouseLeftReleased
        {
            get { return (mCurrentMouseState.LeftButton == ButtonState.Released && mLastMouseState.LeftButton == ButtonState.Pressed); }
        }

        public bool mouseLeftDrag
        {
            get { return (mCurrentMouseState.LeftButton == ButtonState.Pressed && mLastMouseState.LeftButton == ButtonState.Pressed); }
        }


        public bool mouseWheelDrag
        {
            get { return (mCurrentMouseState.MiddleButton == ButtonState.Pressed); }
        }

        public float mouseWheel
        {
            get { return mCurrentMouseState.ScrollWheelValue - mLastMouseState.ScrollWheelValue; }
        }
        #endregion

        #region Thumbsticks
        public Vector2 LeftThumbStick
        {
            get { return new Vector2(mCurrentGamePadState.ThumbSticks.Left.X, mCurrentGamePadState.ThumbSticks.Left.Y); }
        }

        public Vector2 RightThumbStick
        {
            get { return new Vector2(mCurrentGamePadState.ThumbSticks.Right.X, mCurrentGamePadState.ThumbSticks.Right.Y); }
        }
        #endregion

        #region InputControl
        public bool SingleKeyPressInput(Keys aKey)
        {
            return mCurrentKeyboardState.IsKeyDown(aKey) && mLastKeyboardState.IsKeyUp(aKey);
        }
        public bool MulitKeyPressInput(Keys aKey)
        {
            return mCurrentKeyboardState.IsKeyDown(aKey);
        }
        public bool KeyHeldDown(Keys aKey)
        {
            return mCurrentKeyboardState.IsKeyDown(aKey) && mLastKeyboardState.IsKeyDown(aKey);
        }
        public bool KeyIsUp(Keys aKey)
        {
            return mCurrentKeyboardState.IsKeyUp(aKey);
        }
        
        public bool SingleButtonPressInput(Buttons aButton)
        {
            return mCurrentGamePadState.IsButtonDown(aButton) && mLastGamePadState.IsButtonUp(aButton);
        }
        public bool MulitButtonPressInput(Buttons aButton)
        {
            return mCurrentGamePadState.IsButtonDown(aButton);
        }
        public bool ButtonHeldDown(Buttons aButton)
        {
            return mCurrentGamePadState.IsButtonDown(aButton) && mLastGamePadState.IsButtonDown(aButton);
        }
        public bool ButtonIsUp(Buttons aButton)
        {
            return mCurrentGamePadState.IsButtonUp(aButton);
        }
        #endregion

        #region Construction
        private InputManager(Game aGame) : base(aGame) { }
        static InputManager Instance;
        static public InputManager Get(Game aGame)
        {
            if (null == Instance)
            {
                Instance = new InputManager(aGame);
            }

            return Instance;
        }
        static public InputManager Get()
        {
            return Instance;
        }
        #endregion

        #region UpdateInput
        public override void Update(GameTime gameTime)
        {
            mLastKeyboardState = mCurrentKeyboardState;
            mCurrentKeyboardState = Keyboard.GetState();

            mLastGamePadState = mCurrentGamePadState;
            mCurrentGamePadState = GamePad.GetState(PlayerIndex.One);

            mLastMouseState = mCurrentMouseState;
            mCurrentMouseState = Mouse.GetState();
        }

        #endregion
    }
}