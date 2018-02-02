
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManagerTrue
{
    class Program
    {

        



        static void Main(string[] args)
        {
            
            Console.SetWindowSize(100, 58);
            FAR far = new FAR(@"C:\Users\Santa sheikh\Desktop\Санжар");
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(System.DateTime.Now);

            bool quit = false;
           
            while (!quit)
            {
                far.Draw();
                
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Enter:
                        far.Process(pressedKey);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
