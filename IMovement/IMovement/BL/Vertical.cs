using GameFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public class Vertical : IMovement
    {
        private int Speed;
        private Point Boundary;
        private Direction VerticalDirection;
        private IPlayer Player;

        public void SetPlayerInstance(IPlayer player)
        {
            Player = player;
        }

        public Vertical(int Speed, Point Boundary, Direction VerticalDirection)
        {
            this.Speed = Speed;
            this.Boundary = Boundary;
            this.VerticalDirection = VerticalDirection;
        }

        public Point Move(Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {
            if (!enemyCollideRight && !enemyCollideLeft && !enemyCollideRight)
            { }
            
            if (Location.Y <= Boundary.Y)
            {
                VerticalDirection = Direction.Up;
            }
            else if (Location.Y >= Boundary.X)
            {
                VerticalDirection = Direction.Down;
            }

            if (VerticalDirection == Direction.Down)
            {
                Location.Y -= Speed;
            }

            if (VerticalDirection == Direction.Up)
            {
                Location.Y += Speed;
            }

            return Location;
        }
    }
}
