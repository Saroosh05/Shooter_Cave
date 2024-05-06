using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace Movement
{
    public interface IMovement
    {
        Point Move(Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight);
        void SetPlayerInstance(IPlayer player);
    }
}
