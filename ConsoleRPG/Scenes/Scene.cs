using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    enum Destinations { Outside, FirstRoom, SecondRoom, BoosDoorRoom, BossRoom, RightRoom, WandRoom, TopRightRoom, BossKeyRoom };
    enum Door { RedDoor, YellowDoor, BlueDoor, OpenDoor }
    class Scene
    {
        public GameObject[,] map;
        //protected List<GameObject> gameObjects = new List<GameObject>(); 
        //protected List<Enemy> enemies = new List<Enemy>();
        //protected List<Item> items = new List<Item>();
        //protected List<Portal> portals = new List<Portal>();
        protected Player player;

        public Scene(Player player)
        {
            this.player = player;
            map = new GameObject[Constants.WINDOW_WIDTH, Constants.WINDOW_HEIGHT];
            //set collision for inventory screen
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                new GameObject(i, Console.WindowHeight - 7, map, true);
            }
            
        }

       

        protected void drawTopPortal(Destinations destination, Door door)
        {
            switch(door)
            {
                case Door.BlueDoor:
                    {
                       new Item(Constants.WINDOW_WIDTH / 2 - 2, 1, map, Type.bluedoor);
                        break;
                    }
                case Door.YellowDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH / 2 - 2, 1, map, Type.yellowdoor);
                        break;
                    }
                case Door.RedDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH / 2 - 2, 1, map, Type.reddoor);
                        break;
                    }
                case Door.OpenDoor:
                    {
                       new GameObject(Constants.WINDOW_WIDTH / 2 - 2, 1, ConsoleColor.Black, map);
                        break;
                    }
            }
            
            new Portal(Constants.WINDOW_WIDTH / 2 - 2, 0, ConsoleColor.Black, map, destination, player);
         
        }

        protected void drawBottomPortal(Destinations destination, Door door)
        {
            switch (door)
            {
                case Door.BlueDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 9, map, Type.bluedoor);
                        break;
                    }
                case Door.YellowDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 9, map, Type.yellowdoor);
                        break;
                    }
                case Door.RedDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 9, map, Type.reddoor);
                        break;
                    }
                case Door.OpenDoor:
                    {
                       new GameObject(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 9, ConsoleColor.Black, map);
                        break;
                    }
            }

            new Portal(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 8, ConsoleColor.Black, map, destination, player);         
        }

        protected void drawLeftPortal(Destinations destination, Door door)
        {
            switch (door)
            {
                case Door.BlueDoor:
                    {
                        new Item(1, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.bluedoor);
                        break;
                    }
                case Door.YellowDoor:
                    {
                        new Item(1, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.yellowdoor);
                        break;
                    }
                case Door.RedDoor:
                    {
                        new Item(1, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.reddoor);
                        break;
                    }
                case Door.OpenDoor:
                    {
                        new GameObject(1, Constants.WINDOW_HEIGHT / 2 - 5, ConsoleColor.Black, map);
                        break;
                    }
            }

            new Portal(0, Constants.WINDOW_HEIGHT / 2 - 5, ConsoleColor.Black, map, destination, player);
        }

        protected void drawRightPortal(Destinations destination, Door door)
        {
            switch (door)
            {
                case Door.BlueDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH - 2, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.bluedoor);
                        break;
                    }
                case Door.YellowDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH - 2, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.yellowdoor);
                        break;
                    }
                case Door.RedDoor:
                    {
                        new Item(Constants.WINDOW_WIDTH - 2, Constants.WINDOW_HEIGHT / 2 - 5, map, Type.reddoor);
                        break;
                    }
                case Door.OpenDoor:
                    {
                        new GameObject(Constants.WINDOW_WIDTH - 2, Constants.WINDOW_HEIGHT / 2 - 5, ConsoleColor.Black, map);
                        break;
                    }
            }

            new Portal(Constants.WINDOW_WIDTH - 1, Constants.WINDOW_HEIGHT / 2 - 5, ConsoleColor.Black, map, destination, player);
            
        }

        protected void drawRoom()
        {

            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < Constants.WINDOW_HEIGHT - 7; y++)
                {
                    if (x > 1 && x < Console.WindowWidth - 2 && y > 1 && y < Constants.WINDOW_HEIGHT - 9)
                    {
                        continue;
                    }
                    new GameObject(x, y, ConsoleColor.Gray, map, ' ', true);
                    
                }
            }

        }

        public void clearMap()
        {
            Array.Clear(map, 0, map.Length);
        }

        public void draw()
        {       
            for(int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] != null)
                    { 
                        map[x, y].draw();
                    }
                }
            }
        //    player.draw();
        }

        public void update()
        {


            List<Enemy> enemies = new List<Enemy>();
            foreach(GameObject gameObject in map)
            {
                if (gameObject is Enemy)
                {
                    Enemy e = (Enemy)gameObject;
                    enemies.Add(e);
                }
            }
           
            foreach(Enemy enemy in enemies)
            {
                enemy.moveEnemy();
            }
            //for (int x = 0; x < map.GetLength(0); x++)
            //{
            //    for (int y = 0; y < map.GetLength(1); y++)
            //    {
            //        if(map[x, y] is Enemy)
            //        {
            //            Enemy enemy = (Enemy) map[x, y];
            //            enemy.moveEnemy();
            //        }
            //    }
            //}
        }

     
        public virtual void placePlayer()
        {
        }

        public virtual void resetEnemies()
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] is Enemy)
                    {
                        map[x, y] = null;
                    }
                }
            }

        }
        public void clearScreen()
        {    
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            Console.Clear();
        }
    }
}
