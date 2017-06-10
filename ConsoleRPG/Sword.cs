using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Sword: Weapon
    {
        const int DISTANCE = 2;
        int distanceCounter = 0; 

        public Sword() : base()
        {
            color = ConsoleColor.DarkCyan;
            damage = 1; 
        }

        public override void fire(int x, int y, GameObject[,] map, Direction direction)
        {
            if (!isActive)
            {
                distanceCounter = 0;
            }

            base.fire(x, y, map, direction);
         
        }

        public override void moveProjectile(Player player)
        {
            if(distanceCounter > DISTANCE)
            {
                die();
            }
            if (isActive)
            {
                distanceCounter++;
            }
            base.moveProjectile(player);
           
        }

        protected override bool checkForGameObject()
        {
           return base.checkForGameObject();
         
        }
    }
}
