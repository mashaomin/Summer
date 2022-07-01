using System;
using System.Collections.Generic;
using System.Text;

namespace Summer.Battle.Interface
{
    public interface I_Enemy
    {
        I_EnemyComp Get<I_EnemyComp>();
    }

    public interface I_EnemyComp
    {

    }
}
