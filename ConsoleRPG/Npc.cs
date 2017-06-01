using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Npc : GameObject
    {
        public Npc(int x, int y, ConsoleColor color, GameObject[,] map, char label) : base(x, y, color, map, label)
        {

        }

        public void interact(Inventory inventory)
        {

        }
    }
}
