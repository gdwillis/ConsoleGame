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

        public void draw()
        {
            clearInventoryBox(); 
            drawBorders();
            drawItemAmounts();
            drawWeapons();
         
        }
        const int margin = 5;
       // int inventorWidth = Console.WindowWidth - margin*2;
       // int inventoryHeight = 7; 

        public void drawBorders()
        {
            clearInventoryBox(); 
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
            //draw key amounts
            Console.BackgroundColor = Constants.BACKGROUND_COLOR;
            int x = margin + 19;
            int y = Console.WindowHeight - 5;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("x" + blueKey);
            Console.SetCursorPosition(x, y + 1);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("x" + yellowKey);
            Console.SetCursorPosition(x, y + 2);
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("x" + redKey);

            //draw potion amounts 
            Console.ForegroundColor = Constants.FOREGROUND_COLOR;
            x = Console.WindowWidth - (margin + 4);
            y = Console.WindowHeight - 3;
            Console.SetCursorPosition(x, y);           
            System.Console.Write("x" + potion);

            x -= (Console.WindowWidth / 5) - 2;
            Console.SetCursorPosition(x, y);
            System.Console.Write("x" + ether);

        }

        public void drawWeapons()
        {
            if (fireWand)
            {
                Console.ForegroundColor = Constants.FOREGROUND_COLOR;
                Console.BackgroundColor = Constants.FOREGROUND_COLOR;
                int x = margin + (Console.WindowWidth / 5 * 2) + 9;
                int y = Console.WindowHeight - 3;
                Console.SetCursorPosition(x, y);
                System.Console.Write(' ');
            }

            if (sword)
            {
                Console.ForegroundColor = Constants.FOREGROUND_COLOR;
                Console.BackgroundColor = Constants.FOREGROUND_COLOR;
                int x = margin + (Console.WindowWidth / 5) + 9;
                int y = Console.WindowHeight - 3;
                Console.SetCursorPosition(x, y);
                System.Console.Write(' ');
            }
        }
        
    }
}
