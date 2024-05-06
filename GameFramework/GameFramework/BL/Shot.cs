using Movement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFramework
{
    public class Shot : GameObject
    {
        public Shot(Image img, int X, int Y, IMovement Controller, GameObjectType objectType) : base(img, X, Y, Controller, objectType)
        {
        }

        public override void UpdateIt(bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {
            this.Pic.Location = Controller.Move(this.Pic.Location, collideUp, collideDown, collideLeft, collideRight, enemyCollideUp, enemyCollideDown, enemyCollideLeft, enemyCollideRight);
        }


    }
}
