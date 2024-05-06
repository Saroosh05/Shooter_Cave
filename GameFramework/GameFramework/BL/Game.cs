using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Movement;
using Collisions;

namespace GameFramework
{
    public class Game
    {
        public static Game ThisGame = null;
        public static Form Container;
        List<GameObject> GameObjects;
        List<Collision> Collisions;
        IPlayer GamePlayer;
        bool EndGame = false;

        private Game(Form container)
        {
            GameObjects = new List<GameObject>();
            Collisions = new List<Collision>();
            Container = container;
        }

        public static Game GetInstance(Form Container)
        {
            if (ThisGame == null)
            {
                ThisGame = new Game(Container);
            }

            return ThisGame;
        }

        public void AddGameObject(System.Drawing.Image img, int X, int Y, IMovement Controller, GameObjectType objectType, System.Drawing.Image ShotPic, System.Drawing.Image PlayerRightPic)
        {
            GameObject gameObject = null;

            if (objectType == GameObjectType.Enemy)
            {
                gameObject = new Enemy(img, X, Y, Controller, objectType);
            }
            else if (objectType == GameObjectType.Player)
            {
                GamePlayer = Player.GetInstance(img, X, Y, Controller, objectType, ShotPic, PlayerRightPic);
                gameObject = AddPlayer(GamePlayer);
                Controller.SetPlayerInstance(GamePlayer);
            }
            else if (objectType == GameObjectType.Wall) 
            {
                gameObject = new Wall(img, X, Y, Controller, objectType);
            }
            else if (objectType == GameObjectType.Fire)
            {
                gameObject = new Fire(img, X, Y, Controller, objectType);
            }
            else if (objectType == GameObjectType.Treasure)
            {
                gameObject = new Treasure(img, X, Y, Controller, objectType);
            }

            GameObjects.Add(gameObject);
            Container.Controls.Add(gameObject.GetPictureBox());
        }

        public GameObject AddPlayer(IPlayer player)
        {

            GameObjects.Add(player as Player);
            Container.Controls.Add((player as Player)?.GetPictureBox());

            return player as Player;
        }

        public void AddCollision(Collision collision) 
        {
            Collisions.Add(collision);
        }


        public void UpdateIt()
        {
            List<GameObject> gameObjectListCopy = new List<GameObject>(GameObjects);
            Detection PlayerAndWall = new Detection(GameObjects, GameObjectType.Player, GameObjectType.Wall);
            Detection PlayerAndEnemy = new Detection(GameObjects, GameObjectType.Player, GameObjectType.Enemy);

            bool playerCollidedWithEnemy = false;

            foreach (GameObject gameObject in gameObjectListCopy)
            {
                if (gameObject.GetObjectType() != GameObjectType.Wall && gameObject.GetObjectType() != GameObjectType.Fire && gameObject.GetObjectType() != GameObjectType.Treasure)
                {
                    gameObject.UpdateIt(PlayerAndWall.DetectCollisionUp(), PlayerAndWall.DetectCollisionDown(), PlayerAndWall.DetectCollisionLeft(), PlayerAndWall.DetectCollisionRight(), PlayerAndEnemy.DetectCollisionUp(), PlayerAndEnemy.DetectCollisionDown(), PlayerAndEnemy.DetectCollisionLeft(), PlayerAndEnemy.DetectCollisionRight());

                    if (PlayerAndWall.DetectCollisionUp() || PlayerAndWall.DetectCollisionDown() || PlayerAndWall.DetectCollisionLeft() || PlayerAndWall.DetectCollisionRight())
                    {
                        CollisionAction(gameObject, GameObjectType.Wall);
                    }

                    if (PlayerAndEnemy.DetectCollisionUp() || PlayerAndEnemy.DetectCollisionDown() || PlayerAndEnemy.DetectCollisionLeft() || PlayerAndEnemy.DetectCollisionRight())
                    {
                        if (!playerCollidedWithEnemy)
                        {
                            playerCollidedWithEnemy = true;
                            CollisionAction(gameObject, GameObjectType.Enemy);
                        }
                        
                    }

                    if (gameObject.GetObjectType() == GameObjectType.Enemy)
                    {
                        if (Detect(gameObject, GameObjectType.Shot))
                        {
                            CollisionAction(gameObject, GameObjectType.Shot);
                        }
                    }

                    if (gameObject.GetObjectType() == GameObjectType.Player)
                    {
                        if (Detect(gameObject, GameObjectType.Container))
                        {
                            CollisionAction(gameObject, GameObjectType.Container);
                        }

                        if (Detect(gameObject, GameObjectType.Treasure))
                        {
                            CollisionAction(gameObject, GameObjectType.Treasure);
                        }
                    }
                }
            }

            GamePlayer.RemoveShot();
        }

        public bool Detect(GameObject gameObject, GameObjectType gameObject2) 
        {
            int check = 0;
            for (int y = 0; y < GameObjects.Count; y++)
            {
                if (GameObjects[y].GetObjectType() == gameObject2)
                {
                    if (gameObject.GetPictureBox().Bounds.IntersectsWith(GameObjects[y].GetPictureBox().Bounds))
                    {
                        GameObjects[y].GetPictureBox().Visible = false;
                        GameObjects.Remove(GameObjects[y]);
                        check++;
                    }
                }

                if (gameObject2 == GameObjectType.Container)
                {
                    if (gameObject.GetPictureBox().Top + gameObject.GetPictureBox().Height >= Container.Top + Container.Height - 70)
                    {
                        check++;
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

        public void CollisionAction(GameObject gameObject1, GameObjectType gameObject) 
        {
            foreach (Collision collision in Collisions)
            {
                if ((collision.GetObjectType1() == gameObject1.GetObjectType() && collision.GetObjectType2() == gameObject) || (collision.GetObjectType1() == gameObject && collision.GetObjectType2() == gameObject1.GetObjectType())) 
                {
                    int check = 0;
                    int action = collision.PerformAction(GamePlayer.GetScore(), GamePlayer.GetHealth(), ref check);

                    if (check == 0)
                    {
                        GamePlayer.SetScore(action);

                    }
                    else if (check == 1) 
                    {
                        GamePlayer.SetHealth(action);
                    }
                    else if (check == -1)
                    {
                        if (gameObject1.GetObjectType() == GameObjectType.Enemy)
                        {
                            gameObject1.GetPictureBox().Visible = false;
                            GameObjects.Remove(gameObject1);
                            GamePlayer.SetScore(action);
                        }
                    }
                    else if (check == -3)
                    {
                        EndGame = true;
                        Container.Hide();
                        
                    }

                }
                
            }
        }
        public int GetPlayerScore() 
        {
            return GamePlayer.GetScore();
        }

        public int GetObjectCount(GameObjectType gameObject)
        {
            int count = 0;

            for (int x= 0; x < GameObjects.Count; x++)
            {
                if (GameObjects[x].GetObjectType() == gameObject) 
                {
                    count++;

                    if (GameObjects[x].GetObjectType() == GameObjectType.Player) 
                    {
                        return count;
                    }
                }
            }
            return count;
        }

        public void AddShot(Shot shot)
        {
            GameObjects.Add(shot);
            Container.Controls.Add(shot.GetPictureBox());
        }

        public List<GameObject> GetGameObjects() 
        {
            return GameObjects;
        }

        public Form GetContainer() 
        {
            return Container;
        }

        public int GetPlayerHealth() 
        {
            return GamePlayer.GetHealth();
        }

        public bool GetEndGame() 
        {
            return EndGame;
        }
    }
}
