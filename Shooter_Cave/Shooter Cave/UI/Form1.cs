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
using GameFramework;
using Movement;
using Collisions;

namespace Shooter_Cave
{
    public partial class Form1 : Form
    {
        Game ShooterCave;
        int CheckForOver = 0;
        int CheckForWin = 0;

        public Form1()
        {
            InitializeComponent();
        } 

        private void timer_Tick(object sender, EventArgs e)
        {
            ShooterCave.UpdateIt();
            SetCounter();
            SetScore(ShooterCave.GetPlayerScore());
            SetHealth(ShooterCave.GetPlayerHealth());
            EndIt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShooterCave = Game.GetInstance(this);

            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm3, 213, 0, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm3, 413, 0, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm3, -5, 0, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm6, 199, 153, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm5, 30, 241, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm5, 604, 241, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm4, 476, 338, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm4, 158, 338, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm1, 331, 441, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm, 232, 476, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.bl1, 628, 443, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.bl1, 0, 443, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm2, 754, 13, null, GameObjectType.Wall, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.gm2, 0, 13, null, GameObjectType.Wall, null, null);

            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.t, 70, 211, null, GameObjectType.Treasure, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.t, 700, 415, null, GameObjectType.Treasure, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.t, 367, 123, null, GameObjectType.Treasure, null, null);

            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.e1_removebg_preview, 30, 40, new ZigZag(5, new System.Drawing.Point(754, 100), new System.Drawing.Point(30, 40), Direction.RightDown), GameObjectType.Enemy, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.e2_removebg_preview__1_, 31, 389, new Vertical(4, new System.Drawing.Point(400, 270), Direction.Up), GameObjectType.Enemy, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.e3_removebg_preview, 570, 165, new Horizontal(3, new System.Drawing.Point(690, 570), Direction.Right), GameObjectType.Enemy, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.p_removebg_preview, 360, 367, new ArrowKeys(), GameObjectType.Player, Shooter_Cave.Properties.Resources.shot_removebg_preview, Shooter_Cave.Properties.Resources.pR_removebg_preview);

            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.ff, 527, 401, null, GameObjectType.Fire, null, null);
            ShooterCave.AddGameObject(Shooter_Cave.Properties.Resources.ff, 132, 401, null, GameObjectType.Fire, null, null);

            

            Collision collision1 = new Collision(GameObjectType.Player, GameObjectType.Wall, GameAction.Nothing);
            Collision collision2 = new Collision(GameObjectType.Player, GameObjectType.Enemy, GameAction.DecreasePoints);
            Collision collision3 = new Collision(GameObjectType.Enemy, GameObjectType.Shot, GameAction.Killed);
            Collision collision4 = new Collision(GameObjectType.Player, GameObjectType.Container, GameAction.GameOver);
            Collision collision5 = new Collision(GameObjectType.Player, GameObjectType.Treasure, GameAction.IncreasePoints);

            ShooterCave.AddCollision(collision1);
            ShooterCave.AddCollision(collision2);
            ShooterCave.AddCollision(collision3);
            ShooterCave.AddCollision(collision4);
            ShooterCave.AddCollision(collision5);
        }


        private void SetCounter() 
        {
            PlayerCount.Text = "Player Count: " + ShooterCave.GetObjectCount(GameObjectType.Player);
            EnemyCount.Text = "Enemy Count: " + ShooterCave.GetObjectCount(GameObjectType.Enemy);
        }

        private void SetScore(int score) 
        {
            label1.Text = "Score: " + score;
        }

        private void SetHealth(int health) 
        {
            PlayerHealth.Value = health;
        }

        private void EndIt()
        {
            GameOver gameOver = new GameOver(ShooterCave);
            GameWin gameWin = new GameWin(ShooterCave);

            if (ShooterCave.GetEndGame())
            {
                if (CheckForOver == 0)
                {
                    gameOver.Show();
                    CheckForOver++;
                }

            }
            else if (ShooterCave.GetObjectCount(GameObjectType.Enemy) == 0) 
            {
                if (CheckForWin == 0)
                {
                    gameWin.Show();
                    this.Hide();
                    CheckForWin++;
                }
            }
        }
    }
}
