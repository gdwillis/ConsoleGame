using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Player: GameObject
    {
      
        Direction direction = Direction.North;

        public Destinations currentRoom;
        public Destinations previouseRoom;
        public Sword sword;
        IceWand iceWand; 
        // GameObject sword = new GameObject(ConsoleColor.DarkCyan);
        //  GameObject fireWand = new GameObject(ConsoleColor.Red);
        Item item; 
        public bool hasCompleteLevel = false;
        public bool hasSpace = false; 
        public ConsoleKey saveKey = ConsoleKey.A;
        Inventory inventory;
        private bool isAlive;
        int health;
        int magic;
        const int MAX_HEALTH = 3;
        const int MAX_MAGIC = 5; 
        public bool IsAlive
        {
            get { return isAlive; }
        }

        private bool hasWon;
        public bool HasWon
        {
            get { return hasWon; }
        }


        bool isInteracting;
        public bool IsInteracting
        {
            get { return isInteracting; }
        }

        public Player(): base()
        {
            isAlive = true;
            hasWon = false; 
            label = 'P';
            color = ConsoleColor.Blue;
            inventory = new Inventory();
            sword = new Sword();
            iceWand = new IceWand();
            health = 3;
            magic = 5; 
        }
   
 
   
        public override void initialize(int x, int y, GameObject[,] map)
        {
            base.initialize(x, y, map);
        }

        public void drawInventory()
        {
            inventory.draw(health, magic); 
        }
     

        public void updateWeapons()
        {
            iceWand.moveProjectile(this);
            sword.moveProjectile(this); 
        }

        public void killOffWeapons()
        {
            iceWand.die(); 
            sword.die();
        }

        public void movePlayer(ConsoleKey keyPressed)
        {
            // ConsoleKeyInfo keyInfo = Console.ReadKey(true);
          
         
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        {
                            update(Direction.North);
                            direction = Direction.North;
                            break;
                        }

                    case ConsoleKey.DownArrow:
                        {
                            update(Direction.South);
                            direction = Direction.South;
                            break;
                        }


                    case ConsoleKey.LeftArrow:
                        {
                            update(Direction.West);
                            direction = Direction.West;
                            break;
                        }

                    case ConsoleKey.RightArrow:
                        {
                            update(Direction.East);
                            direction = Direction.East;
                            break;
                        }
            
                   
                    case ConsoleKey.Spacebar:
                        {
                        attack();
                        break;
                        }

                case ConsoleKey.Q:
                    {
                        useMagic();
                        break;
                    }

                case ConsoleKey.D:
                    {
                        drawMapDebugInfo();
                        break;
                    }
                case ConsoleKey.P:
                    {
                        consumePotion();
                        break;
                    }
                case ConsoleKey.E:
                    {
                        consumeEther();
                        break;
                    }



            }

            saveKey = keyPressed;

        }

        void takeDamage()
        {
             health--;
             inventory.draw(health, magic);
         
            if (health <= 0)
            {
                isAlive = false; 
            }
        }
        void attack()
        {
            if (inventory.Sword)
            {
                sword.fire(X, Y, map, direction);
            }
        }
        void useMagic()
        {
            if (inventory.FireWand && !iceWand.IsActive)
            {
                if (magic > 0)
                { 
                    magic--;
                    iceWand.fire(X, Y, map, direction);
                    inventory.draw(health, magic);
                }

             
            }
        }
        void consumePotion()
        {
            if (inventory.Potion > 0 && health < MAX_HEALTH)
            {
                inventory.Potion--;
                health = MAX_HEALTH;
                inventory.draw(health, magic);
            }

        }
        void consumeEther()
        {
            if (inventory.Ether > 0 && magic < MAX_MAGIC)
            {
                inventory.Ether--;
                magic = MAX_MAGIC;
                inventory.draw(health, magic);
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
        public void drawMapDebugInfo()
        {
            for (int x = 0; x < Constants.WINDOW_WIDTH; x++)
            {
                for (int y = 0; y < Constants.WINDOW_HEIGHT; y++)
                {
                    if (map[x, y] != null)
                    {

                        GameObject gameObject = map[x, y];


                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.SetCursorPosition(gameObject.X, gameObject.Y);
                        Console.Write(gameObject.Label);

                        if (map[gameObject.NextX, gameObject.NextY] != null)
                        {
                            gameObject = map[gameObject.NextX, gameObject.NextY];

                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.SetCursorPosition(gameObject.X, gameObject.Y);
                            Console.Write(gameObject.Label);
                        }
                        
                    }

                 
                }
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
                inventory.draw(health, magic);
                
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
                    if (item.Type == Type.princess)
                    {
                        isInteracting = false;
                        hasWon = true;
                        return;
                    }
                    inventory.draw(health, magic);
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


        
        protected override bool checkForGameObject()
        {
            GameObject gameObject = map[NextX, NextY];
            if(gameObject == null)
            {
                return true; 
            }
            if(gameObject is Item)
            {               
                item = (Item)gameObject;
                if (item.Type == Type.lavaTile)
                {
                    isAlive = false;
                }
                else if (item.Type == Type.block)
                {
                    switch(saveKey)
                    {
                        case ConsoleKey.UpArrow:
                            {
                                item.update(Direction.North);
                                break; 
                            }
                        case ConsoleKey.DownArrow:
                            {
                                item.update(Direction.South);
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                item.update(Direction.West);
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                item.update(Direction.East);
                                break;
                            }
                    }                                  
                }
              
                else
                {
                    item.interact(inventory);
                    isInteracting = true;
                }              
            }
            if(gameObject is Enemy)
            {
                takeDamage();
            }
            if (gameObject is Portal)
            {
                Portal portal = (Portal)gameObject;
                portal.transitionToNextRoom(direction);
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
