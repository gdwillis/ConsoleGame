using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG
{
    class Inventory
    {
        
        int blueKey;
        public int BlueKey {
            get { return blueKey; }
            set { blueKey = value; }
        }

        int yellowKey;
        public int YellowKey
        {
            get { return yellowKey; }
            set { yellowKey = value; }
        }

        int redKey;
        public int RedKey
        {
            get { return redKey; }
            set { redKey = value; }
        }

        int potion;
        public int Potion
        {
            get { return potion; }
            set { potion = value; }
        }

        int ether;
        public int Ether
        {
            get { return ether; }
            set { ether = value; }
        }

        bool sword;
        public bool Sword
        {
            get { return sword; }
            set {
                  sword = value;
                }
        }

        bool fireWand;
        public bool FireWand
        {
            get { return fireWand; }
            set {
                  fireWand = value;
            }
        }

        public void draw(int health, int magic)
        {
            clearInventoryBox(); 
            drawBorders();
            drawItemAmounts();
            drawWeapons();
            drawHealth(health);
            drawMagic(magic);
         
        }
        const int margin = 5;
       // int inventorWidth = Console.WindowWidth - margin*2;
       // int inventoryHeight = 7; 

        public void drawBorders()
        {
            Console.BackgroundColor = Constants.FOREGROUND_COLOR;
            Console.ForegroundColor = Constants.FOREGROUND_COLOR;

            //draw borders


            int x = margin;
            int y = Console.WindowHeight - 7;
            int counter = 0;


            for (int i = margin; i <= Console.WindowWidth - margin; i++)
            {
                Console.SetCursorPosition(x, y);
                x = i;
                Console.Write(' ');
                //draw bottom line
                if (i == Console.WindowWidth - margin && counter <= 1)
                {
                    i = margin;
                    x = i;
                    y = Console.WindowHeight - 1;
                    counter++;
                }

            }

            x = margin;
            y = Console.WindowHeight - 7;
            counter = 0;
            for (int i = Console.WindowHeight - 7; i <= Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(x, y);
                y = i;
                Console.Write(' ');

                if (i == Console.WindowHeight - 1 && counter <= 4)
                {
                    i = Console.WindowHeight - 7;
                    y = i;
                    x += (Console.WindowWidth - margin * 2) / 5;
                    counter++;
                    if (counter == 4)
                    {
                        x -= 1;
                    }
                }

            }

        }

        public void clearInventoryBox()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Blue;

            for (int x = margin + 1; x <= Console.WindowWidth - margin - 2; x++)
            {
                for (int y = Console.WindowHeight - 6; y <= Console.WindowHeight - 2; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(' ');
                }

            }
            //get into position to write dialog.
            Console.ForegroundColor = Constants.FOREGROUND_COLOR;
            Console.SetCursorPosition(margin + 2, Console.WindowHeight - 5);
        }

        public void drawItemAmounts()
        {
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;

            //draw potion amounts 
            int y = Console.WindowHeight - 3;
            int x = margin + 19;
            Console.SetCursorPosition(x, y);
            System.Console.Write("x" + potion);

            Console.ForegroundColor = Constants.FOREGROUND_COLOR;
            x = margin + (Console.WindowWidth / 5) + 17;
            Console.SetCursorPosition(x, y);
            System.Console.Write("x" + ether);

            //draw key amounts
       
            
            y = Console.WindowHeight - 5;
          
           
            x = Console.WindowWidth - (margin + 4);
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("x" + blueKey);
            Console.SetCursorPosition(x, y + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("x" + yellowKey);
            Console.SetCursorPosition(x, y + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("x" + redKey);




      


        }
        private void drawHealth(int health)
        {
            //draw health
            const int MAX_HEALTH = 3;
            if (health > MAX_HEALTH)
            {
                health = MAX_HEALTH; 
            }
            int x = margin + 20;
            int y = Console.WindowHeight - 5;
            for (int i = 1; i <= health; i++)
            {               
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;            
                Console.SetCursorPosition(x, y);
                System.Console.Write(" ");
                x -= 2;
            }
        }

        private void drawMagic(int magic)
        {
            //draw health
            const int MAX_MAGIC = 5;
            if (magic > MAX_MAGIC)
            {
                magic = MAX_MAGIC;
            }
            int x = margin + (Console.WindowWidth / 5) + 18;
            int y = Console.WindowHeight - 5;
            for (int i = 1; i <= magic; i++)
            {
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(x, y);
                System.Console.Write(" ");
                x -= 2;
            }
        }
        public void drawWeapons()
        {
            if (fireWand)
            {
                Console.ForegroundColor = Constants.FOREGROUND_COLOR;
                Console.BackgroundColor = Constants.FOREGROUND_COLOR;

                int x = (Console.WindowWidth / 5) * 4 - (margin + 4);
                int y = Console.WindowHeight - 3;
                Console.SetCursorPosition(x, y);
                System.Console.Write(' ');
            }

            if (sword)
            {
                Console.ForegroundColor = Constants.FOREGROUND_COLOR;
                Console.BackgroundColor = Constants.FOREGROUND_COLOR;
                int x = margin + (Console.WindowWidth / 5 * 2) + 9;
                int y = Console.WindowHeight - 3;
                Console.SetCursorPosition(x, y);
                System.Console.Write(' ');
            }
        }
        
    }
}
