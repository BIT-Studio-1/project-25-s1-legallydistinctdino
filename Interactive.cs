using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    internal class Interactive
    {
        static int x = 0;
        static int y = 10;
        static int ground = 10;

        static bool jump = false;
        static int jumpHeight = 5;
        static int jumpProgress = 0;

        static bool crouch = false;
        static bool holdingCrouch = false;
        static int crouchTimer = 0;
        static int crouchDuration = 10;

        public static void Calls()
        {
            while (true)
            {
                Input();
                Update();
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
        
        public static void Update()
        {

            x++;
            if (x >= Console.WindowWidth - 1)
            {
                x = 0;
            }

            if (jump)
            {
                y = ground - jumpProgress;
                jumpProgress--;

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

            if (!jump && !crouch)
            {
                y = ground;
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

        }

    }
}
