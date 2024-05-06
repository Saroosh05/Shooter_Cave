using Movement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFramework
{
    public class Player : GameObject, IPlayer
    {
        private int Score = 0;
        private int Health = 100;
        List<Shot> Shots;
        Game game;
        Image ShotPic;
        public static Player GamePlayer = null;
        Direction PlayerDirection;
        Image RightImage;
        Image LeftImage;
        private bool isFiring = false;

        public static Player GetInstance(Image img, int X, int Y, IMovement Controller, GameObjectType objectType, Image shotPic, Image img2)
        {
            if (GamePlayer == null) 
            {
                GamePlayer = new Player(img, X, Y, Controller, objectType, shotPic, img2);
            }
            return GamePlayer;
        }

        private Player(Image img, int X, int Y, IMovement Controller, GameObjectType objectType, Image shotPic, Image img2) : base(img, X, Y, Controller, objectType)
        {
            game = Game.GetInstance(Game.Container);
            Shots = new List<Shot>();
            this.ShotPic = shotPic;
            this.RightImage = img2;
            this.LeftImage = img;
        }

        public override void UpdateIt(bool collideUp, bool collideDown, bool collideLeft, bool collideRight, bool enemyCollideUp, bool enemyCollideDown, bool enemyCollideLeft, bool enemyCollideRight)
        {
            this.Pic.Location = Controller.Move(this.Pic.Location, collideUp, collideDown, collideLeft, collideRight, enemyCollideUp, enemyCollideDown, enemyCollideLeft, enemyCollideRight);
        }

        public void SetScore(int score) 
        {
            Score = score;
        }

        public int GetScore() 
        {
            return Score;
        }

        public void SetHealth(int health)
        {
            Health = health;
        }

        public int GetHealth()
        {
            return Health;
        }

        public void Shoot(Point location, Direction direction)
        {

            if (!isFiring)
            {
                isFiring = true;

                Shot shot = new Shot(ShotPic, location.X + 10, location.Y + 20, new ShotMovement(10, direction), GameObjectType.Shot);
                Shots.Add(shot);
                game.AddShot(shot);

                Timer resetTimer = new Timer();
                resetTimer.Interval = 600; // Adjust the interval as needed
                resetTimer.Tick += (sender, e) =>
                {
                    isFiring = false;

                    resetTimer.Stop();
                    resetTimer.Dispose();
                };
                resetTimer.Start();
            }

            RemoveShot();
        }

        public void RemoveShot()
        {
            List<Shot> ShotsCopy = new List<Shot>(Shots);


            foreach (Shot shot in ShotsCopy) 
            {
                if (shot.GetPictureBox().Left <= 0 || shot.GetPictureBox().Bounds.IntersectsWith(FindWall().GetPictureBox().Bounds))
                {
                    shot.GetPictureBox().Visible = false;
                    game.GetContainer().Controls.Remove(shot.GetPictureBox());
                    game.GetGameObjects().Remove(shot);
                    Shots.Remove(shot);
                }
            }

        }

        public GameObject FindWall() 
        {
            GameObject wall = null;
            foreach (GameObject gameObject in game.GetGameObjects()) 
            {
                if (gameObject.GetObjectType() == GameObjectType.Wall)
                {
                    if (gameObject.GetPictureBox().Location == new Point(754, 13))
                    {
                        wall = gameObject;
                    }
                }
            }

            return wall;
        }

        public List<Shot> GetShots()
        {
            return Shots;
        }

        public Direction GetDirection() 
        {
            return PlayerDirection;
        }

        public void SetDirection(Direction direction)
        {
            PlayerDirection = direction;
        }

        public void UpdateImageDirection() 
        {
           
            if (PlayerDirection == Direction.Right)
            {
                Pic.Image = RightImage;
                Pic.Height = 63;
                Pic.Width = 62;
            }
            else 
            {
                Pic.Image = LeftImage;
            }
        }
    }
}
