using GameFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public class Horizontal : IMovement
    {
        private int Speed;
        private Point Boundary;
        private Direction HorzizontalDirection;
        private IPlayer Player;

        public void SetPlayerInstance(IPlayer player)
        {
            Player = player;
        }

        public Horizontal(int Speed, Point Boundary, Direction HorzizontalDirection) 
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.HorzizontalDirection = HorzizontalDirection;
        }

        public Point Move(Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight) 
        {
            if (!enemyCollideRight && !enemyCollideLeft)
            {
              
            }

            if (Location.X <= Boundary.Y)
            {
                HorzizontalDirection = Direction.Right;
            }
            else if (Location.X >= Boundary.X)
            {
                HorzizontalDirection = Direction.Left;
            }
            if (HorzizontalDirection == Direction.Left)
            {
                Location.X -= Speed;
            }

            if (HorzizontalDirection == Direction.Right)
            {
                Location.X += Speed;
            }
            return Location;
        }
    }
}
