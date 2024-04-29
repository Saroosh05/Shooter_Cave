using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework_FallingUnderGravity
{
    internal class GameObject
    {
        private Image Pic;
        private int X;
        private int Y;
        private bool Gravity;

        public GameObject(Image image, int x, int y, bool gravity)
        {
            Pic = image;
            X = x;
            Y = y;
            Gravity = gravity;
        }

        public bool GetGravity() 
        {
            return Gravity;
        }

        public int GetX() 
        {
            return X;
        }

        public int GetY() 
        {
            return Y;
        }
    }
}
