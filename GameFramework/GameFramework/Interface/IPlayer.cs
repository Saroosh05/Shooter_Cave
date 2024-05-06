using Movement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public interface IPlayer
    {
        void Shoot(Point Location, Direction direction);
        void SetScore(int score);
        int GetScore();
        void SetHealth(int health);
        int GetHealth();
        List<Shot> GetShots();
        void RemoveShot();
        void SetDirection(Direction direction);
        Direction GetDirection();
        void UpdateImageDirection();
    }
}
