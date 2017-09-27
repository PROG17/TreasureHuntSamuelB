using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunt
{
    static class StringExtensions
    {
        static int cursorLeft = -1, cursorTop;


        public static string GetInput(string str, out ConsoleKeyInfo consoleKeyInfo)
        {

            if (cursorLeft == -1)
            {
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
            }
            else if (Console.CursorLeft!=cursorLeft+str.Length || Console.CursorTop!=cursorTop)
            {
                cursorLeft = Console.CursorLeft;
                cursorTop = Console.CursorTop;
            }


            string result = str;
            ConsoleKeyInfo cki;

            cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Backspace)
            {
                if (result.Length > 0)
                    result = result.Substring(0, result.Length - 1);
            }
            else if (cki.Key!=ConsoleKey.Enter && cki.Key!=ConsoleKey.UpArrow && cki.Key != ConsoleKey.DownArrow && cki.Key != ConsoleKey.LeftArrow && cki.Key != ConsoleKey.RightArrow)
            {
                result = result + cki.KeyChar;
            }


            consoleKeyInfo = cki;

            Console.CursorLeft = cursorLeft;
            Console.CursorTop = cursorTop;

            Console.Write(result + " ");

            Console.CursorLeft = cursorLeft;
            Console.CursorTop = cursorTop;

            Console.Write(result);

            return result;
        }

        public static string ReplaceAt(this string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }

    }

}
