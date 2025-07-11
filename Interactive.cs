﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    public class Interactive
    {
        static Random rand = new Random();

        //Player location
        static int x = 25;
        static int y = 25;
        static int ground = 25;

        //Variables needed for jump
        static bool jump = false;


        static double jumpVelocity = 0;
        static double gravity = 0.4;
        static double jumps = 25;


        static bool preJump = false;
        static int preJumpT = 0;
        static int preJumpD = 3;


        //Variables needed for crouch
        static bool crouch = false;
        static bool holdingCrouch = false;
        static int crouchTimer = 0;
        static int crouchDuration = 7; //set crouch time

        static int[] obstacleX = new int[10];
        static int[] obstacleY = new int[10];

        static int[] prevObstacleX = new int[10];
        static int[] prevObstacleY = new int[10];

        static int[] birdX = new int[10];
        static int[] birdY = new int[10];
        static int[] prevBirdX = new int[10];
        static int[] prevBirdY = new int[10];
        static int birdCount = 3;

        static int minSpace = 25;
        static int maxSpace = 60;

        static bool rightArrowPressed = false;
        public static int obstacleSpeed = 1;
        

        static int prevX = x;
        static int prevY = y;

        static string jumpUp =
    "\\o\n" +
    " |\\\n" +
    "/ \\";
        static string person =
                " o\n" +
                "/|\\\n" +
                "/ \\";

        static string preJumpPerson =
               " o\n" +
                "/|\\\n" +
                "< >";

        static string crouched =
            "\n" +
            " ___\\o\n" +
            "/)  | ";

        static string obstacle =
            "  /\\\n" +
            " /  \\\n" +
            "/____\\\n" +
            "  ||";
        static string smallObstacle =
            " /\\\n" +
            "/__\\\n" +
            " ||";
        static string bird =
            " /\\\n" +
            "/__\\\n" +
            "   ";
        //Chaser position
        static int xC = 0;
        static int yC = 21;

        //escape bool
        public static bool exit = false;
        public static bool playerDied = false;


        public static int chaserCooldown = 0;
        public static bool rightArrowHeld = false;
        public static int rightArrowCooldown = 0;


        //Used to see if we should clear previous chaser 
        static bool chaserClearPrev = false;

        //loops while playing
        public static void Calls()
        {
            Console.Clear();
            GameScreen.Clear();

            exit = false;
            playerDied = false;

            Game.minutes = 0;
            Game.seconds = 0;
            Game.isPlaying = true;

            xC = 0; 
            chaserCooldown = 0;
            obstacleSpeed = 1;
            x = 25;
            y = 25;
            preJump = false;
            prevX = 25;
            prevY = 25;



            SpawnObstacle();

            Task task = Game.StartTimer();

            while (!exit)
            {
                Input();
                Update();
                Draw();
                Thread.Sleep(50);
            }

            Game.isPlaying = false;
            if (playerDied)
            {
                Game.GameOver();
                // set isPlaying to false so that the time stops
                
                
            }
            Menu.MainMenu();


        }

        static void SpawnObstacle()
        {
            int start = Console.WindowWidth;

            for (int i = 0; i < obstacleX.Length; i++)
            {
                obstacleX[i] = start;
                obstacleY[i] = ground - 2;
                start += rand.Next(minSpace, maxSpace);
            }

            start = Console.WindowWidth + 10;
            
            //for (int i = 0; i < birdX.Length; i++)
            //{
            //    birdX[i] = start;
            //    birdY[i] = rand.Next(ground - 6, ground - 3); 
            //    start += rand.Next(minSpace, maxSpace); 
            //}
        }

        //player input
        public static void Input()
        {
            
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // if escape is pushed go back to the main menu instantly
                if (key.Key == ConsoleKey.Escape)
                {
                    exit = true;
                    break;
                }

                if (key.Key == ConsoleKey.Spacebar && !jump)
                {
                    preJump = true;

                    preJumpT = preJumpD;

                }
                else if (key.Key == ConsoleKey.C && !jump)
                {
                    crouchTimer = crouchDuration;
                    crouch = true;
                }
                else if (key.Key == ConsoleKey.RightArrow && obstacleSpeed < 5)
                {
                    rightArrowCooldown = 5;
                    obstacleSpeed += 1;

                }
                else if (key.Key == ConsoleKey.LeftArrow && obstacleSpeed > 0)
                {
                    obstacleSpeed -= 1;
                }

            }

        }
        
        //Updates the player location after input is made
        public static void Update()
        {
            //Automatically moves player to the right
            //x++;
            //if (x >= Console.WindowWidth - 1)  //resets at the start when it reaches end of console
            //{
            //    x = 0;
            //}

            

            //if (rightArrowCooldown > 0)
            //{
            //    rightArrowHeld = true;
            //    rightArrowCooldown--;
            //}
            //else
            //{
            //    rightArrowHeld = false;
            //}

            //obstacle movement instead of player
            for (int i = 0; i < obstacleX.Length; i++)
            {
                prevObstacleX[i] = obstacleX[i];
                prevObstacleY[i] = obstacleY[i];
                obstacleX[i] -= obstacleSpeed;
                
                //when it leaves the console by scrolling away, it spawns new one
                if (obstacleX[i] < 0)
                {
                    int furthestX = FurthestObstacle();

                    obstacleX[i] = furthestX + rand.Next(minSpace, maxSpace);
                    obstacleY[i] = ground - 2;
                }

                if (CollisionDetection(obstacleX[i], obstacleY[i]))
                {
                    playerDied = true;
                    exit = true;
                }

            }



            //if (!rightArrowHeld)
            //{
            //    chaserCooldown--;
            //    if (chaserCooldown <= 0)
            //    {
            //        xC++; //chaser position variable
            //        chaserCooldown = 30;
            //    }
            //}
            //else
            //{
            //    //slow chaser cooldown recovery when holding key
            //    chaserCooldown = Math.Min(chaserCooldown + 1, 20);
            //}


            //for (int i = 0; i < birdCount; i++)
            //{
            //    prevBirdX[i] = birdX[i];
            //    prevBirdY[i] = birdY[i];
            //    birdX[i] -= obstacleSpeed;

            //    if (birdX[i] < 0)
            //    {
            //        int furthestBirdX = FurthestBird();
            //        birdX[i] = furthestBirdX + rand.Next(minSpace + 5, maxSpace + 10);
            //        birdY[i] = rand.Next(ground - 6, ground - 3);
            //    }

            //    if (CollisionDetection(birdX[i], birdY[i]))
            //    {
            //        playerDied = true;
            //        exit = true;
            //    }
            //}

            if (preJump)
            {
                //starts 3
                preJumpT--;

                if (preJumpT <= 0) //pre jump crouch ending 
                {
                    preJump = false;
                    jump = true; //start the rest of jump when legs stretched 
                    jumpVelocity = -2;

                }
            }


            if (jump)
            {
                jumps += jumpVelocity;
                jumpVelocity += gravity;

                if (jumps >= ground)
                {
                    jumps = ground;
                    jump = false;
                    jumpVelocity = 0;
                }

                y = (int)jumps;
            }



            if (!jump)
            {
                if (crouchTimer > 0)
                {
                    crouchTimer--;
                    crouch = true;
                    y = ground + 1;
                }
                else
                {
                    crouch = false;
                    y = ground;
                }
            }


        }

        //checks for where the furthest obstacle is and spawns it BEHIND it
        static int FurthestObstacle()
        {
            int max = 0;
            for (int i = 0; i < obstacleX.Length; i++)
            {
                if (obstacleX[i] > max)
                    max = obstacleX[i];
            }
            return max; //bring value into update method in furthestX
        }

        static int FurthestBird()
        {
            int max = 0;
            for (int i = 0; i < birdCount; i++)
            {
                if (birdX[i] > max)
                    max = birdX[i];
            }
            return max;
        }

        //animation part
        public static void Draw()
        {
            // Clear old character
            GameScreen.ClearArea(prevX, prevY, prevX + 6, prevY - 3);

            // Update previous position tracker
            prevX = x;
            prevY = y;


            for (int i = 0; i < obstacleX.Length; i++)
            {
                GameScreen.ClearArea(prevObstacleX[i], prevObstacleY[i] + 3, prevObstacleX[i] + 6, prevObstacleY[i] - 1);
                if (obstacleX[i] >= 0 && obstacleX[i] < Console.WindowWidth)
                {
                    GameScreen.SetStringAt(obstacleX[i], obstacleY[i], smallObstacle);
                }
            }

            //for (int i = 0; i < birdCount; i++)
            //{
            //    if (birdX[i] >= 0 && birdX[i] < Console.WindowWidth)
            //    {
            //        GameScreen.ClearArea(prevBirdX[i], prevBirdY[i] + 2, prevBirdX[i] + 3, prevBirdY[i]);
            //        GameScreen.SetStringAt(birdX[i], birdY[i], bird);
            //    }
            //}



            // Draw new character

            if (preJump)
                GameScreen.SetStringAt(x, y - 2, preJumpPerson);
            else if (!crouch)
            {
                if (jumpVelocity < 0)
                    GameScreen.SetStringAt(x, y - 2, jumpUp);
                else
                    GameScreen.SetStringAt(x, y - 2, person);
            }

            else
                GameScreen.SetStringAt(x, y - 3, crouched);

            Chaser();

            // Draw ground line
            GameScreen.SetRow(new string('_', Console.WindowWidth).ToCharArray(), ground);

            // Render Changes
            GameScreen.Render();
        }

        public static void Chaser()
        {
            string chaser;
            //Displays 1st character
            if (Game.seconds <= 20 && Game.minutes == 0)
            {
                chaser =
                " \\   \\  ,,\n /   /  \\\\\n .---.  //\n(:::::)(_)():\n `---'  \\\\\n \\   \\  //\n /   / '''";
                GameScreen.SetStringAt(xC, yC - 2, chaser);
                chaserClearPrev = true;
            }
            //Displays 2nd chaser
            else if (Game.seconds <= 45 && Game.minutes == 0)
            {
                if (chaserClearPrev == true)
                {
                    GameScreen.ClearArea(0, 29, 17, 12);
                    chaserClearPrev = false;
                }
                chaser =
                "     (()__(()\r\n     /       \\ \r\n    ( /    \\  \\\r\n     \\ o o    /\r\n     (_()_)__/ \\\r\n    / _,==.____ \\\r\n   (   |--|      )\r\n   /\\_.|__|'-.__/\\_\r\n  / (        /     \\\r\n  \\  \\      (      /\r\n   )  '._____)    /\r\n(((____.--(((____/";
                GameScreen.SetStringAt(xC, yC - 7, chaser);
            }
            //Displays 3rd chaser
            else if ((Game.seconds <= 60 && Game.minutes == 0) || (Game.seconds <= 20 && Game.minutes == 1))
            {
                if (chaserClearPrev == false)
                {
                    GameScreen.ClearArea(0, 29, 20, 12);
                    chaserClearPrev = true;
                }
                chaser =
                "    __//\n   / .. \\\n   \\ \\/ /\n`__/    \\\n \\______/\n   |  |";
                GameScreen.SetStringAt(xC, yC - 1, chaser);
            }
            //Displays 4th chaser
            else if (Game.minutes == 1 && Game.seconds <= 40)
            {
                if (chaserClearPrev == true)
                {
                    GameScreen.ClearArea(0, 29, 17, 12);
                    chaserClearPrev = false;
                }
                chaser =
                "      _____\n\t\t\t  / . _<~\n  __/  /\n (_____)_\n(________)";
                GameScreen.SetStringAt(xC, yC, chaser);
            }
            //Displays final chaser
            else if (Game.minutes >= 1)
            {
                if (chaserClearPrev == false)
                {
                    GameScreen.ClearArea(0, 29, 17, 12);
                    chaserClearPrev = true;
                }
                chaser =
                "           _\n   /-----/ 0-\n  / ------/\n\t|| ||";
                GameScreen.SetStringAt(xC, yC, chaser);
            }
        }


        //method to detect collisions
        public static bool CollisionDetection(int obX, int obY)
        {
            int playerX = x+2, playerY = y-2;

            if (obX == playerX && obY == playerY)
            {
                return true;
            }

            for (int i = 1; i <= 3; i++)
            {
                if (obY - i == playerY)
                {
                    for (int j = 0; j <= 3; j++)
                    {
                        if (obX + j == playerX)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}
