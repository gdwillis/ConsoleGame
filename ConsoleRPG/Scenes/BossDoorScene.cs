using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class BossDoorScene: Scene
    {
        public BossDoorScene(Player player): base(player)
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < Constants.WINDOW_HEIGHT - 9; y++)
                {
                    if (y > Constants.WINDOW_HEIGHT / 2 - 8 && y < Constants.WINDOW_HEIGHT / 2 )
                    {
                        continue;
                    }
                  

                    new Item(x, y, map, Type.lavaTile);
                }
            }

            drawRoom();

            drawTopPortal(Destinations.BossRoom, Door.RedDoor);
            drawTopPortal(Destinations.BossRoom, Door.OpenDoor);
            drawRightPortal(Destinations.SecondRoom, Door.OpenDoor);
            
            new Item(2, 2, map, Type.ether);
            new Item(Constants.WINDOW_WIDTH - 3, 2, map, Type.potion);

        }
        
        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Right);
        }

    }
}
