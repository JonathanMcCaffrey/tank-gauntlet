using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Button
{
    public class HostileState : AbstractState
    {
        #region Singletons
        protected PlayerManager thePlayerManager = PlayerManager.Get();
        protected EnemyManager theEnemyManager = EnemyManager.Get();
        protected TileManager theTileManager = TileManager.Get();
        #endregion
    }
}
