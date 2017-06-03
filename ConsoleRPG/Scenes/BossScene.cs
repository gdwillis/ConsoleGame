using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class BossScene: Scene
    {
        Item trigger;
        Boss boss; 
        
        public BossScene(Player player): base(player)
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < Constants.WINDOW_HEIGHT - 9; y++)
                {
                    if (x > 5 && x < Constants.WINDOW_WIDTH - 5 && y > 3 && y < Constants.WINDOW_HEIGHT - 11)
                    {
                        continue;
                    }

                    new Item(x, y, map, Type.lavaTile);
                }
            }

            drawRoom();

            drawTopPortal(Destinations.PrincessRoom, Door.BlockedDoor);
            drawBottomPortal(Destinations.RightRoom, Door.BlockedDoor);

            new GameObject(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 10, ConsoleColor.Black, map);
            new GameObject(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 11, ConsoleColor.Black, map);
            trigger = new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 12, map, Type.bossTrigger);
            boss = new Boss(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.DarkRed, map, 'B');
        }

        public override void update()
        {
            base.update();
            if(trigger.isSet)
            {
                new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 10, map, Type.lavaTile);
                new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT - 11, map, Type.lavaTile);
                draw();
                boss.isAlive = false; 
                trigger.isSet = false; 
            }
            if(!boss.isAlive)
            {
                drawTopPortal(Destinations.PrincessRoom, Door.OpenDoor);
                new GameObject(Constants.WINDOW_WIDTH / 2 - 2, 2, ConsoleColor.Black, map);
                new GameObject(Constants.WINDOW_WIDTH / 2 - 2, 3, ConsoleColor.Black, map);
                draw();
                boss.isAlive = true; 
            }
            boss.moveEnemy(); 
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Bottom);
        }
    }
}
