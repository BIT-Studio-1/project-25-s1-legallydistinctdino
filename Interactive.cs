using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Interactive
    {
        //Player location
        static int x = 0;
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
        static int crouchDuration = 10; //set crouch time

        //loops while playing
        public static void Calls()
        {
            while (true)
            {
                Input();
                //Update();
                Draw();
                Thread.Sleep(50);
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
            }

        }

        //Updates the player location after input is made
        public static void Update()
        {
            //Automatically moves player to the right
            x++;
            if (x >= Console.WindowWidth - 1)  //resets at the start when it reaches end of console
            {
                x = 0;
            }

            if (jump)
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
            }
            else
            {
                crouch = false;
            }

        }

        //animation part
        public static void Draw()
        {
            Console.Clear();

            Console.SetCursorPosition(x, y);

            if (jump)
            {
                Console.Write("O");
            }
            else if (crouch)
            {
                Console.Write("-"); 
            }
            else
            {
                Console.Write("O"); 
            }

            //ground drawn
            Console.SetCursorPosition(0, ground + 1);
            Console.Write(new string('_', Console.WindowWidth));
        }

    }
}
