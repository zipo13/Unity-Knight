using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public interface DamageListener
    {
        void hurt(float attackDirection);
        void dead();
    }
}
