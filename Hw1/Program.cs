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
        public enum RotorsPermutation
        {
            EKMFLGDQVZNTOWYHXUSPAIBRCJ = 1,
            AJDKSIRUXBLHWTMCQGZNPYFVOE,
            BDFHJLCPRTXVZNYEIWGAKMUSQO,
            ESOVPZJAYQUIRHXLNFTGKDCMWB,
            VZBRGITYUPSDNHLXAWMJQOFECK
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
            else
            {
                Console.WriteLine("----INITIALIZE TO GET 2,3,4,5----");
            }
            Console.WriteLine("6. Task 5");
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
                    else
                    {
                        Console.WriteLine("Plugboard is not initialized yet");
                    }
                    break;
                case 3:
                    if (m_pg != null && m_rf != null)
                    {
                        Test(Components.Reflector);
                    }
                    else
                    {
                        Console.WriteLine("Reflectors is not initialized yet");
                    }

                    break;
                case 4:
                    if (m_rtList != null && m_rtList.Count > 0)
                    {
                        Test(Components.Rotor);
                    }
                    else
                    {
                        Console.WriteLine("Rotors are not initalized yet");
                    }
                    break;
                case 5:
                    if (m_rtList != null && m_rtList.Count > 0)
                    {
                        StartEnigma();
                    }
                    break;
                case 6:
                    Task5();
                    break;

                default:
                    Initizalize();
                    break;
            }
        }

        public static void TypeWriterEffect(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }

        private static void Task5()
        {
            Reflector t6_reflector;
            Plugboard t6_plugboard;
            List<Rotor> t6_rotorList;
            Enigma t5_enigma;
            TypeWriterEffect("In this section i will explain how to solve task 5:");
            TypeWriterEffect("Press any key to start");
            Helper.ReadKey();
            Console.Clear();
            Console.WriteLine("--INCOMING MESSAGE--");
            Thread.Sleep(400);
            Console.Clear();
            Thread.Sleep(100);
            Console.WriteLine("--INCOMING MESSAGE--");
            Thread.Sleep(400);
            Console.Clear();
            Thread.Sleep(100);
            Console.WriteLine("--INCOMING MESSAGE--");
            Thread.Sleep(400);
            Console.Clear();
            TypeWriterEffect("CON MLD \nRNYHP UMDPQ CUAQN LVVSP \nIARKC TTRJQ KCFPT OKRGO  \nZXALD RLPUH AUZSO SZFSU  \nGWFNF DZCUG VEXUU LQYXO  \nTCYRP SYGGZ HQMAG PZDKC  \nKGOJM MYYDD H ");
            TypeWriterEffect("Press a key to analyse");
            Helper.ReadKey();
            Console.WriteLine();
            TypeWriterEffect("Step 1:");
            Thread.Sleep(500);
            TypeWriterEffect("Initialize a Reflector of type B");
            t6_reflector = new Reflector();
            Thread.Sleep(500);
            Console.WriteLine();
            TypeWriterEffect("Step 2:");
            Thread.Sleep(500);
            TypeWriterEffect("Initialize a Plugboard with 29th October's Settings: ZU HL CQ WM OA PY EB TR DN VI");
            Thread.Sleep(500);

            t6_plugboard = new Plugboard("ZU HL CQ WM OA PY EB TR DN VI".Split(' '));
            Console.WriteLine();
            TypeWriterEffect("Step 3:");
            Thread.Sleep(500);
            TypeWriterEffect("Initialize Rotors 2-5-4  with C-O-N as starting offset and Setting to S-I-X");
            Thread.Sleep(500);

            t6_rotorList = new List<Rotor>();
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("N"), Helper.LetterToIndexConverter("X"), ((RotorsPermutation)4).ToString(), 4, 9));
            TypeWriterEffect("Created Rotor 4 with Settings X and initial offset N");
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("O"), Helper.LetterToIndexConverter("I"), ((RotorsPermutation)5).ToString(), 5, 25));
            TypeWriterEffect("Created Rotor 5 with Settings I and initial offset O");
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("C"), Helper.LetterToIndexConverter("S"), ((RotorsPermutation)2).ToString(), 2, 4));
            TypeWriterEffect("Created Rotor 2 with Settings S and initial offset C");
            Thread.Sleep(500);

            TypeWriterEffect("all components are ready!");
            Thread.Sleep(500);
            Console.WriteLine();
            TypeWriterEffect("Step 4:");
            Thread.Sleep(500);
            TypeWriterEffect("Initialize the enigma, with the reflector, the plugboard and the rotors we've created");
            t5_enigma = new Enigma(t6_rotorList, t6_reflector, t6_plugboard);

            Thread.Sleep(500);
            TypeWriterEffect("Enigma Created successfully!");

            Thread.Sleep(500);
            Console.WriteLine();
            TypeWriterEffect("Step 5:");
            Thread.Sleep(500);
            TypeWriterEffect("now lets decrypt MLD to get the proper key.");

            TypeWriterEffect("Answer for MLD ===> " + t5_enigma.Start(1));
            Thread.Sleep(500);
            TypeWriterEffect("So now we use the answer D-O-R as the initial offset, and we create a new enigma with these rotors.");
            Thread.Sleep(500);
            t6_rotorList = new List<Rotor>();
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("R"), Helper.LetterToIndexConverter("X"), ((RotorsPermutation)4).ToString(), 4, 9));
            TypeWriterEffect("Created Rotor 4 with Settings X and initial offset R");
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("O"), Helper.LetterToIndexConverter("I"), ((RotorsPermutation)5).ToString(), 5, 25));
            TypeWriterEffect("Created Rotor 5 with Settings I and initial offset O");
            t6_rotorList.Add(new Rotor(Helper.LetterToIndexConverter("D"), Helper.LetterToIndexConverter("S"), ((RotorsPermutation)2).ToString(), 2, 4));
            TypeWriterEffect("Created Rotor 2 with Settings S and initial offset D");
            t5_enigma = new Enigma(t6_rotorList, t6_reflector, t6_plugboard);
            Thread.Sleep(500);

            Console.WriteLine();
            TypeWriterEffect("Step 6:");
            TypeWriterEffect("Now, our enigma is ready.\nlets decrypt the message! but skip the CON MLD words, and the RNYHP..");

            TypeWriterEffect("Answer ===> \n" + t5_enigma.Start(2));
            Thread.Sleep(500);
            Console.WriteLine();
            TypeWriterEffect("Step 7:");
            Thread.Sleep(500);
            TypeWriterEffect("Write it down with the proper identation and spaces");
            TypeWriterEffect("GROUP SOUTH COMMAND FROM GEN PAULUS X\nSIXTH ARMY IS ENCIRCLED X\nOPERATION BLAU FAILED X\nCOMMENCE RELIEF OPERATION IMMEDIATELY");

            Console.WriteLine();
            Thread.Sleep(500);
            TypeWriterEffect("Thats it!\npress any key to go back to menu");
            Helper.ReadKey();
        }

        private static void StartEnigma()
        {
            Enigma enigma = new Enigma(m_rtList, m_rf, m_pg);
            enigma.Start(0);
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
                conString = conString.Trim(new char[] { ' ', ',', '.', '\\', '/', ';' });
                if (!Regex.IsMatch(conString, @"^(?!.*?([A-Z]).*\1)([A-Z]{2})*([ ][A-Z]{2})*$"))
                {
                    Console.WriteLine("Plugboard configuration string should look like 'XX YY ZZ' etc");
                    Console.WriteLine("no more than 10 couples");
                    Console.WriteLine("and a letter cannot appear twice.");
                    Console.WriteLine("please use english letters only");
                }
                else
                {
                    configurationCouples = conString.Split(' ');
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
            int notch = -1;
            switch (rotorNum)
            {
                case 1:
                    permutation = ((RotorsPermutation)1).ToString();
                    notch = 16;
                    break;
                case 2:
                    permutation = ((RotorsPermutation)2).ToString();
                    notch = 4;
                    break;
                case 3:
                    permutation = ((RotorsPermutation)3).ToString();
                    notch = 21;
                    break;
                case 4:
                    permutation = ((RotorsPermutation)4).ToString();
                    notch = 9;
                    break;
                case 5:
                    permutation = ((RotorsPermutation)5).ToString();
                    notch = 25;
                    break;
                default:
                    permutation = ((RotorsPermutation)1).ToString();
                    break;
            }
            Rotor rt = new Rotor(RotorOffset, RotorSettings, permutation, rotorNum, notch);
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
