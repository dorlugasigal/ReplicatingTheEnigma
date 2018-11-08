using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Enigma
    {
        List<Rotor> m_rotorList;
        Reflector m_reflector;
        Plugboard m_plugboard;

        public Enigma(List<Rotor> rotorList, Reflector reflector, Plugboard plugboard)
        {
            Console.Clear();
            int num;
            m_reflector = reflector;
            m_plugboard = plugboard;
            m_rotorList = new List<Rotor>();
            List<int> chosed = new List<int>();
            List<Rotor> tempList = new List<Rotor>();
            tempList.AddRange(rotorList.ToList());

            Console.WriteLine("Initializing the Enigma, please choose 3 rotors you would like to use:");
            do
            {
                if (tempList.Count > 0)
                {
                    Console.WriteLine("Rotors you choosed: " + String.Join(" , ", chosed.ToArray()));
                }
                switch (m_rotorList.Count)
                {
                    case 0:
                        Console.WriteLine("Choose the right-most rotor");
                        break;
                    case 1:
                        Console.WriteLine("Choose the middle rotor");
                        break;
                    case 2:
                        Console.WriteLine("Choose the left-most rotor");
                        break;
                }
                Console.WriteLine("Available Rotors: ");
                for (int i = 0; i < tempList.Count; i++)
                {
                    Console.WriteLine(i + 1 + ". " + tempList[i].ToString());
                }

                Console.Write("==> ");
                num = Helper.ReadKey();
                if (num > 0 && num <= tempList.Count)
                {
                    int rotorID = tempList[num - 1].GetID();
                    if (chosed.Contains(rotorID))
                    {
                        Console.Clear();

                        Console.WriteLine("this rotor already in the list, choose another one.");
                        Console.WriteLine("Available Rotors: ");
                        for (int i = 0; i < tempList.Count; i++)
                        {
                            Console.WriteLine(tempList[i].ToString());
                        }
                    }
                    else
                    {
                        Console.Clear();
                        chosed.Add(num);
                        m_rotorList.Add(tempList[num - 1]);
                        tempList.Remove(tempList[num - 1]);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input, select the number of the row");
                }

            } while (m_rotorList.Count != 3);
            m_rotorList.AddRange(tempList.ToArray());
            m_rotorList[0].SetNextRotor(m_rotorList[1]);
            m_rotorList[1].SetNextRotor(m_rotorList[2]);


            Console.WriteLine("The Enigma successfully configured with the following rotors:");
            Console.WriteLine("Right  Rotor: " + m_rotorList[0].ToString());
            Console.WriteLine("Middle Rotor: " + m_rotorList[1].ToString());
            Console.WriteLine("Left   Rotor: " + m_rotorList[2].ToString());
            Console.WriteLine("Press any key to start the machine");
            Console.ReadKey();
        }

        internal void Start()
        {
            Console.WriteLine("Enter a word to Encrypt: ");
            var x = Console.ReadLine();
            x = x.ToUpper();
            Console.Write("==>  ");
            for (int character = 0; character < x.Length; character++)
            {

                if (m_rotorList[0].isNotch() || m_rotorList[1].isNotch())
                {
                    if (m_rotorList[1].isNotch())
                    {
                        m_rotorList[2].OffsetIncrement();
                    }
                    m_rotorList[1].OffsetIncrement();
                }
                m_rotorList[0].OffsetIncrement();
                var a = m_plugboard.TranslateLetter(x.ElementAt(character).ToString(), Helper.Direction.Forward);
                var b = m_rotorList[0].TranslateLetter(a, Helper.Direction.Forward);
                var c = m_rotorList[1].TranslateLetter(b, Helper.Direction.Forward);
                var d = m_rotorList[2].TranslateLetter(c, Helper.Direction.Forward);
                var e = m_reflector.TranslateLetter(d, Helper.Direction.Forward);
                var f = m_rotorList[2].TranslateLetter(e, Helper.Direction.Reverse);
                var g = m_rotorList[1].TranslateLetter(f, Helper.Direction.Reverse);
                var h = m_rotorList[0].TranslateLetter(g.ToString(), Helper.Direction.Reverse);
                var i = m_plugboard.TranslateLetter(h.ToString(), Helper.Direction.Reverse);

                //Console.WriteLine("m_plugboard.TranslateLetter(" + x[0].ToString() + ", Helper.Direction.Forward):     " + a);
                //Console.WriteLine("m_rotorList[0].TranslateLetter(" + a + ", Helper.Direction.Forward):   " + b);
                //Console.WriteLine("m_rotorList[1].TranslateLetter(" + b + ", Helper.Direction.Forward):    " + c);
                //Console.WriteLine("m_rotorList[2].TranslateLetter(" + c + ", Helper.Direction.Forward):     " + d);
                //Console.WriteLine("m_reflector.TranslateLetter(" + d + ", Helper.Direction.Forward):         " + e);
                //Console.WriteLine("m_rotorList[2].TranslateLetter(" + e + ", Helper.Direction.Reverse):       " + f);
                //Console.WriteLine("m_rotorList[1].TranslateLetter(" + f + ", Helper.Direction.Reverse):        " + g);
                //Console.WriteLine("m_rotorList[0].TranslateLetter(" + g + ", Helper.Direction.Reverse):         " + h);
                //Console.WriteLine("m_plugboard.TranslateLetter(" + h + ".ToString(), Helper.Direction.Reverse);  " + i);


                Console.Write(i);
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }
    }
}
