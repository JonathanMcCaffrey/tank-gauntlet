using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;


namespace TankGauntlet
{
    public static class Input
    {
        public static TouchCollection CurrentTouchCollection = new TouchCollection();
        public static TouchCollection OldTouchCollection = new TouchCollection();

        public static void Initiailize()
        {
            TouchPanel.EnabledGestures = GestureType.Tap | GestureType.FreeDrag | GestureType.DragComplete;
        }


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
        }
    }
}
