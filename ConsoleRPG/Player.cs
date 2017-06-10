using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Player : GameObject
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
        const int MAX_MAGIC = 10;
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
        public Inventory Inventory
        {
            get { return inventory; }
        }
        public Player() : base()
        {
            isAlive = true;
            hasWon = false;
            label = 'P';
            color = ConsoleColor.Blue;
            inventory = new Inventory();
            sword = new Sword();
            iceWand = new IceWand();
            health = MAX_HEALTH;
            magic = MAX_MAGIC;
            hasCollision = true;
        }



        public override void initialize(int x, int y, GameObject[,] map)
        {
            base.initialize(x, y, map);
        }

        public void drawInventory()
        {
            inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);
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
                        direction = Direction.North;
                        update(direction);
                        break;
                    }

                case ConsoleKey.DownArrow:
                    {

                        direction = Direction.South;
                        update(direction);
                        break;
                    }


                case ConsoleKey.LeftArrow:
                    {

                        direction = Direction.West;
                        update(direction);
                        break;
                    }

                case ConsoleKey.RightArrow:
                    {

                        direction = Direction.East;
                        update(direction);
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

        }


        public void takeDamage(int damage)
        {
            updateColor(ConsoleColor.Red);
            health -= damage;
            inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);

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
                    inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);
                }


            }
        }
        void consumePotion()
        {
            if (inventory.Potion > 0 && health < MAX_HEALTH)
            {
                inventory.Potion--;
                health = MAX_HEALTH;
                inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);
            }

        }
        void consumeEther()
        {
            if (inventory.Ether > 0 && magic < MAX_MAGIC)
            {
                inventory.Ether--;
                magic = MAX_MAGIC;
                inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);
            }
        }
        public void interactInput()
        {
            if (item.HasEndedInteraction)
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
                inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);

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
                    inventory.draw(health, MAX_HEALTH, magic, MAX_MAGIC);
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
            if (gameObject == null)
            {
                return true;
            }
            if (gameObject is Item)
            {
                item = (Item)gameObject;
                if (item.Type == Type.lavaTile)
                {
                    isAlive = false;
                }
                else if (item.Type == Type.block)
                {
                    switch (direction)
                    {
                        case Direction.North:
                            {
                                item.update(Direction.North);
                                break;
                            }
                        case Direction.South:
                            {
                                item.update(Direction.South);
                                break;
                            }
                        case Direction.West:
                            {
                                item.update(Direction.West);
                                break;
                            }
                        case Direction.East:
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
            if (gameObject is Enemy)
            {
                Enemy enemy = (Enemy)gameObject;
                takeDamage(enemy.Damage);
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
