using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegallyDistinctDino
{
    class Interactive_game
    {
        static int x = 0;
        static int y = 10;
        static int ground = 10;

        static bool jump = false;
        static int jumpHeight = 5;
        static int jumpProgress = 0;

        static bool crouch = false;

        static void calls()
        {
            Input();
            Update();
        }

        //player input
        static void Input()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true); //read key

                if (key.Key == ConsoleKey.Spacebar)
                {
                    jump = true;
                    jumpProgress = jumpHeight;
                }
                else if (key.Key == ConsoleKey.C)
                {
                    crouch = true;
                }
                
            }
        
        }
        
        static void Update()
        {
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
        }

    }
}
