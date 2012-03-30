using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input.Touch;


namespace TankGauntlet
{
    public static class Input
    {
        public static void Initiailize()
        {
            TouchPanel.EnabledGestures = GestureType.Tap;
        }


        private static GestureSample m_Gesture;
        public static GestureSample Gesture
        {
            get { return m_Gesture; }
        }

        public static void Update()
        {
            if (TouchPanel.IsGestureAvailable)
            {
                m_Gesture = TouchPanel.ReadGesture();
            }
        }
    }
}
