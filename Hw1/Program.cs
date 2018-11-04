using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Hw1
{
    class Program
    {
        public static Plugboard m_pg;
        public static Reflector m_rf;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Dor Lugasi home work #1 solution.");
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Initialize");
            if (m_pg != null && m_rf != null)
            {
                Console.WriteLine("2. Test Plugboard");
                Console.WriteLine("3. Test Reflector");
            }
            Console.WriteLine("0. Exit");
            var x = Console.ReadKey();
            switch (x.Key)
            {

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Console.Clear();
                    Console.WriteLine("Thank you! good bye");
                    Environment.Exit(0);
                    break;
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:

                    Initizalize();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    if (m_pg != null && m_rf != null)
                    {
                        TestPlugboard();
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    if (m_pg != null && m_rf != null)
                    {
                        TestReflector();
                    }
                    break;
                default:
                    Initizalize();
                    break;
            }
        }

        public static void Initizalize()
        {
            Console.Clear();
            Console.WriteLine("Initializing..." + Environment.NewLine);

            Console.WriteLine("insert a configuration string for the new Plugboard");
            Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
            Console.WriteLine("no more than 10 couples");
            string conString;
            do
            {
                Console.Write("==> ");
                conString = Console.ReadLine();
                if (!Regex.IsMatch(conString, @"^[a-zA-Z\s]+$"))
                {
                    Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
                    Console.WriteLine("no more than 10 couples");
                    Console.WriteLine("please use english letters only");
                }

            } while (!Regex.IsMatch(conString, @"^[a-zA-Z\s]+$"));

            Console.WriteLine("Creating a new Plugboard");
            m_pg = new Plugboard(conString.Trim(new char[] { ' ', ',', '.', '\\', '/' }));
            Console.WriteLine("Created successfully");

            Console.WriteLine("Creating a new Reflector");
            m_rf = new Reflector();
            Console.WriteLine("Created successfully");

            Console.WriteLine("Reflector and Plugboard succesfully configured");
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }

        private static void TestPlugboard()
        {
            Console.Clear();
            Console.WriteLine("Insert a Text to test the Plugboard");
            string TestString;
            do
            {
                Console.Write("==> ");
                TestString = Console.ReadLine();
                if (!Regex.IsMatch(TestString, @"^[a-zA-Z\s]+$"))
                {
                    Console.WriteLine("please use english letters only");
                }

            } while (!Regex.IsMatch(TestString, @"^[a-zA-Z\s]+$"));

            Console.WriteLine("Answer==> " + m_pg.LetterIndexConverter(TestString));
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }
        private static void TestReflector()
        {
            Console.Clear();
            Console.WriteLine("Insert a text to test the Reflector");
            string TestString;
            do
            {
                Console.Write("==> ");
                TestString = Console.ReadLine();
                if (!Regex.IsMatch(TestString, @"^[a-zA-Z\s]+$"))
                {
                    Console.WriteLine("please use english letters only");
                }

            } while (!Regex.IsMatch(TestString, @"^[a-zA-Z\s]+$"));
            Console.WriteLine("Answer==> " + m_rf.LetterIndexConverter(TestString));
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }
    }
}
