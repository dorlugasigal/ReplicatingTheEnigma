using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Enigma
    {
        #region Properties
        private List<Rotor> m_rotorsList;
        private Reflector m_reflector;
        private Plugboard m_plugboard;
        #endregion

        public Enigma(List<Rotor> rotorsList, Reflector reflector, Plugboard plugboard)
        {
            if (rotorsList.Count != 3)
            {
                Console.Clear();
            }
            int num;
            m_reflector = reflector;
            m_plugboard = plugboard;
            m_rotorsList = new List<Rotor>();

            if (rotorsList.Count == 3)//task 5
            {
                m_rotorsList.Add(rotorsList[0]);
                m_rotorsList.Add(rotorsList[1]);
                m_rotorsList.Add(rotorsList[2]);
                //m_rotorList[0].SetNextRotor(m_rotorList[1]);
                //m_rotorList[1].SetNextRotor(m_rotorList[2]);
                return;
            }

            List<int> choosed = new List<int>();
            List<Rotor> tempList = new List<Rotor>();
            tempList.AddRange(rotorsList.ToList());
            Console.WriteLine("Initializing the Enigma, please choose 3 rotors you would like to use:");
            do
            {
                if (tempList.Count > 0)
                {
                    Console.WriteLine("Rotors you choosed: " + String.Join(" , ", choosed.ToArray()));
                }
                switch (m_rotorsList.Count)
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
                    if (choosed.Contains(rotorID))
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
                        choosed.Add(num);
                        m_rotorsList.Add(tempList[num - 1]);
                        tempList.Remove(tempList[num - 1]);
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input, select the number of the row");
                }

            } while (m_rotorsList.Count != 3);
            m_rotorsList.AddRange(tempList.ToArray());
            //m_rotorList[0].SetNextRotor(m_rotorList[1]);
            //m_rotorList[1].SetNextRotor(m_rotorList[2]);


            Console.WriteLine("The Enigma successfully configured with the following rotors:");
            Console.WriteLine("Right  Rotor: " + m_rotorsList[0].ToString());
            Console.WriteLine("Middle Rotor: " + m_rotorsList[1].ToString());
            Console.WriteLine("Left   Rotor: " + m_rotorsList[2].ToString());
            Console.WriteLine("Press any key to start the machine");
            Console.ReadKey();
        }

        private void OffsetHandler()
        {
            if (m_rotorsList[0].isNotch() || m_rotorsList[1].isNotch())
            {
                if (m_rotorsList[1].isNotch())
                {
                    m_rotorsList[2].OffsetIncrement();
                }
                m_rotorsList[1].OffsetIncrement();
            }
            m_rotorsList[0].OffsetIncrement();

        }

        public string Start(int t5)
        {
            string x;
            StringBuilder answer = new StringBuilder();
            if (t5 == 0)// not task 5
            {
                Console.WriteLine("Enter a word to Encrypt: ");
                x = Helper.ReadSentence("Sentence to Translate");
            }
            else //task 5
            {
                if (t5 == 1)
                {
                    x = "MLD";
                }
                else if (t5 == 2)
                {
                    x = "UMDPQ CUAQN LVVSP \nIARKC TTRJQ KCFPT OKRGO  \nZXALD RLPUH AUZSO SZFSU  \nGWFNF DZCUG VEXUU LQYXO  \nTCYRP SYGGZ HQMAG PZDKC  \nKGOJM MYYDD H ";
                }
                else
                {
                    x = "ENIGMA";
                }
            }
            if (t5 != 3)
            {
                Console.Write("==>  ");
            }
            for (int character = 0; character < x.Length; character++)
            {
                if (x.ElementAt(character) == ' ')
                {
                    answer.Append(' ');
                    continue;
                }
                if (x.ElementAt(character) == '\n')
                {
                    answer.Append('\n');
                    continue;
                }
                OffsetHandler();

                var a = m_plugboard.TranslateLetter(x.ElementAt(character).ToString(), Helper.Direction.Forward);
                var b = m_rotorsList[0].TranslateLetter(a, Helper.Direction.Forward);
                var c = m_rotorsList[1].TranslateLetter(b, Helper.Direction.Forward);
                var d = m_rotorsList[2].TranslateLetter(c, Helper.Direction.Forward);
                var e = m_reflector.TranslateLetter(d, Helper.Direction.Forward);
                var f = m_rotorsList[2].TranslateLetter(e, Helper.Direction.Reverse);
                var g = m_rotorsList[1].TranslateLetter(f, Helper.Direction.Reverse);
                var h = m_rotorsList[0].TranslateLetter(g.ToString(), Helper.Direction.Reverse);
                var i = m_plugboard.TranslateLetter(h.ToString(), Helper.Direction.Reverse);

                //for testing
                //Console.WriteLine("m_plugboard.TranslateLetter(" + x[0].ToString() + ", Helper.Direction.Forward):     " + a);
                //Console.WriteLine("m_rotorList[0].TranslateLetter(" + a + ", Helper.Direction.Forward):   " + b);
                //Console.WriteLine("m_rotorList[1].TranslateLetter(" + b + ", Helper.Direction.Forward):    " + c);
                //Console.WriteLine("m_rotorList[2].TranslateLetter(" + c + ", Helper.Direction.Forward):     " + d);
                //Console.WriteLine("m_reflector.TranslateLetter(" + d + ", Helper.Direction.Forward):         " + e);
                //Console.WriteLine("m_rotorList[2].TranslateLetter(" + e + ", Helper.Direction.Reverse):       " + f);
                //Console.WriteLine("m_rotorList[1].TranslateLetter(" + f + ", Helper.Direction.Reverse):        " + g);
                //Console.WriteLine("m_rotorList[0].TranslateLetter(" + g + ", Helper.Direction.Reverse):         " + h);
                //Console.WriteLine("m_plugboard.TranslateLetter(" + h + ".ToString(), Helper.Direction.Reverse);  " + i);
                answer.Append(i);
            }
            if (t5 == 0) //task 5
            {
                Console.WriteLine(answer);
                Console.WriteLine();
                Console.WriteLine("Press any key to go back to menu");
                Console.ReadKey();
            }
            return answer.ToString();
        }
    }
}
