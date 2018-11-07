using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static Hw1.Helper;

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
            if (m_pg != null && m_rf != null && m_rtList != null)
            {
                Console.WriteLine("2. Test Plugboard");
                Console.WriteLine("3. Test Reflector");
                Console.WriteLine("4. Test Rotor");
                Console.WriteLine("5. Run the Enigma");
            }
            Console.WriteLine("0. Exit");
            switch (Helper.ReadKey())
            {

                case 0:
                    Console.Clear();
                    Console.WriteLine("Thank you! good bye");
                    Environment.Exit(0);
                    break;
                case 1:
                    Initizalize();
                    break;
                case 2:
                    if (m_pg != null && m_rf != null)
                    {
                        Test(Components.Plugboard);
                    }
                    break;
                case 3:
                    if (m_pg != null && m_rf != null)
                    {
                        Test(Components.Reflector);
                    }
                    break;
                case 4:
                    if (m_rtList != null && m_rtList.Count > 0)
                    {
                        Test(Components.Rotor);
                    }
                    break;
                case 5:
                    if (m_rtList != null && m_rtList.Count > 0)
                    {
                        StartEnigma();
                    }
                    break;
                default:
                    Initizalize();
                    break;
            }
        }

        private static void StartEnigma()
        {
            Enigma enigma = new Enigma(m_rtList, m_rf, m_pg);
            enigma.Start();
        }

        public static void Initizalize()
        {
            Console.Clear();
            Console.WriteLine("Initializing..." + Environment.NewLine);

            Console.WriteLine("insert a configuration string for the new Plugboard");
            Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
            Console.WriteLine("no more than 10 couples");
            string conString;
            string[] configurationCouples = null;
            do
            {
                Console.Write("==> ");
                conString = Console.ReadLine();
                conString = conString.ToUpper();
                if (!Regex.IsMatch(conString, @"^(?!.*?([A-Z]).*\1)([A-Z]{2})*([ ][A-Z]{2})*$"))
                {
                    Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
                    Console.WriteLine("no more than 10 couples");
                    Console.WriteLine("and a letter cannot appear twice.");
                    Console.WriteLine("please use english letters only");
                }
                else
                {
                    configurationCouples = conString.Trim(new char[] { ' ', ',', '.', '\\', '/', ';' }).Split(' ');
                    if (configurationCouples != null && configurationCouples.Length > 10)
                    {
                        Console.WriteLine("Too much arguments inserted to configuration string");
                        Console.WriteLine("Insert no more than 10 couples");
                    }
                }

            } while (!Regex.IsMatch(conString, @"^(?!.*?([A-Z]).*\1)([A-Z]{2})*([ ][A-Z]{2})*$") || (configurationCouples != null && configurationCouples.Length > 10));

            m_pg = new Plugboard(configurationCouples);
            string extraMessage = conString.Length > 0 ? (" with these couples: " + conString) : string.Empty;
            Console.WriteLine("Plugboard Created successfully " + extraMessage);

            m_rf = new Reflector();
            Console.WriteLine("Reflector Created successfully");

            m_rtList = new List<Rotor>();
            for (int i = 1; i < 6; i++)
            {
                m_rtList.Add(CreateRotor(i));
            }
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            Console.WriteLine("Reflector, Plugboard and all the rotors successfully configured");
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }

        public static Rotor CreateRotor(int rotorNum)
        {
            Console.WriteLine("───────────────────────────────────────────────────────────────────────");

            Console.WriteLine();

            Console.WriteLine("Enter Settings for Rotor " + rotorNum + ":");
            int RotorSettings = Helper.ReadLetter("Settings");
            Console.WriteLine("Enter Initial-Offset for Rotor " + rotorNum + ":");
            int RotorOffset = Helper.ReadLetter("Initial Offset");

            string permutation;
            switch (rotorNum)
            {
                case 1:
                    permutation = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
                    break;
                case 2:
                    permutation = "AJDKSIRUXBLHWTMCQGZNPYFVOE";
                    break;
                case 3:
                    permutation = "BDFHJLCPRTXVZNYEIWGAKMUSQO";
                    break;
                case 4:
                    permutation = "ESOVPZJAYQUIRHXLNFTGKDCMWB";
                    break;
                case 5:
                    permutation = "VZBRGITYUPSDNHLXAWMJQOFECK";
                    break;
                default:
                    permutation = "EKMFLGDQVZNTOWYHXUSPAIBRCJ";
                    break;
            }
            Rotor rt = new Rotor(RotorOffset, RotorSettings, Helper.Direction.Forward, permutation, rotorNum);
            Console.WriteLine("Rotor " + rotorNum + " Created successfully");
            Console.WriteLine();
            return rt;
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
                    ans = m_rf.TranslateLetter(TestString, null);
                    break;
                case Components.Plugboard:
                    ans = m_pg.TranslateLetter(TestString, null);
                    break;
                case Components.Rotor:
                    Console.WriteLine("1. Test Forward Permutation");
                    Console.WriteLine("2. Test Reverse Permutation");
                    switch (Helper.ReadKey())
                    {
                        case 1:
                            ans = m_rtList[int.Parse(rotorNumber) - 1].TranslateLetter(TestString, Direction.Forward);
                            break;
                        case 2:
                            ans = m_rtList[int.Parse(rotorNumber) - 1].TranslateLetter(TestString, Direction.Reverse);
                            break;
                        default:
                            ans = m_rtList[int.Parse(rotorNumber) - 1].TranslateLetter(TestString, Direction.Forward);
                            break;
                    }
                    break;
            }
            Console.WriteLine("Answer==> " + ans);
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }

    }
}
