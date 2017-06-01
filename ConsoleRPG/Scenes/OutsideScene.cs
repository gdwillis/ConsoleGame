using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class OutsideScene: Scene
    {
        public OutsideScene(Player player) : base(player)
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {

                for (int y = 16; y < 23; y++)
                {
                    if (x >= Constants.WINDOW_WIDTH / 2 - 4 && x <= Constants.WINDOW_WIDTH / 2 + 3)
                    {
                        continue;
                    }
                     new GameObject(x, y, ConsoleColor.DarkGreen, map, ' ', true);
                    //gameObjects.Add(gameObject);
                }
            }
            //sky
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    new GameObject(x, y, ConsoleColor.Black, map, ' ');
                    //gameObjects.Add(gameObject);
                }
            }

            //moat

            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 10; y < 16; y++)
                {
                    new GameObject(x, y, ConsoleColor.Blue, map, ' ', true);
                }
            }
            //gate
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 2; y < 10; y++)
                {
                    if (y == 2 && x % 2 == 0)
                    {
                        continue;
                    }
                    new GameObject(x, y, ConsoleColor.DarkGray, map, ' ', true);

                }
            }
            //closed drawbridge
            for (int x = Constants.WINDOW_WIDTH / 2 - 7; x < Constants.WINDOW_WIDTH / 2 + 7; x++)
            {
                for (int y = 4; y < 10; y++)
                {
                    if ((y == 4 && x <= Constants.WINDOW_WIDTH / 2 - 6) || (y == 4 && x >= Constants.WINDOW_WIDTH / 2 + 5))
                    {
                        continue;
                    }
                    if ((y == 5 && x <= Constants.WINDOW_WIDTH / 2 - 7) || (y == 5 && x >= Constants.WINDOW_WIDTH / 2 + 6))
                    {
                        continue;
                    }
                    if (y >= 5 && x >= Constants.WINDOW_WIDTH / 2 - 4 && x <= Constants.WINDOW_WIDTH / 2 + 3)
                    {
                        new Portal(x, y, ConsoleColor.DarkRed, map, Destinations.FirstRoom, player);

                    }
                    else
                    {
                        new GameObject(x, y, ConsoleColor.Gray, map, ' ', true);

                    }
                }
            }

            new Item(Constants.WINDOW_WIDTH / 2, 17, map, Type.oldMan);

        }

        public override void placePlayer()
        {
            player.initialize(Constants.WINDOW_WIDTH / 2, 21, map);
        }
    }
}
