using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooter_Cave
{
    internal class DiagonalEnemy : Enemy
    {
        public DiagonalEnemy(Image pic, int X, int Y, int Speed, int Widht, int Height, string Direction) : base (pic, X, Y, Speed, Widht, Height, Direction) 
        {
        
        }

        public void MoveEnemy()
        {
            if (EnemyPic.Top <= 40)
            {
                Direction = "Up";
            }
            else if (EnemyPic.Top >= 200)
            {
                Direction = "Down";
            }

            if (Direction == "Down")
            {
                EnemyPic.Top -= Speed;
                EnemyPic.Left -= Speed;
            }

            if (Direction == "Up")
            {
                EnemyPic.Top += Speed;
                EnemyPic.Left += Speed;
            }

        }
    }
}
