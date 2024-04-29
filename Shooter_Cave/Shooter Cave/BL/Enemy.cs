using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter_Cave
{
    internal class Enemy
    {
        protected PictureBox EnemyPic;
        protected string Direction;
        protected int Speed;
        protected int X;
        protected int Y;
        protected int Width;
        protected int Height;

        public Enemy(Image pic, int X, int Y, int Speed, int Width, int Height, string Direction) 
        {
            EnemyPic = new PictureBox();
            EnemyPic.Image = pic;
            this.Speed = Speed;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Direction = Direction;
        }

        public PictureBox GetEnemyPic() 
        {
            return EnemyPic;
        }
        public void CreateEnemy(Form form)
        {
            EnemyPic.BackColor = System.Drawing.Color.Transparent;
            EnemyPic.Location = new System.Drawing.Point(X, Y);
            EnemyPic.Size = new System.Drawing.Size(Width, Height);
            EnemyPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            EnemyPic.BringToFront();

            form.Controls.Add(EnemyPic);
        }
    }
}
