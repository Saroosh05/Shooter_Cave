using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Framework_FallingUnderGravity
{
    public class Game
    {
        private int Gravity;
        private Form GameForm;
        private List<GameObject> GameObjects;

        public Game(int gravity, Form form)
        {
            this.Gravity = gravity;
            this.GameForm = form;
            GameObjects = new List<GameObject>();
        }

        public void AddGameObject(Image img, int x, int y, bool gravity) 
        {
            GameObject gameObject = new GameObject(img, x, y, gravity);
            GameObjects.Add(gameObject);
        }

        public void UpdateMovements() 
        {
            foreach (GameObject gameObject in GameObjects)
            {
                if (gameObject.GetGravity())
                {
                    int y = gameObject.GetY();
                    y += Gravity;
                }
            }
        }
    }
}
