using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameFramework;

namespace Collisions
{
    public class Collision : ICollision
    {
        private GameObjectType Object1;
        private GameObjectType Object2;
        private GameAction Action;

        public Collision(GameObjectType Object1, GameObjectType Object2, GameAction Action)
        {
            this.Object1 = Object1;
            this.Object2 = Object2;
            this.Action = Action;
        }

        public int PerformAction(int points, int health, ref int check)
        {
            if (Action == GameAction.IncreasePoints)
            {
                points += 100;
            }
            else if (Action == GameAction.DecreasePoints)
            {
                health -= 30;

                check = 1;
                if (health <= 0)
                {
                    health = 0;
                    check = -3;
                }

                return health;
            }
            else if (Action == GameAction.Killed)
            {
                points += 100;
                check = -1;
            }
            else if (Action == GameAction.GameOver)
            {
                check = -3;
            }
            else if (Action == GameAction.Nothing) 
            {
            
            }

            return points;

        }

        public GameObjectType GetObjectType1 ()
        {
            return Object1;
        }
        public GameObjectType GetObjectType2()
        {
            return Object2;
        }
    }
}
