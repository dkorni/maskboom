using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Interfaces
{
    interface IDamageable
    {
        event Action OnDied;

        float Health { get; }

        void SetDamage(float damage);
    }
}
