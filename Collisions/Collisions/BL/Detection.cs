using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Collisions
{
    public class Detection : IDetection
    {
        List<GameObject> GameObjects;
        GameObjectType Object1;
        GameObjectType Object2;

        public Detection(List<GameObject> gameObjects, GameObjectType object1, GameObjectType object2) 
        {
            GameObjects = gameObjects;
            Object1 = object1;
            Object2 = object2;
        }
        public bool DetectCollisionUp()
        {
            int check = 0;
            for (int x = 0; x < GameObjects.Count; x++)
            {
                for (int y = 0; y < GameObjects.Count; y++)
                {
                    if (GameObjects[x].GetObjectType() == Object1 && GameObjects[y].GetObjectType() == Object2)
                    {
                        if (GameObjects[x].GetPictureBox().Top <= GameObjects[y].GetPictureBox().Bottom + 1 && (GameObjects[x].GetPictureBox().Top) >= GameObjects[y].GetPictureBox().Top && (GameObjects[x].GetPictureBox().Left > GameObjects[y].GetPictureBox().Left - 50 && (GameObjects[x].GetPictureBox().Left + 63) < GameObjects[y].GetPictureBox().Right + 50))
                        {
                            check++;
                        }
                    }
                }
            }

            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DetectCollisionRight()
        {
            int check = 0;

            for (int x = 0; x < GameObjects.Count; x++)
            {
                for (int y = 0; y < GameObjects.Count; y++)
                {
                    if (GameObjects[x].GetObjectType() == Object1 && GameObjects[y].GetObjectType() == Object2)
                    {
                        if ((GameObjects[x].GetPictureBox().Top > GameObjects[y].GetPictureBox().Top && (GameObjects[x].GetPictureBox().Top + GameObjects[x].GetPictureBox().Height) < (GameObjects[y].GetPictureBox().Top + GameObjects[y].GetPictureBox().Height)) && ((GameObjects[x].GetPictureBox().Left + GameObjects[x].GetPictureBox().Width) >= GameObjects[y].GetPictureBox().Left) && (GameObjects[x].GetPictureBox().Left < (GameObjects[y].GetPictureBox().Left + GameObjects[y].GetPictureBox().Width))) 
                        {
                            check++;
                        }

                        if (((GameObjects[x].GetPictureBox().Left + GameObjects[x].GetPictureBox().Width) >= GameObjects[y].GetPictureBox().Left) && (GameObjects[x].GetPictureBox().Left < (GameObjects[y].GetPictureBox().Left + GameObjects[y].GetPictureBox().Width)) && (((GameObjects[x].GetPictureBox().Top < GameObjects[y].GetPictureBox().Top + 20 && GameObjects[x].GetPictureBox().Bottom > GameObjects[y].GetPictureBox().Bottom - 30)) || (GameObjects[x].GetPictureBox().Top < GameObjects[y].GetPictureBox().Top && GameObjects[x].GetPictureBox().Top > GameObjects[y].GetPictureBox().Bottom)))
                        {
                            check++;
                        }
                    }
                }
            }

            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DetectCollisionDown()
        {
            int check = 0;

            for (int x = 0; x < GameObjects.Count; x++)
            {
                for (int y = 0; y < GameObjects.Count; y++)
                {
                    if (GameObjects[x].GetObjectType() == Object1 && GameObjects[y].GetObjectType() == Object2)
                    {

                        if (GameObjects[x].GetPictureBox().Top + GameObjects[x].GetPictureBox().Height >= GameObjects[y].GetPictureBox().Top - 3 && (GameObjects[x].GetPictureBox().Top + GameObjects[x].GetPictureBox().Height) <= GameObjects[y].GetPictureBox().Top && (GameObjects[x].GetPictureBox().Left > GameObjects[y].GetPictureBox().Left - 50 && (GameObjects[x].GetPictureBox().Left + 63) < GameObjects[y].GetPictureBox().Right + 50))
                        {
                            check++;
                        }
                    }
                }
            }

            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DetectCollisionLeft()
        {
            int check = 0;

            for (int x = 0; x < GameObjects.Count; x++)
            {
                for (int y = 0; y < GameObjects.Count; y++)
                {
                    if (GameObjects[x].GetObjectType() == Object1 && GameObjects[y].GetObjectType() == Object2)
                    {
                        if ((GameObjects[x].GetPictureBox().Top > GameObjects[y].GetPictureBox().Top && (GameObjects[x].GetPictureBox().Top + GameObjects[x].GetPictureBox().Height) < (GameObjects[y].GetPictureBox().Top + GameObjects[y].GetPictureBox().Height)) && (GameObjects[x].GetPictureBox().Left <= (GameObjects[y].GetPictureBox().Left + GameObjects[y].GetPictureBox().Width)) && (GameObjects[x].GetPictureBox().Left > GameObjects[y].GetPictureBox().Left))
                        {
                            check++;
                        }

                        if ((GameObjects[x].GetPictureBox().Left <= (GameObjects[y].GetPictureBox().Left + GameObjects[y].GetPictureBox().Width + 2) && (GameObjects[x].GetPictureBox().Left > GameObjects[y].GetPictureBox().Left) && ((GameObjects[x].GetPictureBox().Top < GameObjects[y].GetPictureBox().Top + 20 && GameObjects[x].GetPictureBox().Bottom > GameObjects[y].GetPictureBox().Bottom - 30)) || (GameObjects[x].GetPictureBox().Top < GameObjects[y].GetPictureBox().Top && GameObjects[x].GetPictureBox().Top > GameObjects[y].GetPictureBox().Bottom)))
                        {
                            check++;
                        }
                    }
                }
            }

            if (check > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
