using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter_Cave
{
    internal class HorizontalEnemy : Enemy
    {
        public HorizontalEnemy(Image pic, int X, int Y, int Speed, int Widht, int Height, string Direction) : base(pic, X, Y, Speed, Widht, Height, Direction)
        {

        }

        public void MoveEnemy()
        {
            if (EnemyPic.Left <= 200)
            {
                Direction = "Right";
            }
            else if (EnemyPic.Left >= 500)
            {
                Direction = "Left";
            }
            if (Direction == "Left")
            {
                EnemyPic.Left -= Speed;
            }

            if (Direction == "Right")
            {
                EnemyPic.Left += Speed;
            }
        }
    }
}
