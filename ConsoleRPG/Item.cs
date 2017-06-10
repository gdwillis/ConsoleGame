using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    //programming exercise: change this class to be more object oriented by using inheritance

    enum Type { blueKey, yellowKey, redKey, potion, ether, iceWand, oldMan, bluedoor, reddoor, yellowdoor, lavaTile, block, trigger, bossTrigger, princess };
   
    class Item : GameObject
    {
        bool hasEndedInteraction;
        
        public bool HasEndedInteraction
        {
            get { return hasEndedInteraction; }
        }

        bool canRemove;

        public bool CanRemove
        {
            get { return canRemove; }
        }

        bool removeImmediatly;

        public bool RemoveImmediatly
        {
            get { return removeImmediatly; }
        }


        int dialogCounter;
        Type type; 
        public Type Type
        {
            get { return type; }
        }


        public Item(int x, int y, GameObject[,] map, Type type): base(x, y, map, true)
        {
            
            removeImmediatly = false; 
            hasEndedInteraction = false;
            canRemove = true; 
            dialogCounter = 0; 
            this.type = type; 
            switch(type)
            {
                case Type.blueKey:
                    {
                        color = ConsoleColor.Blue;
                        label = 'B';
                        break; 
                    }
                case Type.yellowKey:
                    {
                        color = ConsoleColor.Yellow;
                        label = 'Y';
                        break;
                    }
                case Type.redKey:
                    {
                        color = ConsoleColor.Red;
                        label = 'R';
                        break;
                    }
                case Type.potion:
                    {
                        color = ConsoleColor.DarkRed;
                        label = 'P';
                        break;
                    }
                case Type.ether:
                    {
                        color = ConsoleColor.DarkBlue;
                        label = 'E';
                        break;
                    }
                case Type.iceWand:
                    {
                        color = ConsoleColor.DarkMagenta;
                        label = 'W';
                        break;
                    }

                case Type.oldMan:
                    {
                        color = ConsoleColor.Cyan;
                        label = 'S';
                        break;
                    }

                case Type.princess:
                    {
                        color = ConsoleColor.Cyan;
                        label = 'P';
                        break;
                    }

                case Type.bluedoor:
                    {
                        color = ConsoleColor.Blue;
                        label = 'D';
                        canRemove = false;
                        break;
                    }
                case Type.reddoor:
                    {
                        color = ConsoleColor.Red;
                        label = 'D';
                        canRemove = false;
                        break;
                    }
                case Type.yellowdoor:
                    {
                        color = ConsoleColor.Yellow;
                        label = 'D';
                        canRemove = false;
                        break;
                    }
                case Type.lavaTile:
                    {
                        color = ConsoleColor.Red;
                        label = ' ';
                        break;
                    }
                case Type.block:
                    {
                        color = ConsoleColor.Green;
                        label = 'B';
                        break;
                    }
                case Type.trigger:
                    {
                        color = ConsoleColor.DarkGreen;
                        label = 'T';
                        canRemove = false; 
                        break;
                    }
                case Type.bossTrigger:
                    {
                        color = ConsoleColor.Black;
                        label = ' ';
                        hasCollision = false; 
                        break;
                    }
            }

       //     draw();
        }


        public void interact(Inventory inventory)
        {
            
            switch (type)
            {
                case Type.blueKey:
                    {
                        presentkeyDialog(inventory);
                        inventory.BlueKey++;
                        break;
                    }
                case Type.yellowKey:
                    {
                        presentkeyDialog(inventory);
                        inventory.YellowKey++;
                        break;
                    }
                case Type.redKey:
                    {
                        presentkeyDialog(inventory);
                        inventory.RedKey++; 
                        break;
                    }
                case Type.potion:
                    {
                        presentConsumableDialog(inventory);
                        inventory.Potion++;
                        break;
                    }
                case Type.ether:
                    {
                        presentConsumableDialog(inventory);
                        inventory.Ether++;
                        break;
                    }
                case Type.iceWand:
                    {
                        presentFireWandDialog(inventory);
                        inventory.FireWand = true;
                        break;
                    }
                case Type.oldMan:
                    {
                        presentOldManDialog(inventory);
                        inventory.Sword = true; 
                        break;
                    }
                case Type.bluedoor:
                    {
                        presentDoorDialog(inventory);
                        break;
                    }
                case Type.reddoor:
                    {
                        presentDoorDialog(inventory);
                        break;
                    }
                case Type.yellowdoor:
                    {
                        presentDoorDialog(inventory);
                        break;
                    }
                case Type.trigger:
                    {
                        presentTriggerDialog(inventory);
                        break;
                    }
                case Type.bossTrigger:
                    {
                        presentBossTriggerDialog(inventory);
                        break;
                    }
                case Type.princess:
                    {
                        presentPrincessDialog(inventory);
                        break;
                    }
            }
            
        }

        void presentConsumableDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            Console.WriteLine("You have picked up a potion");
            hasEndedInteraction = true; 
           
        }

        void presentDoorDialog(Inventory inventory)
        {
            string keyType = "";
            ConsoleColor saveColor;
            bool isLocked = true; 
            if (type == Type.reddoor)
            {
                if(inventory.RedKey > 0)
                {
                    inventory.RedKey--;
                    isLocked = false; 
                }
                saveColor = ConsoleColor.Red;
                keyType = "RED KEY.";
            }
            else if (type == Type.bluedoor)
            {
                if (inventory.BlueKey > 0)
                {
                    inventory.BlueKey--;
                    isLocked = false;
                }
                saveColor = ConsoleColor.Blue;
                keyType = "BLUE KEY";
            }
            else
            {
                if (inventory.YellowKey > 0)
                {
                    inventory.YellowKey--;
                    isLocked = false;
                }
                saveColor = ConsoleColor.Yellow;
                keyType = "YELLOW KEY";
            }
            if (isLocked)
            {
                inventory.clearInventoryBox();
                Console.Write("You need a ");
                Console.ForegroundColor = saveColor;
                Console.Write(keyType);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(". To open this door.");
            }
            else
            {
                canRemove = true;
                removeImmediatly = true; 
            }
            hasEndedInteraction = true;
        }

        void presentkeyDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            string keyType = "";
            string doorType = "";
            ConsoleColor saveColor; 
            
            if (type == Type.redKey)
            {
                saveColor = ConsoleColor.Red;
                keyType = "RED KEY.";
                doorType = "RED DOOR";
            }
            else if (type == Type.blueKey)
            {
                saveColor = ConsoleColor.DarkBlue;
                keyType = "BLUE KEY";
                doorType = "BLUE DOOR";
            }
            else 
            {
                saveColor = ConsoleColor.Yellow;
                keyType = "YELLOW KEY";
                doorType = "YELLOW DOOR";
            }
            Console.Write("You have found a ");
            Console.ForegroundColor = saveColor;
            Console.Write(keyType);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(". With this key you can open any ");
            Console.ForegroundColor = saveColor;
            Console.Write(doorType);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(".");
            hasEndedInteraction = true;

        }

        void presentFireWandDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            Console.WriteLine("You have found the fire wand");
            hasEndedInteraction = true;

        }

        void presentTriggerDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            Console.WriteLine("It looks like something can be pushed on to this switch.");
            hasEndedInteraction = true;

        }

        void presentBossTriggerDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            Console.WriteLine("So you surrived my dungeon, but now you must face me! MUHAHAHA!");
            hasEndedInteraction = true;
            isSet = true; 

        }

        void presentPrincessDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            Console.WriteLine("Thank you for saving me!");
            hasEndedInteraction = true; 
        }

        void presentOldManDialog(Inventory inventory)
        {
            inventory.clearInventoryBox();
            if (dialogCounter == 0)
            {
                Console.WriteLine("You must save the princess locked in the dungeon.");
                
            }
            else if (dialogCounter == 1)
            {
                Console.WriteLine("Please take this sword it will protect you.");

            }

            else if (dialogCounter == 2)
            {
                Console.WriteLine("Safe journeys young hero!");
                //open drawbridge
                for (int x = Constants.WINDOW_WIDTH / 2 - 4; x < Constants.WINDOW_WIDTH / 2 + 4; x++)
                {
                    for (int y = 5; y < 10; y++)
                    {
                        GameObject gameObject = map[x, y];
                        gameObject.Color = ConsoleColor.Black;
                        gameObject.draw(); 
                    }
                }

                for (int x = Constants.WINDOW_WIDTH / 2 - 4; x < Constants.WINDOW_WIDTH / 2 + 4; x++)
                {
                    for (int y = 10; y < 16; y++)
                    {
                        GameObject gameObject = map[x, y];
                        gameObject.Color = ConsoleColor.Black;
                        gameObject.HasCollision = false; 
                        gameObject.draw();
                    }
                }

             //   new Portal(5, 0, Room.FirstRoom, player);
             //   new Portal(6, 0, Room.FirstRoom, player);
             //   new Portal(7, 0, Room.FirstRoom, player);

                hasEndedInteraction = true; 
            }

            dialogCounter++; 
        }

        public bool isSet;
 
        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if (gameObject == null)
            {
                return true;
            }
            if (gameObject is Item)
            {
                Item item = (Item) gameObject;
                if(item.type == Type.trigger)
                {
                    item.isSet = true;
                }
                return true;
            }
            else if (gameObject.HasCollision)
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
