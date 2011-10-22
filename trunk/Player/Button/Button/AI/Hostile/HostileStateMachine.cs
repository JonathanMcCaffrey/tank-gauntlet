using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Button
{
    public class HostileStateMachine : AbstractStateMachine
    {
        #region Data
        private Enemy mEnemy;
        public Enemy Enemy
        {
            get { return mEnemy; }
            set { mEnemy = value; }
        }
        #endregion

        #region Construction
        public  HostileStateMachine(Enemy aEnemy)
        {
            mEnemy = aEnemy;
            State = new HostileSeek(this);
        }
        #endregion
    }
}
