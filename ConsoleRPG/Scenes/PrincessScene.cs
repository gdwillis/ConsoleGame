using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class PrincessScene : Scene
    {
        public PrincessScene(Player player) : base(player)
        {
            drawRoom();
            drawBottomPortal(Destinations.BossRoom, Door.BlockedDoor);
            new Item(Constants.WINDOW_WIDTH / 2 - 2, Constants.WINDOW_HEIGHT / 2, map, Type.princess);
        }

        public override void placePlayer(FromDirection fromDirection = FromDirection.Top)
        {
            base.placePlayer(FromDirection.Bottom);
        }
    }
}
