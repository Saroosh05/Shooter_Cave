using EZInput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Shooter_Cave
{
    internal class Player
    {
        private PictureBox Person;
        private int X;
        private int Y;
        private List<Shot> Shots;
        private bool jump = false;
        private int force;
        private int gravity = 20;
        private bool playerMoved = false;
        private string Direction = "Left";

        public Player(Image pic, int x, int y)
        {
            Person = new PictureBox();
            Person.Image = pic;
            X = x;
            Y = y;
            Shots = new List<Shot>();
        }

        public void CreatePlayer(Form form)
        {
            Person.BackColor = System.Drawing.Color.Transparent;
            Person.Location = new System.Drawing.Point(X, Y);
            Person.Size = new System.Drawing.Size(63, 75);
            Person.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            Person.TabIndex = 15;
            Person.BringToFront();
            Person.TabStop = false;

            form.Controls.Add(Person);
        }

        public void MovePlayer(List<PictureBox> Walls) 
        {
            
            /*if (!WallCollisions(Walls)) 
            {
                MovePlayerLeft();
                MovePlayerRight();
                MovePlayerUp();
                MovePlayerDown();
            }*/

            MovePlayerLeft();
            MovePlayerRight();
            MovePlayerUp();
            MovePlayerDown();
            //PlayerJump();
            //SetPlayerPosition(Walls);
            FallUnderGravity(Walls);
        }
        public void MovePlayerLeft()
        {
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                Person.Left -= 10;
            }
        }

        public void MovePlayerRight()
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                Person.Left += 10;
                Direction = "Right";
            }
        }

        public void MovePlayerUp()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                Person.Top -= 10;
                Direction = "Left";
            }
        }

        public void MovePlayerDown()
        {
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                Person.Top += 10;
                Direction = "Down";
            }
        }

        public void PlayerJump()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (!jump)
                {

                    jump = true;
                    force = gravity;
                    Direction = "Up";
                }
            }
        }

        

        public void SetPlayerPosition(List<PictureBox> Walls)
        {
            playerMoved = false;

            if (jump)
            {
                Person.Top -= force;
                force--;
            }
           
            if (WallCollisions(Walls))
            {
                jump = false;
            }

        }

        public void FallUnderGravity(List<PictureBox> Walls)
        {
            bool Fall = true;

            foreach (PictureBox wall in Walls)
            {
                int distance = wall.Top - Person.Bottom;


                if (Person.Bottom >= wall.Top && Person.Bottom <= wall.Top &&( Person.Left > wall.Left - 50 && Person.Right < wall.Right + 50))
                {
                    Fall = false;
                }
            }

            if (Fall)
            {
                Person.Top ++;
            }
        }


        public bool WallCollisions(List<PictureBox> Walls)
        {
            bool check = false;

            foreach (PictureBox wall in Walls)
            {


                /*// Check for collision with the top side of the wall
                if (Person.Bottom >= wall.Top && Person.Top >= wall.Bottom)
                {
                    Person.Top = wall.Top + wall.Height;
                    check = true;
                }*/

               /* // Check for collision with the left side of the wall
                if (Person.Right >= wall.Left && Person.Left <= wall.Left)
                {
                    Person.Left = wall.Left - Person.Width; // Move person just left of the wall
                    check = true;
                }*/

                // Check for collision with the right side of the wall
                if (Person.Left <= wall.Left + wall.Width && Person.Right >= wall.Right && (Person.Top >= wall.Top || Person.Top + (Person.Height/2) <= wall.Top + wall.Height))
                {
                    Person.Left ++;
                    //wall.Visible = false;
                    check = true;
                    break;
                }
            }

            return check;
        }


        /*public bool WallCollisions(List<PictureBox> Walls)
        {
            for (int x = 0;x < Walls.Count; x++)
            {
                if (Walls[x].Bounds.IntersectsWith(Person.Bounds))
                {
                    if (Direction == "Left")
                    {
                        Person.Left += 10;
                    }
                    if (Direction == "Right")
                    {
                        Person.Left -= 10;
                    }
                    if (Direction == "Up")
                    {
                        Person.Top -= 10;
                    }
                    if (Direction == "Down")
                    {
                        Person.Top += 10;
                    }
                    return true;
                }
            }
            return false;

        }*/

        public void Shoot(Form form) 
        {
            Shot shot = new Shot();
            if (shot.CreateShot(this.Person, form))
            {
                Shots.Add(shot);
            }
        }
        public void MoveShot(Form form) 
        {
            Shoot(form);

            for (int x = 0; x < Shots.Count; x++)
            {
                Shots[x].MoveShot();
                if (Shots[x].RemoveShot(form)) 
                {
                    Shots.Remove(Shots[x]);
                }       
            }
        }

        public void DetectCollision(PictureBox enemy)
        {
            for (int x = 0; x < Shots.Count; x++)
            {
                if (Shots[x].GetShot().Bounds.IntersectsWith(enemy.Bounds))
                {
                    enemy.Visible = false;
                    Shots[x].GetShot().Visible = false;
                }
            }
        }
    }
}
