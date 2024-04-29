using EZInput;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shooter_Cave
{
    internal class Shot
    {
        private PictureBox ShotPic;
        private string direction;

        public Shot() 
        {
            ShotPic = new PictureBox();
        }
        public PictureBox GetShot() 
        {
            return ShotPic;
        }

        public bool CreateShot(PictureBox player, Form form)
        {
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                ShotPic.BackColor = System.Drawing.Color.Transparent;
                ShotPic.Image = Shooter_Cave.Properties.Resources.shot_removebg_preview;
                ShotPic.Top = player.Top + 29;
                ShotPic.Left = player.Left - 30;
                ShotPic.Size = new System.Drawing.Size(20, 20);
                ShotPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                ShotPic.TabIndex = 17;
                ShotPic.TabStop = false;
                ShotPic.BringToFront();

                form.Controls.Add(ShotPic);

                return true;
            }

            return false;
        }

        public void MoveShot()
        {
            ShotPic.Left -= 30;
        }

        public bool RemoveShot(Form form) 
        {
            if (ShotPic.Left <= 0)
            {
                form.Controls.Remove(ShotPic);
                return true;
            }
            return false;
          
        }
    }
}
