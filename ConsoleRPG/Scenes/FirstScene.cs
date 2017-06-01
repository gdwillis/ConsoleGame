using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class FirstScene: Scene
    {
        public FirstScene(Player player): base(player)
        {
            drawRoom();

            //draw back door
            for (int x = Constants.WINDOW_WIDTH / 2 - 4; x < Constants.WINDOW_WIDTH / 2 + 1; x++)
            {
                for (int y = Constants.WINDOW_HEIGHT - 8; y < Constants.WINDOW_HEIGHT - 6; y++)
                {
                    new GameObject(x, y, ConsoleColor.DarkGray, map, ' ', true);  
                    
                }
            }

            drawTopPortal(Destinations.SecondRoom, Door.OpenDoor);

            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            new Item(Constants.WINDOW_WIDTH - 20, 7, map, Type.yellowKey);

        }

        public override void resetEnemies()
        {
            base.resetEnemies();        
            new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E');
        }

        public override void placePlayer()
        {
            player.initialize(Constants.WINDOW_WIDTH / 2, Constants.WINDOW_HEIGHT - 10, map);
        }
    }
}
