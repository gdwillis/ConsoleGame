using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Boss: Enemy
    {
        public bool isAlive; 
        public Boss(int x, int y, ConsoleColor color, GameObject[,] map, char label) : base(x, y, color, map, label)
        {
            isAlive = true; 
        }
    }
}
