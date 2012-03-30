using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Button
{
    public class AbstractState
    {
        #region Data
        AbstractStateMachine mAbstractStateMachine;
        #endregion

        #region Methods
        public virtual void Update()
        {

        }
        #endregion
    }
}
