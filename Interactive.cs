using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Interactive
    {
        static Random rand = new Random();

        //Player location
        static int x = 18;
        static int y = 10;
        static int ground = 10;

        //Variables needed for jump
        static bool jump = false;
       

        static double jumpVelocity = 0;
        static double gravity = 0.4;
        static double jumps = 10;


        static bool preJump = false;
        static int preJumpT = 0;
        static int preJumpD = 3;

        static bool endJump = false;
        static int endJumpT = 0;
        static int endJumpD = 3;


        //Variables needed for crouch
        static bool crouch = false;
        static bool holdingCrouch = false;
        static int crouchTimer = 0;
        static int crouchDuration = 7; //set crouch time

        static int[] obstacleX = new int[10];
        static int[] obstacleY = new int[10];

        static int[] prevObstacleX = new int[10];
        static int[] prevObstacleY = new int[10];

        static int minSpace = 10;
        static int maxSpace = 30;

        static bool rightArrowPressed = false;
        static int obstacleSpeed = 1;

        static int prevX = x;
        static int prevY = y;
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

        //Chaser position
        static int xC = 0;
        static int yC = 6;

        //escape bool
        static bool exit = false;

        //loops while playing
        public static void Calls()
        {
            exit = false;
            SpawnObstacle();
            Task task = Game.StartTimer();
            while (!exit)
            {
                Input();
                Update();
                Draw();
                Thread.Sleep(50);
            }
            Menu.MainMenu();
        }

        static void SpawnObstacle()
        {
            int start = Console.WindowWidth;

            for (int i = 0; i < obstacleX.Length; i++)
            {
                obstacleX[i] = start;
                obstacleY[i] = ground-3;
                start += rand.Next(minSpace, maxSpace);
            }
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
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    obstacleSpeed = 2;

                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    obstacleSpeed = 1;
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
                    obstacleY[i] = ground-3;
                }

                if (x == obstacleX[i] && y == obstacleY[i])
                {
                    //Game.GameOver();
                }

            }

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

        //animation part
        public static void Draw()
        {
            // Clear old character
            GameScreen.ClearArea(prevX, prevY, prevX+6, prevY-3);

            // Update previous position tracker
            prevX = x;
            prevY = y;


            for (int i = 0; i < obstacleX.Length; i++)
            {
                
                if (obstacleX[i] >= 0 && obstacleX[i] < Console.WindowWidth)
                {
                    GameScreen.ClearArea(prevObstacleX[i], prevObstacleY[i]+3, prevObstacleX[i]+6, prevObstacleY[i]-1);
                    GameScreen.SetStringAt(obstacleX[i], obstacleY[i], obstacle);
                }
            }

            // Draw ground line
            GameScreen.SetRow(new string('_', Console.WindowWidth).ToCharArray(), ground);

            // Draw new character

            if (preJump)
                GameScreen.SetStringAt(x, y - 2, preJumpPerson);
            else if(!crouch)
                GameScreen.SetStringAt(x, y - 2, person);

            else
                GameScreen.SetStringAt(x, y - 3, crouched);
            Chaser();
            // Render Changes
            GameScreen.Render();
        }

        public static void Chaser()
        {
            ////Displays 2nd chaser
            //if ()
            //{
                
            //}
            ////Displays 3rd chaser
            //else if ()
            //{

            //}
            ////Displays 4th chaser
            //else if ()
            //{

            //}
            ////Displays final chaser
            //else if ()
            //{

            //}
            ////Displays 1st chaser
            //else
            //{
            //    string chaser =
            //    " \\   \\  ,,\r\n /   /  \\\\\r\n .---.  //\r\n(:::::)(_)():\r\n `---'  \\\\\r\n \\   \\  //\r\n /   / '''";
            //    // Clear old character
            //    GameScreen.SetStringAt(xC, yC - 2, chaser);
            //}
            string chaser =
            " \\   \\  ,,\n /   /  \\\\\n .---.  //\n(:::::)(_)():\n `---'  \\\\\n \\   \\  //\n /   / '''";
            // Clear old character
            GameScreen.SetStringAt(xC, yC - 2, chaser);
        }


        //method to detect collisions
        //public static void CollisionDetection()
        //{
        //    if (x == obstacleX && y == obstacleY)
        //    {
        //        Game.GameOver();
        //    }

        //}

    }
}
