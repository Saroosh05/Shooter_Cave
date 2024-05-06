using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using GameFramework;

namespace Movement
{
    public class ArrowKeys : IMovement
    {
        private bool Jump = false;
        private int Force;
        private int Gravity = 20;
        private bool Moved = false;
        private IPlayer Player;

        public void SetPlayerInstance(IPlayer player)
        {
            Player = player;
        }

        public System.Drawing.Point Move(System.Drawing.Point Location, bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight) 
        {
            if (!collideUp && !enemyCollideUp)
            {
                PlayerJump(ref Location);
            }

            if (!collideLeft && !enemyCollideLeft)
            {
                MovePlayerLeft(ref Location);
            }

            if (!collideRight && !enemyCollideRight)
            {
                MovePlayerRight(ref Location);
            }

            if (!collideDown && !enemyCollideDown) 
            {
                FallUnderGravity(ref Location);
            }

            Shoot(ref Location);
            Player.UpdateImageDirection();

            return Location;
        }

        public void Shoot(ref System.Drawing.Point Location) 
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                if (Player.GetDirection() == Direction.Right)
                {
                    Player.Shoot(Location, Direction.Right);
                }
                else 
                {
                    Player.Shoot(Location, Direction.Left);
                }
               
            }
        }
        public void MovePlayerLeft(ref System.Drawing.Point Location)
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                Location.X -= 10;
                Player.SetDirection(Direction.Left);
            }
        }

        public void MovePlayerRight(ref System.Drawing.Point Location)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Location.X += 10;
                Player.SetDirection(Direction.Right);
            }
        }

        public void PlayerJump(ref System.Drawing.Point Location)
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                Location.Y -= 10;
            }
        }

        public void FallUnderGravity(ref System.Drawing.Point Location)
        {
            Location.Y++;
        }
    }
}
