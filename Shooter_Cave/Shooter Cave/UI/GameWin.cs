using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameFramework;

namespace Shooter_Cave
{
    public partial class GameWin : Form
    {
        Game ShooterCave;
        public GameWin(Game game)
        {
            InitializeComponent();
            ShooterCave = game;
        }

        private void GameWin_Load(object sender, EventArgs e)
        {
            score.Text = "Score :   " + ShooterCave.GetPlayerScore();
        }
    }
}
