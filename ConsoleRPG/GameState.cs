using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleRPG
{
    static class GameState
    {
        static Player player;
        static bool hasLevelStarted;

        static Scene currentScene;
        static OutsideScene outsideScene;
        static FirstScene firstScene;
        static SecondScene secondScene;
        static RightScene rightScene;
        static BossDoorScene bossDoorScene;
        static WandScene wandScene;
        static TopRightScene topRightRoom;
        static BossKeyScene bossKeyScene;
        static BossScene bossScene;
        static PrincessScene princessScene;
        public static void Start()
        {
        
            player = new Player();
            player.currentRoom = Destinations.Outside; 
            outsideScene = new OutsideScene(player);
            firstScene = new FirstScene(player);
            secondScene = new SecondScene(player);
            rightScene = new RightScene(player);
            bossDoorScene = new BossDoorScene(player);
            wandScene = new WandScene(player);
            topRightRoom = new TopRightScene(player);
            bossKeyScene = new BossKeyScene(player);
            bossScene = new BossScene(player);
            princessScene = new PrincessScene(player); 

            hasLevelStarted = false;
            
            while (player.IsAlive && !player.HasWon)
            {
                if (!hasLevelStarted)
                {
                    initializeRoom();
                    hasLevelStarted = true;
                }
                if (!player.IsInteracting)
                {
                    
                    currentScene.update();

                    player.updateWeapons(); 
                    
                  
                    if (Console.KeyAvailable)
                    {
                        //readkey has a delay do to windows character repeat delay seeting on the keyboard. 
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);

                        //prevents lag effect  
                        while (Console.KeyAvailable) { Console.ReadKey(true); }
                        player.movePlayer(keyPressed.Key);
                        
                        if (keyPressed.Key == ConsoleKey.Escape)
                        {
                            //end application
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            return;
                        }
                    }
                    


                }
                else
                {
                    player.interactInput();
                }
                
                if (player.hasCompleteLevel)
                {
                    hasLevelStarted = false;
                    player.hasCompleteLevel = false;
                    // EndGame(); 

                }
                Thread.Sleep(Constants.GAME_SPEED);
               
            }
            
            EndGame(); 
        }

        static void EndGame()
        {
            currentScene.clearScreen();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 2);
            if (player.IsAlive)
            {
                System.Console.WriteLine("Congradulations you have completed the game!");
            }
            else
            {
                System.Console.WriteLine("Game Over!");
            }

            System.Console.WriteLine("Would you like to play again?");
            System.Console.WriteLine("Type (y) for yes or (n) for no");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Start();
                }
            } while (keyInfo.Key != ConsoleKey.N);


        }

  
        static void initializeRoom()
        {
         
            player.hasCompleteLevel = false;

            switch (player.currentRoom)
            {
                case Destinations.Outside:
                    {
                        currentScene = outsideScene;
                        break;
                    }

                case Destinations.FirstRoom:
                    {
                        currentScene = firstScene; 
                        break;
                    }
                case Destinations.SecondRoom:
                    {
                        currentScene = secondScene;
                        break;
                    }

                case Destinations.BossDoorRoom:
                    {
                        currentScene = bossDoorScene; 
                        break;
                    }

                case Destinations.RightRoom:
                    {
                        currentScene = rightScene;
                        break;
                    }
                case Destinations.WandRoom:
                    {
                        currentScene = wandScene; 
                        break;
                    }
                case Destinations.TopRightRoom:
                    {
                        currentScene = topRightRoom;
                        break;
                    }
                case Destinations.BossKeyRoom:
                    {
                        currentScene = bossKeyScene; 
                        break;
                    }
                case Destinations.BossRoom:
                    {
                        currentScene = bossScene;
                        break;
                    }
                case Destinations.PrincessRoom:
                    {
                        currentScene = princessScene;
                        break;
                    }
                    //World.reDrawMap(); 
            }          
            currentScene.clearScreen();
            currentScene.reset(); 
            currentScene.placePlayer();
            currentScene.draw();
           
        }
    }
}
