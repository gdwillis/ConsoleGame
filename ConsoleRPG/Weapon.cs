using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Weapon: GameObject
    {
        protected bool isActive;
        protected int damage; 
        public bool IsActive
        {
            get { return isActive; }
        }
        Direction direction;
        public Weapon() : base()
        {
            isActive = false;
           
        }

        public virtual void fire(int x, int y, GameObject[,] map, Direction direction)
        {
            //this makes for an interesting game mechanic to control the direction as the projectile is moving
            //this.direction = direction;
            if (!isActive)
            {
                initialize(x, y, map);
                this.direction = direction;
                isActive = true;
            }
        }

        public virtual void moveProjectile(Player player)
        {
            
            if (isActive)
            {
                switch (direction)
                {
                    case Direction.North:
                        {
                            update(Direction.North);
                            break;
                        }
                    case Direction.South:
                        {
                            update(Direction.South);

                            break;
                        }
                    case Direction.East:
                        {
                            update(Direction.East);
                            break;
                        }
                    case Direction.West:
                        {
                            update(Direction.West);
                            break;
                        }
                }
                player.update(Direction.Stay);
            }
        }
       
        protected override bool checkBounds()
        {
            if (NextX < 0 || NextX >= Console.WindowWidth || NextY < 0 || NextY >= Console.WindowHeight)
            {
                die();
                return false;
            }
           
            return true;
        }

        public void die()
        {
            isActive = false;
            //case trying to kill projectiles and they have not been added to map yet. As in going to another room.  
            if (map != null)
            {
                remove();
            } 
        
        }

        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if (gameObject == null)
            {
                return true;
            }
            if (gameObject is Enemy)
            {
                Enemy enemy = (Enemy)gameObject;
                enemy.takeDamage(damage);
            }

            if (gameObject.HasCollision)
            {
                die();
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
