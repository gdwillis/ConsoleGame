using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class RightScene: Scene
    {
        public RightScene(Player player) : base(player)
        {
            drawRoom();
            drawTopPortal(Destinations.TopRightRoom, Door.OpenDoor);
            drawLeftPortal(Destinations.SecondRoom, Door.OpenDoor);
            drawBottomPortal(Destinations.WandRoom, Door.YellowDoor);
        }

        public override void reset()
        {
            base.reset();
            new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E');
            new Flyer(Constants.WINDOW_WIDTH / 2, 8, ConsoleColor.Green, map, 'F');
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            if (player.previouseRoom == Destinations.SecondRoom)
            {
                base.placePlayer(FromDirection.Left);
            }
            else if (player.previouseRoom == Destinations.TopRightRoom)
            {
                base.placePlayer(FromDirection.Top);
            }
            else if (player.previouseRoom == Destinations.WandRoom)
            {
                base.placePlayer(FromDirection.Bottom);
            }
        }
    }
}
