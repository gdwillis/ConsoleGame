using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class WandScene: Scene
    {
        public WandScene(Player player): base(player)
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < Constants.WINDOW_HEIGHT - 9; y++)
                {
                    if ((x > Constants.WINDOW_WIDTH / 2 - 8 && x < Constants.WINDOW_WIDTH / 2 + 5))
                    {
                        continue;
                    }

                    new Item(x, y, map, Type.lavaTile);
                }
            }

            drawRoom();

            drawTopPortal(Destinations.RightRoom, Door.OpenDoor);

            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            new Item(Constants.WINDOW_WIDTH / 2 + 1, Constants.WINDOW_HEIGHT - 10, map, Type.ether);
            new Item(Constants.WINDOW_WIDTH / 2 - 5, Constants.WINDOW_HEIGHT - 10, map, Type.potion);
            new Item(Constants.WINDOW_WIDTH/2 - 2, Constants.WINDOW_HEIGHT - 10, map, Type.iceWand);

        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Top);
        }
    }
}
