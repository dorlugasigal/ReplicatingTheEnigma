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
        public static List<Rotor> m_rtList;
        public enum Components
        {
            Reflector, Plugboard, Rotor
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Dor Lugasi home work #1 solution.");
            Console.WriteLine();
            Console.WriteLine("1. Initialize");
            if (m_pg != null && m_rf != null)
            {
                Console.WriteLine("2. Test Plugboard");
                Console.WriteLine("3. Test Reflector");
                Console.WriteLine("4. Test Rotor");
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
                        Test(Components.Plugboard);
                    }
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    if (m_pg != null && m_rf != null)
                    {

                        Test(Components.Reflector);
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    if (m_rtList != null && m_rtList.Count > 0)
                    {
                        Test(Components.Rotor);
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
                conString = Console.ReadLine().ToUpper();
                if (!Regex.IsMatch(conString, @"^(?!.*?([A-Z]).*\1)([A-Z]{2})([ ][A-Z]{2})*$"))
                {
                    Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
                    Console.WriteLine("no more than 10 couples");
                    Console.WriteLine("and a letter cannot appear twice.");
                    Console.WriteLine("please use english letters only");
                }

            } while (!Regex.IsMatch(conString, @"^(?!.*?([A-Z]).*\1)([A-Z]{2})([ ][A-Z]{2})*$"));

            Console.WriteLine("Creating a new Plugboard");
            m_pg = new Plugboard(conString.Trim(new char[] { ' ', ',', '.', '\\', '/' }));
            Console.WriteLine("Created successfully");

            Console.WriteLine("Creating a new Reflector");
            m_rf = new Reflector();
            Console.WriteLine("Created successfully");

            m_rtList = new List<Rotor>();
            Rotor rt1 = new Rotor(1, 1, Helper.Direction.Forward, "EKMFLGDQVZNTOWYHXUSPAIBRCJ");
            Rotor rt2 = new Rotor(1, 1, Helper.Direction.Forward, "AJDKSIRUXBLHWTMCQGZNPYFVOE");
            Rotor rt3 = new Rotor(1, 1, Helper.Direction.Forward, "BDFHJLCPRTXVZNYEIWGAKMUSQO");
            Rotor rt4 = new Rotor(1, 1, Helper.Direction.Forward, "ESOVPZJAYQUIRHXLNFTGKDCMWB");
            Rotor rt5 = new Rotor(26, 5, Helper.Direction.Reverse, "VZBRGITYUPSDNHLXAWMJQOFECK");

            m_rtList.Add(rt1);
            m_rtList.Add(rt2);
            m_rtList.Add(rt3);
            m_rtList.Add(rt4);
            m_rtList.Add(rt5);

            Console.WriteLine("Reflector and Plugboard succesfully configured");
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }



        private static void Test(Components comp)
        {
            Console.Clear();
            string rotorNumber = string.Empty;
            if (comp == Components.Rotor)
            {
                Console.WriteLine("Which Rotor would you like to test? (1-5)");
                do
                {
                    Console.Write("==> ");
                    rotorNumber = Console.ReadLine().ToUpper();
                    if (!Regex.IsMatch(rotorNumber, @"^[1-5]+$"))
                    {
                        Console.WriteLine("please enter a number between 1-5");
                    }

                } while (!Regex.IsMatch(rotorNumber, @"^[1-5]+$"));
            }
            Console.WriteLine("Insert a letter to test the " + comp.ToString());
            string TestString;
            do
            {
                Console.Write("==> ");
                TestString = Console.ReadLine().ToUpper();
                if (!Regex.IsMatch(TestString, @"^[a-zA-Z]{1}$"))
                {
                    Console.WriteLine("please use english letters only");
                }

            } while (!Regex.IsMatch(TestString, @"^[a-zA-Z]{1}$"));
            string ans = string.Empty;
            switch (comp)
            {
                case Components.Reflector:
                    ans = m_rf.LetterIndexConverter(TestString);
                    break;
                case Components.Plugboard:
                    ans = m_pg.LetterIndexConverter(TestString);
                    break;
                case Components.Rotor:
                    ans = m_rtList[int.Parse(rotorNumber)-1].LetterIndexConverter(TestString);
                    break;
            }
            Console.WriteLine("Answer==> " + ans);
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }
    }
}
