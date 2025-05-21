using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Interactive
    {
        static Random rand = new Random();

        //Player location
        static int x = 5;
        static int y = 10;
        static int ground = 10;

        //Variables needed for jump
        static bool jump = false;
        static int jumpHeight = 5;
        static int jumpProgress = 0;

        //Variables needed for crouch
        static bool crouch = false;
        static bool holdingCrouch = false;
        static int crouchTimer = 0;
        static int crouchDuration = 7; //set crouch time

        static int[] obstacleX = new int[10];
        static int[] obstacleY = new int[10];

        static int minSpace = 10;
        static int maxSpace = 30;

        static bool rightArrowPressed = false;
        static int obstacleSpeed = 1;

        //loops while playing
        public static void Calls()
        {

            SpawnObstacle();

            while (true)
            {
                Input();
                Update();
                Draw();
                Thread.Sleep(50);
            }
        }

        static void SpawnObstacle()
        {
            int start = Console.WindowWidth;

            for (int i = 0; i < obstacleX.Length; i++)
            {
                obstacleX[i] = start;
                obstacleY[i] = ground;
                start += rand.Next(minSpace, maxSpace);
            }
        }

        //player input
        public static void Input()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Spacebar && !jump && crouchTimer == 0)
                {
                    jump = true;
                    jumpProgress = jumpHeight;
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
                obstacleX[i] -= obstacleSpeed;

                //when it leaves the console by scrolling away, it spawns new one
                if (obstacleX[i] < 0)
                {
                    int furthestX = FurthestObstacle();

                    obstacleX[i] = furthestX + rand.Next(minSpace, maxSpace);
                    obstacleY[i] = ground;
                }

                if (x == obstacleX[i] && y == obstacleY[i])
                {
                    Game.GameOver();
                }

            }


            if(jump)
            {
                y = ground - jumpProgress; //starts at 5, goes down slowly
                jumpProgress--;

                //at the ground, resets ground back to 10 
                if (y >= ground)
                {
                    y = ground;
                    jump = false;
                }
            }

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
            string person =
                " o\n" +
                "/|\\\n" +
                "/ \\";

            string crouched =
                "\n" +
                " ___\\o\n" +
                "/)  | ";

            GameScreen.ClearArea(x, y, x + 20, y - 20);
            if (!crouch) GameScreen.SetStringAt(x, y-3, person);
            else GameScreen.SetStringAt(x, y-3, crouched);
            //GameScreen.Clear('#');
            GameScreen.SetRow(new string('_', Console.WindowWidth).ToCharArray(), ground);

            
            GameScreen.Render();

            //Console.CursorVisible = false;
            //Console.Clear();

            //Console.SetCursorPosition(x, y);

            //This is to draw player
            Console.Write(jump ? "O" : crouch ? "-" : "O");

            //if (jump)
            //{
            //    Console.Write("O");
            //}
            //else if (crouch)
            //{
            //    Console.Write("-"); 
            //}
            //else
            //{
            //    Console.Write("O"); 
            //}

            for (int i = 0; i < obstacleX.Length; i++)
            {
                if (obstacleX[i] >= 0 && obstacleX[i] < Console.WindowWidth)
                {
                    Console.SetCursorPosition(obstacleX[i], obstacleY[i]);
                    Console.Write("#");
                }
            }

            //ground drawn
            Console.SetCursorPosition(0, ground + 2);
            Console.Write(new string('_', Console.WindowWidth));
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
