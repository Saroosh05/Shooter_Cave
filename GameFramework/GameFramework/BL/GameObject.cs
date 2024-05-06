using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Movement;

namespace GameFramework
{
    public class GameObject
    {
        protected PictureBox Pic;
        protected bool ShouldFall = false;
        protected IMovement Controller;
        protected GameObjectType ObjectType;

        public GameObject(Image img, int X, int Y, IMovement Controller, GameObjectType objectType)
        {
            Pic = new PictureBox();
            Pic.Image = img;
            Pic.Location = new Point(X, Y);
            Pic.Height = img.Height;
            Pic.Width = img.Width;
            Pic.BackColor = Color.Transparent;
            Pic.SizeMode = PictureBoxSizeMode.StretchImage;
            Pic.BringToFront();
            Pic.TabStop = false;
            this.Controller = Controller;

            if (objectType == GameObjectType.Fire)
            {
                Pic.Height = 148;
                Pic.Width = 125;
            }
            ObjectType = objectType;
        }

        public virtual void UpdateIt(bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {
            this.Pic.Location = Controller.Move(this.Pic.Location, collideUp, collideDown, collideLeft, collideRight, enemyCollideUp, enemyCollideDown, enemyCollideLeft, enemyCollideRight);
        }

        public PictureBox GetPictureBox()
        {
            return Pic;
        }

        public GameObjectType GetObjectType() 
        {
            return ObjectType;
        }
    }
}
