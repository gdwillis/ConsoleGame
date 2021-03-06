﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class IceWand: Weapon
    {
        public IceWand() : base()
        {
            color = ConsoleColor.Cyan;
            damage = 2;
        }
      
        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if (gameObject == null)
            {
                return true;
            }
            

            if (gameObject is Player)
            {
                return true; 
            }
            if (gameObject is Item)
            {
                Item item = (Item)gameObject;
                if (item.Type == Type.lavaTile)
                {
                    item.remove();
                    return true; 
                }
            }

            return base.checkForGameObject();


        }
    }
}
