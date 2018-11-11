using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hw1
{
    public static class Helper
    {
        #region Properties and Singelton Getters for ABC and indexing
        public enum Direction
        {
            Forward,
            Reverse
        }
        //private static string ABCD = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Dictionary<int, char> ABC_Dictionary;
        public static Dictionary<int, char> getABC //singelton ABC
        {
            get
            {
                if (ABC_Dictionary == null)
                {
                    ABC_Dictionary = new Dictionary<int, char>();

                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        int key = c - 'A';
                        ABC_Dictionary.Add(key, c);
                    }
                }
                return ABC_Dictionary;
            }
        }
        private static Dictionary<char, int> ABCIndex_Dictionary;
        public static Dictionary<char, int> getABCIndex
        {
            /*
                because the letters and the index are unique and you insist that:
                "there should be no routine use of string search operations ",
                i made two dictionaries that you can use table lookups instead of "IndexOf".
                although with string length like this (26), the time (and space) complexity is the same.
            */
            get
            {
                if (ABCIndex_Dictionary == null)
                {
                    ABCIndex_Dictionary = new Dictionary<char, int>();
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        int key = c - 'A';
                        ABCIndex_Dictionary.Add(c,key);
                    }
                }
                return ABCIndex_Dictionary;
            }
        }
        public static int LetterToIndexConverter(char letter)
        {
            return getABCIndex[letter];
        }
        public static char IndexToLetterConverter(int index)
        {
            return getABC[index];
            //return ABC.IndexOf(letter.ToUpper()); 
        }

        #endregion

        #region Read from keyboard

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
                    return LetterToIndexConverter(read[0]);
                }
            }
        }
        public static string ReadSentence(string objective)
        {
            while (true)
            {
                Console.Write("==> ");
                var read = Console.ReadLine().ToUpper();
              
                if (!Regex.IsMatch(read, @"^[A-Za-z ]+$"))
                {
                    Console.WriteLine(objective + " should be English words divided by space");
                }
                else
                {
                    return read;
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

        #endregion

        #region ETC

        public static void TypeWriterEffect(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        public static int modulo(int x)
        {
            return (x % 26 + 26) % 26;
        }

        #endregion
    }
}
