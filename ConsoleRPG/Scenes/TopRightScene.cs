using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class TopRightScene: Scene
    {
        Item trigger1;
        Item trigger2; 
        public TopRightScene(Player player): base(player)
        {
            drawRoom();
            drawBottomPortal(Destinations.RightRoom, Door.OpenDoor);
            drawTopPortal(Destinations.BossKeyRoom, Door.BlockedDoor);
            new Item(Constants.WINDOW_WIDTH - 20, 7, map, Type.potion);
            trigger1 = new Item(Constants.WINDOW_WIDTH - 3, 2, map, Type.trigger);
            trigger2 = new Item(2, 2, map, Type.trigger);
            new Item(Constants.WINDOW_WIDTH - 10, 6, map, Type.block);
            new Item(10, 6, map, Type.block);
        }

        public override void reset()
        {
            base.reset();
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] is Item)
                    {
                        Item item = (Item)map[x, y];
                        if (item.Type == Type.block)
                        {
                            map[x, y] = null;
                        }
                    }
                }
            }
            trigger1 = new Item(Constants.WINDOW_WIDTH - 3, 2, map, Type.trigger);
            trigger2 = new Item(2, 2, map, Type.trigger);
            new Item(Constants.WINDOW_WIDTH - 10, 6, map, Type.block);
            new Item(10, 6, map, Type.block);
            drawTopPortal(Destinations.BossKeyRoom, Door.BlockedDoor);
            // new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E');
            // new Enemy(Constants.WINDOW_WIDTH / 2, 8, ConsoleColor.Yellow, map, 'E');
        }
        public override void update()
        {
            base.update();
            if(trigger1.isSet && trigger2.isSet)
            {
                drawTopPortal(Destinations.BossKeyRoom, Door.OpenDoor);
                draw();
                trigger1.isSet = false; 
            }
        }
        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Bottom);
        }
    }

   
}
