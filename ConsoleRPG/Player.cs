using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Player: GameObject
    {
        enum Direction { North, South, East, West };
        Direction direction = Direction.North;

        public Destinations currentRoom; 

       // GameObject sword = new GameObject(ConsoleColor.DarkCyan);
      //  GameObject fireWand = new GameObject(ConsoleColor.Red);
        Item item; 
        public bool hasCompleteLevel = false;
        Inventory inventory;
       
        
        bool isInteracting;
        public bool IsInteracting
        {
            get { return isInteracting; }
        }

        public Player(): base()
        {
            color = ConsoleColor.Blue;
            label = 'P';
            inventory = new Inventory();
        }

        public void initialize(int x, int y, GameObject[,] map)
        {
            newX = x;
            newY = y;
            this.map = map;
            this.x = x;
            this.y = y;
            this.map[this.x, this.y] = this;
        }

        public void drawInventory()
        {
            inventory.draw(); 
        }
     
        public void movePlayer(ConsoleKeyInfo keyPressed)
        {
            // ConsoleKeyInfo keyInfo = Console.ReadKey(true);

           
                switch (keyPressed.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            update(0, -1);
                            direction = Direction.North;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            update(0, 1);
                            direction = Direction.South;
                            break;
                        }


                    case ConsoleKey.LeftArrow:
                        {
                            update(-1, 0);
                            direction = Direction.West;
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            update(1, 0);
                            direction = Direction.East;
                            break;
                        }
                    
                    case ConsoleKey.Spacebar:
                        {
                            if (inventory.Sword)
                            {
                                int swordPosX = 0;
                                int swordPosY = 0;
                                switch (direction)
                                {
                                    case Direction.North:
                                        {
                                            swordPosX = x;
                                            swordPosY = y - 1;
                                            break;
                                        }
                                    case Direction.South:
                                        {
                                            swordPosX = x;
                                            swordPosY = y + 1;
                                            break;
                                        }
                                    case Direction.East:
                                        {
                                            swordPosX = x + 1;
                                            swordPosY = y;
                                            break;
                                        }
                                    case Direction.West:
                                        {
                                            swordPosX = x - 1;
                                            swordPosY = y;
                                            break;
                                        }
                                }
                                //sword.update(swordPosX, swordPosY);
                                Console.BackgroundColor = color;
                            }

                            break; 

                        }
                
                
            }
  
        }

        public void interactInput()
        {
            if(item.HasEndedInteraction)
            {
                endInteraction();
            }
            else
            {
                continueDialog(); 
            }
        }

        void endInteraction()
        {
            if (item.RemoveImmediatly)
            {
                isInteracting = false;
                if (item.CanRemove)
                {
                    item.remove();
                }
                inventory.draw();
            }
            else
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    isInteracting = false;
                    if (item.CanRemove)
                    {
                        item.remove();
                    }
                    inventory.draw();
                }
            }

            
        }

        void continueDialog()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                item.interact(inventory); 
            }
        }


        public void attack(ConsoleKeyInfo keyPressed)
        {
          
        }

        
        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[newX, newY];
            if(gameObject == null)
            {
                return true; 
            }
            if(gameObject is Item)
            {
                item = (Item)gameObject;
                item.interact(inventory);
                isInteracting = true;
                

            }
            if (gameObject is Portal)
            {
                Portal portal = (Portal)gameObject;
                portal.transitionToNextRoom(); 
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
