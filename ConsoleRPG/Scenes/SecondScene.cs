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
            drawLeftPortal(Destinations.BossDoorRoom, Door.YellowDoor);
            drawRightPortal(Destinations.RightRoom, Door.BlueDoor);
            new Item(Constants.WINDOW_WIDTH - 20, 7, map, Type.blueKey);

        }

        public override void reset()
        {
            base.reset();
            new Enemy(Constants.WINDOW_WIDTH / 2, 3, ConsoleColor.Yellow, map, 'E');
            new Enemy(Constants.WINDOW_WIDTH / 2, 2, ConsoleColor.Yellow, map, 'E');
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            if (player.previouseRoom == Destinations.FirstRoom)
            {
                base.placePlayer(FromDirection.Bottom);
            }
            else if (player.previouseRoom == Destinations.RightRoom)
            {
                base.placePlayer(FromDirection.Right);
            }
            else if (player.previouseRoom == Destinations.BossDoorRoom)
            {
                base.placePlayer(FromDirection.Left);
            }
        }

    }
}
