using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Button
{
    public class AbstractStateMachine
    {
        #region Data
        private AbstractState mState;
        public AbstractState State
        {
            get { return mState; }
            set { mState = value; }
        }

        private AbstractState mSecondaryState;
        protected AbstractState SecondaryState
        {
            get { return mSecondaryState; }
            set { mSecondaryState = value; }
        }
        #endregion

        #region Methods
        public void Update()
        {
            mState.Update();

            if (mSecondaryState != null)
            {
                mSecondaryState.Update();
            }
        }
        #endregion
    }
}
