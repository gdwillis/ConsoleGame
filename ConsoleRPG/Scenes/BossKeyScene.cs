using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class BossKeyScene: Scene
    {
        public BossKeyScene(Player player): base(player)
        {
            drawRoom();

            drawBottomPortal(Destinations.TopRightRoom, Door.OpenDoor);

        }
        public override void update()
        {
            base.update();
        }
        public override void reset()
        {
            base.reset();
            new Enemy(Constants.WINDOW_WIDTH / 2, 6, ConsoleColor.Yellow, map, 'E');
            new Enemy(Constants.WINDOW_WIDTH / 2, 7, ConsoleColor.Yellow, map, 'E');
            new Enemy(Constants.WINDOW_WIDTH / 2, 8, ConsoleColor.Yellow, map, 'E');
            new Enemy(Constants.WINDOW_WIDTH / 2, 9, ConsoleColor.Yellow, map, 'f');
            new Enemy(Constants.WINDOW_WIDTH / 2, 10, ConsoleColor.Yellow, map, 'f');
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Bottom);
        }
    }
}
