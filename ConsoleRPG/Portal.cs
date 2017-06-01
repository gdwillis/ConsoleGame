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
        public Portal(int x, int y, ConsoleColor color, GameObject[,] map, Destinations destination, Player player):base(x, y, ConsoleColor.Red, map)
        {
            this.destination = destination;
            this.player = player;
        }

        public void transitionToNextRoom()
        {
            player.hasCompleteLevel = true;
            player.currentRoom = destination; 
        }
    }
}
