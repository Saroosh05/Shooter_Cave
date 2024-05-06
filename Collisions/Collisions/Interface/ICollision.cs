using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collisions
{
    public interface ICollision
    {
        int PerformAction(int points, int health, ref int check);
    }
}
