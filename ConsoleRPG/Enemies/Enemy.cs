using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    
    class Enemy: GameObject
    {
        Random rnd;
        static int seed = 0;
        protected int health; 
        protected int damage;
        bool isAlive;
        public bool IsAlive
        {
            get { return isAlive; }
        }
        public int Health
        {
            get { return health; }
        }

        public int Damage
        {
            get { return damage; }
        }

        public Enemy(int x, int y, ConsoleColor color, GameObject[,] map, char label) : base(x, y, color, map, label, true)
        {
            isAlive = true; 
            damage = 1;
            health = 1; 
            seed++;
            rnd = new Random(seed);
            color = ConsoleColor.Magenta; 
        }
        
        public void moveEnemy()
        {
            if (isAlive)
            {
                float random = rnd.Next(0, 100);

                if (random < 5)
                {
                    update(Direction.North);
                }
                else if (random < 10)
                {
                    update(Direction.South);
                }
                else if (random < 15)
                {
                    update(Direction.West);
                }
                else if (random < 20)
                {
                    update(Direction.East);
                }
                else if (random < 100)
                {
                    update(Direction.Stay);
                }
                updateColor(color);
            }

            else
            {
                remove(); 
            }
                    
        }

        public void takeDamage(int damage)
        {
            updateColor(ConsoleColor.Red);
            health-=damage;
            if (health <= 0)
            {
                isAlive = false;
            }
        }

        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if (gameObject == null)
            {
                return true;
            }

            if(gameObject is Player)
            {
                Player player = (Player)gameObject;
                player.takeDamage(damage); 

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
