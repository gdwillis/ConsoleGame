﻿using System;
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
        static bool hasGameEnded;

        static OutsideScene outsideScene;
        static FirstScene firstScene;
        static SecondScene secondScene;

        static Scene currentScene; 
        public static void Start()
        {
            player = new Player();
            player.currentRoom = Destinations.Outside; 
            outsideScene = new OutsideScene(player);
            firstScene = new FirstScene(player);
            secondScene = new SecondScene(player); 
           
            
            
            hasLevelStarted = false;
            hasGameEnded = false;
            while (!hasGameEnded)
            {
                if (!hasLevelStarted)
                {
                    initializeRoom();
                    hasLevelStarted = true;
                }
                if (!player.IsInteracting)
                {
                    
                    currentScene.update();


                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                        //prevents lag effect  
                        while (Console.KeyAvailable) { Console.ReadKey(true); }
                        player.movePlayer(keyPressed);
                        player.attack(keyPressed);
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
        }

        static void EndGame()
        {
            hasGameEnded = true;
            currentScene.clearScreen();
            System.Console.WriteLine("Congradulations you have completed the game!");
            System.Console.Read();
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

                case Destinations.BoosDoorRoom:
                    {
                        break;
                    }

                case Destinations.RightRoom:
                    {
                        break;
                    }
                case Destinations.WandRoom:
                    {
                        break;
                    }
                case Destinations.TopRightRoom:
                    {
                        break;
                    }
                case Destinations.BossKeyRoom:
                    {
                        break;
                    }
                case Destinations.BossRoom:
                    {
                        break;
                    }
                    //World.reDrawMap(); 
            }          
            currentScene.clearScreen();
            currentScene.resetEnemies(); 
            currentScene.placePlayer();
            currentScene.draw();
            player.drawInventory(); 
           
        }
    }
}