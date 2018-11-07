using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hw1
{
    public static class Helper
    {
        public static string ABC = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public enum Direction
        {
            Forward,
            Reverse
        }
        public static int LetterToIndexConverter(string letter)
        {
            return ABC.IndexOf(letter.ToUpper());
        }
        public static int ReadLetter(string objective)
        {
            while (true)
            {
                Console.Write("==> ");
                int num;
                var read = Console.ReadLine().ToUpper();
                bool flag = int.TryParse(read, out num);
                if (flag && num >= 1 && num <= 26)
                {
                    return num - 1;
                }
                if (!Regex.IsMatch(read, @"^[A-Z]{1}$"))
                {
                    Console.WriteLine(objective + " should be an upper letter A-Z or a number between 1-26");
                }
                else
                {
                    return LetterToIndexConverter(read);
                }
            }
        }
        public static int ReadKey()
        {
            var x = Console.ReadKey();
            Console.WriteLine();
            switch (x.Key)
            {

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    return 0;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    return 1;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    return 2;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    return 3;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    return 4;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    return 5;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    return 6;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    return 7;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    return 8;
                case ConsoleKey.D9:
                case ConsoleKey.NumPad9:
                    return 9;
                default:
                    return -1;
            }
        }
    }
}
