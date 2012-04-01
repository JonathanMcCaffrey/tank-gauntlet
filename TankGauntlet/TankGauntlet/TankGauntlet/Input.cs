using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;


namespace TankGauntlet
{
    public static class Input
    {
#if !Windows
        private static KeyboardState m_CurrentKeyboardState;
        private static KeyboardState m_LastKeyboardState;

        private static MouseState m_CurrentMouseState;
        private static MouseState m_LastMouseState;
#endif

        public static TouchCollection CurrentTouchCollection = new TouchCollection();
        public static TouchCollection OldTouchCollection = new TouchCollection();

        public static void Initiailize()
        {
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.FreeDrag | GestureType.Hold;
        }

#if !Windows
        public static Vector2 MouseTranslation
        {
            get { return new Vector2(m_CurrentMouseState.X - m_LastMouseState.X, m_CurrentMouseState.Y - m_LastMouseState.Y); }
        }

        public static Vector2 MousePosition
        {
            get { return new Vector2(m_CurrentMouseState.X, m_CurrentMouseState.Y); }
        }

        public static bool MouseLeftPressed
        {
            get { return (m_CurrentMouseState.LeftButton == ButtonState.Pressed && m_LastMouseState.LeftButton == ButtonState.Released); }
        }

        public static bool MouseRightReleased
        {
            get { return (m_CurrentMouseState.RightButton == ButtonState.Released && m_LastMouseState.RightButton == ButtonState.Pressed); }
        }

        public static bool MouseRightDrag
        {
            get { return (m_CurrentMouseState.RightButton == ButtonState.Pressed && m_LastMouseState.RightButton == ButtonState.Pressed); }
        }

        public static bool MouseRightPressed
        {
            get { return (m_CurrentMouseState.RightButton == ButtonState.Pressed && m_LastMouseState.RightButton == ButtonState.Released); }
        }

        public static bool MouseLeftReleased
        {
            get { return (m_CurrentMouseState.LeftButton == ButtonState.Released && m_LastMouseState.LeftButton == ButtonState.Pressed); }
        }

        public static bool MouseLeftDrag
        {
            get { return (m_CurrentMouseState.LeftButton == ButtonState.Pressed && m_LastMouseState.LeftButton == ButtonState.Pressed); }
        }

        public static bool MouseWheelDrag
        {
            get { return (m_CurrentMouseState.MiddleButton == ButtonState.Pressed); }
        }

        public static float MouseWheel
        {
            get { return m_CurrentMouseState.ScrollWheelValue - m_LastMouseState.ScrollWheelValue; }
        }
#endif


        private static GestureSample m_Gesture;
        public static GestureSample Gesture
        {
            get { return m_Gesture; }
        }

        public static void Update()
        {
            m_Gesture = TouchPanel.IsGestureAvailable ? TouchPanel.ReadGesture() : new GestureSample();

            if (CurrentTouchCollection.Count > 0)
            {
                OldTouchCollection = CurrentTouchCollection;
            }

            CurrentTouchCollection = TouchPanel.GetState();


                    if (CurrentTouchCollection.Count > 0)
                    {
                        while (TouchPanel.IsGestureAvailable)
                        {
                            TouchPanel.ReadGesture();
                        }
                    }


#if !Windows
            m_LastKeyboardState = m_CurrentKeyboardState;
            m_CurrentKeyboardState = Keyboard.GetState();

            m_LastMouseState = m_CurrentMouseState;
            m_CurrentMouseState = Mouse.GetState();
#endif

        }

#if !Windows
        public static bool SingleKeyPressInput(Keys a_Key)
        {
            return m_CurrentKeyboardState.IsKeyDown(a_Key) && m_LastKeyboardState.IsKeyUp(a_Key);
        }
        public static bool MulitKeyPressInput(Keys a_Key)
        {
            return m_CurrentKeyboardState.IsKeyDown(a_Key);
        }
        public static bool KeyHeldDown(Keys a_Key)
        {
            return m_CurrentKeyboardState.IsKeyDown(a_Key) && m_LastKeyboardState.IsKeyDown(a_Key);
        }
        public static bool KeyIsUp(Keys a_Key)
        {
            return m_CurrentKeyboardState.IsKeyUp(a_Key);
        }
#endif
    }
}
