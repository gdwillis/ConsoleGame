using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    //best place to put enums? 
    enum Direction { North, South, East, West, Stay };

    class GameObject
    {
        private int x;
        private int y;
        private int nextX;
        private int nextY;

        public int NextX
        {
            get { return nextX;  }
        }

        public int NextY
        {
            get { return nextY; }
        }

        public int X
        {
            get { return x; }
        }

        public int Y
        {
            get { return y; }
        }

        protected bool hasCollision;
        protected GameObject[,] map;

        public bool HasCollision
        {
            get { return hasCollision; }
            set { hasCollision = value; }
        }


        protected ConsoleColor color;
        protected char label;

        public char Label
        {
            get { return label; }
        }

        public ConsoleColor Color
        {
            get { return color; }
            set { color = value; }
        }

        public virtual void initialize(int x, int y, GameObject[,] map)
        {
            this.map = map;
            this.x = x;
            this.y = y;
            this.nextX = x;
            this.nextY = y;
            this.map[this.x, this.y] = this;
        }

        public GameObject()
        {
        }

        public GameObject(ConsoleColor color, GameObject[,] map)
        {
            this.color = color;
            this.map = map;
            this.map[this.x, this.y] = this;
        }
     
        public GameObject(int x, int y, GameObject[,] map, bool hasCollision = false)
        {
            initialize(x,y,map);
            this.hasCollision = hasCollision;
            label = ' ';
            color = ConsoleColor.Black; 
        }

        public GameObject(int x, int y, ConsoleColor color, GameObject[,] map, char label = ' ', bool hasCollision = false)
        {
            initialize(x, y, map);
            this.color = color;
            this.label = label;
            this.hasCollision = hasCollision; 
            
        }

        public virtual void update(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    {
                        nextY -= 1;
                        break;
                    }
                case Direction.South:
                    {
                        nextY += 1;
                        break;
                    }
                case Direction.East:
                    {
                        nextX += 1;
                        break;
                    }
                case Direction.West:
                    {
                        nextX -= 1; 
                        break;
                    }

                case Direction.Stay:
                    {
                        nextX = x;
                        nextY = y; 
                        break;
                    }
            }

            if (checkBounds() && checkForGameObject())
            {            
                remove();
                draw();
                //so that player does not overwrite portal 
                if (!(map[nextX, nextY] is Portal))
                {
                    map[nextX, nextY] = this;
                }
                this.x = nextX;
                this.y = nextY;
            }
            else //gameobject did not take the new step so keep new posistion the same as current position
            {
                nextX = this.x;
                nextY = this.y;
            }
        }
        public virtual void draw()
        {
            //draw to new position
            Console.BackgroundColor = color;
            Console.ForegroundColor = Constants.FOREGROUND_COLOR;

            Console.SetCursorPosition(nextX, nextY);
            Console.Write(label);

        }
      
        public virtual void remove()
        {
            if (map[x, y] == this)
            {
                Console.BackgroundColor = Constants.BACKGROUND_COLOR;
                Console.ForegroundColor = Constants.BACKGROUND_COLOR;
                Console.SetCursorPosition(x, y);
                Console.Write(label);
                map[x, y] = null;
            }

        }


        protected virtual bool checkBounds()
        {
            
            if (nextX < 0 || nextX >= Console.WindowWidth || nextY < 0 || nextY >= Console.WindowHeight)
            {
                return false;
            }

            return true;
        }
      
        protected virtual bool checkForGameObject()
        {
            return false; 
        }

       
        
    }
}
