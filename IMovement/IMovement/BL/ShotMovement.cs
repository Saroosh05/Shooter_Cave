using GameFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movement
{
    public class ShotMovement : IMovement
    {
        private int Speed;
        private Direction ShotDirection;
        private IPlayer Player;

        public void SetPlayerInstance(IPlayer player)
        {
            Player = player;
        }
        public ShotMovement(int speed, Direction direction)
        {
            this.Speed = speed;
            this.ShotDirection = direction;


        }
        public Point Move(Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {

            if (ShotDirection == Direction.Right)
            {
                Location.X += Speed;
            }
            else
            {
                Location.X -= Speed;
            }

            return Location;
        }
    }
}
