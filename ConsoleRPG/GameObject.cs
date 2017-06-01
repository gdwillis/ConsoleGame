using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class GameObject
    {
        protected int x;
        protected int y;
        protected int newX;
        protected int newY;
        protected bool hasCollision;
        protected GameObject[,] map;

        public bool HasCollision
        {
            get { return hasCollision; }
            set { hasCollision = value; }
        }

        public int X
        {
            get { return x; } 
        }

        public int Y
        {
            get { return y;  }
        }

        public int NewX
        {
            get { return newX; }
        }

        public int NewY
        {
            get { return newY; }
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

        public GameObject()
        {
        }

        public GameObject(ConsoleColor color, GameObject[,] map)
        {
            x = 0;
            y = 0;
            newX = x;
            newY = y;
            this.color = color;
            this.map = map;
            this.map[this.x, this.y] = this;
        }
     
        public GameObject(int x, int y, GameObject[,] map, bool hasCollision = false)
        {
            this.x = x;
            this.y = y;
            newX = x;
            newY = y;
            this.hasCollision = hasCollision;
            this.map = map;
            this.map[this.x, this.y] = this;
            label = ' ';
            color = ConsoleColor.Black; 
        }

        public GameObject(int x, int y, ConsoleColor color, GameObject[,] map, char label = ' ', bool hasCollision = false)
        {
            this.x = x;
            this.y = y;
            newX = x;
            newY = y;
            this.map = map;
            this.map[this.x, this.y] = this;
            this.color = color;
            this.label = label;
            this.hasCollision = hasCollision; 
            
        }

        public virtual void update(int x , int y)
        {
            newX = this.x + x;
            newY = this.y + y;

            if (checkBounds() && checkForGameObject())
            {
                remove();
                draw();
                if (!(map[newX, newY] is Portal))
                {
                    map[newX, newY] = this;
                }
                this.x = newX;
                this.y = newY;
            }
        }
        public virtual void draw()
        {
            //draw to new position
            Console.BackgroundColor = color;
            Console.ForegroundColor = Constants.FOREGROUND_COLOR;

            Console.SetCursorPosition(newX, newY);
            Console.Write(label);

        }
      
        public virtual void remove()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.ForegroundColor = Constants.BACKGROUND_COLOR;
            Console.SetCursorPosition(x, y);
            Console.Write(label);
            if (!(map[x, y] is Portal))
            {
                map[x, y] = null;
            }
        }

        bool checkBounds()
        {
            
            if (newX < 0 || newX >= Console.WindowWidth || newY < 0 || newY >= Console.WindowHeight)
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
