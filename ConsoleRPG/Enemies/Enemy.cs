﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    
    class Enemy: GameObject
    {
        public string s = "I am an enemy";
        public Enemy(int x, int y, ConsoleColor color, GameObject[,] map, char label) : base(x, y, color, map, label, true)
        {
           
        }

        public void moveEnemy()
        {
            update(Direction.East);           
        }

        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if (gameObject == null)
            {
                return true;
            }
       
            if (gameObject.HasCollision)
            {
                return false;
            }
            else
            {

                return true;
            }
        }
    }
}
