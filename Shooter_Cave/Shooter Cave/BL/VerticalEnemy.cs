using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter_Cave
{
    internal class VerticalEnemy : Enemy
    {
        public VerticalEnemy(Image pic, int X, int Y, int Speed, int Widht, int Height, string Direction) : base(pic, X, Y, Speed, Widht, Height, Direction)
        {

        }

        public void MoveEnemy()
        {
            if (EnemyPic.Top <= 270)
            {
                Direction = "Up";
            }
            else if (EnemyPic.Top >= 400)
            {
                Direction = "Down";
            }

            if (Direction == "Down")
            {
                EnemyPic.Top -= Speed;
            }

            if (Direction == "Up")
            {
                EnemyPic.Top += Speed;
            }

        }
    }
}
