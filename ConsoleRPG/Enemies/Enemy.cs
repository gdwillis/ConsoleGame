using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    
    class Enemy: GameObject
    {
        public string s = "I am an enemy";
        public Enemy(int x, int y, ConsoleColor color, GameObject[,] map, char label) : base(x, y, color, map, label, true)
        {
           
        }

        public void moveEnemy()
        {
            update(1, 0);           
        }

        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[newX, newY];
            if (gameObject == null)
            {
                return true;
            }
            if (gameObject.HasCollision)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
    }
}
