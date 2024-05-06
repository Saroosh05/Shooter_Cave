using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collisions
{
    public interface IDetection
    {
        bool DetectCollisionUp();
        bool DetectCollisionDown();
        bool DetectCollisionLeft();
        bool DetectCollisionRight();
    }
}
