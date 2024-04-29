using EZInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Shooter_Cave
{
    public partial class Form1 : Form
    {
        Player GamePlayer;
        DiagonalEnemy Enemy1;
        HorizontalEnemy Enemy2;
        VerticalEnemy Enemy3;
        List<PictureBox> Walls;

        public Form1()
        {
            InitializeComponent();
            GamePlayer = new Player(Shooter_Cave.Properties.Resources.p_removebg_preview, 360, 356);
            Enemy1 = new DiagonalEnemy(Shooter_Cave.Properties.Resources.e1_removebg_preview, 684, 197, 4, 64, 41, "Up");
            Enemy3 = new VerticalEnemy(Shooter_Cave.Properties.Resources.e2_removebg_preview__1_, 31, 393, 4, 48, 34, "Up");
            Enemy2 = new HorizontalEnemy(Shooter_Cave.Properties.Resources.e3_removebg_preview, 181, 83, 4, 68, 68, "Left");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            fire1.SendToBack();
            fire2.SendToBack();

            GamePlayer.MovePlayer(Walls);
            GamePlayer.MoveShot(this);

            Enemy1.MoveEnemy();
            Enemy2.MoveEnemy();
            Enemy3.MoveEnemy();

            GamePlayer.DetectCollision(Enemy1.GetEnemyPic());
            GamePlayer.DetectCollision(Enemy2.GetEnemyPic());
            GamePlayer.DetectCollision(Enemy3.GetEnemyPic());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddWalls();
            GamePlayer.CreatePlayer(this);
            Enemy1.CreateEnemy(this);
            Enemy2.CreateEnemy(this);
            Enemy3.CreateEnemy(this);   
        }

        private void AddWalls() 
        {
            Walls = new List<PictureBox>() {w1, w2, w3, w4, w5, w6, w7, w8, w9, w10, w11, w12, w13, w14};
        }
    }
}
