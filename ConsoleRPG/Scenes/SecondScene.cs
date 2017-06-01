using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class SecondScene: Scene
    {
        public SecondScene(Player player): base(player)
        {
            drawRoom();
            drawBottomPortal(Destinations.FirstRoom, Door.OpenDoor);
            drawLeftPortal(Destinations.BoosDoorRoom, Door.YellowDoor);
            drawRightPortal(Destinations.RightRoom, Door.BlueDoor);
            new Item(Constants.WINDOW_WIDTH - 20, 7, map, Type.blueKey);

        }

        public override void resetEnemies()
        {
            base.resetEnemies();
            new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E');
            new Enemy(Constants.WINDOW_WIDTH / 2, 8, ConsoleColor.Yellow, map, 'E');
        }

        public override void placePlayer()
        {
            player.initialize(Constants.WINDOW_WIDTH / 2, Constants.WINDOW_HEIGHT - 10, map);
        }

    }
}
