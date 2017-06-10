using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class BossKeyScene: Scene
    {
        List<Enemy> enemies = new List<Enemy>();
        int counter;
        bool hasSpawnedKey; 
        public BossKeyScene(Player player): base(player)
        {
            drawRoom();
            drawBottomPortal(Destinations.TopRightRoom, Door.OpenDoor);
            counter = 0;
          
        }
        public override void update()
        {
            base.update();

            foreach (Enemy enemy in enemies)
            {
                if (!enemy.IsAlive)
                {
                    counter++;
                }
            }
            if(counter != enemies.Count)
            {
                counter = 0; 
            }
            if (counter >= enemies.Count && !hasSpawnedKey)
            {
               Item item = new Item(7, 7, map, Type.redKey);
               item.draw();
                hasSpawnedKey = true; 
            }


        }
        public override void reset()
        {
            if (!hasSpawnedKey)
            {
                base.reset();

                counter = 0;
                enemies.Clear();
                enemies.Add(new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E'));
                enemies.Add(new Enemy(Constants.WINDOW_WIDTH / 2, 7, ConsoleColor.Yellow, map, 'E'));
                enemies.Add(new Enemy(Constants.WINDOW_WIDTH / 2, 8, ConsoleColor.Yellow, map, 'E'));
                enemies.Add(new Enemy(Constants.WINDOW_WIDTH / 2, 9, ConsoleColor.Yellow, map, 'f'));
                enemies.Add(new Enemy(Constants.WINDOW_WIDTH / 2, 10, ConsoleColor.Yellow, map, 'f'));
            }
           
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Bottom);
        }
    }
}
