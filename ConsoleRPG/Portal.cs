using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    

    class Portal: GameObject
    {        
        Destinations destination;
        Player player; 
        public Portal(int x, int y, ConsoleColor color, GameObject[,] map, Destinations destination, Player player):base(x, y, ConsoleColor.Black, map, ' ', true)
        {
            this.destination = destination;
            this.player = player;
        }

        public void transitionToNextRoom(Direction direction)
        {
            player.killOffWeapons();
            player.hasCompleteLevel = true;
            player.previouseRoom = player.currentRoom;
            player.currentRoom = destination; 
        }
    }
}
