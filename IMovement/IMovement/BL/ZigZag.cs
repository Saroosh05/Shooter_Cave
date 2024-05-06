using GameFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Movement
{
    public class ZigZag : IMovement
    {
        private int Speed;
        private Point BoundaryX;
        private Point BoundaryY;
        private Direction ZigZagDirection;
        private IPlayer Player;
        private int Count;

        public void SetPlayerInstance(IPlayer player)
        {
            Player = player;
        }


        public ZigZag(int Speed, Point BoundaryX,Point BoundaryY, Direction ZigZagDirection)
        {
            this.Speed = Speed;
            this.BoundaryX = BoundaryX;
            this.BoundaryY = BoundaryY;
            this.ZigZagDirection = ZigZagDirection;
            Count = 0;
        }

        public Point Move(Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {

            if (ZigZagDirection == Direction.Right)
            {
                if (Count < 5)
                {
                    Location.X += Speed;

                    Location.Y -= Speed;
                }
                else if (Count >= 5 && Count < 10)
                {

                    Location.X += Speed;

                    Location.Y += Speed;

                }
            }
            else if (ZigZagDirection == Direction.Left)
            {

                if (Count < 5)
                {
                    Location.X -= Speed;
                    Location.Y += Speed;
                }

                else if (Count >= 5 && Count < 10)
                {

                    Location.X -= Speed;
                    Location.Y -= Speed;
                }
            }

            if ((Location.X) >= BoundaryX.X || Location.Y >= BoundaryX.Y)
            {
                ZigZagDirection = Direction.Left;
            }
            else if (Location.X <= BoundaryY.X || Location.Y <= BoundaryY.Y)
            {
                ZigZagDirection = Direction.Right;
            }
            if (Count == 10)
            {
                Count = 0;
            }
            Count++;

            return Location;
        }
    }
}
