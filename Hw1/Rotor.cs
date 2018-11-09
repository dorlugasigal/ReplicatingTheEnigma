using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hw1.Helper;

namespace Hw1
{
    class Rotor : ITranslator
    {
        int m_ID;
        int m_notch;
        int m_ringOffset;
        int m_ringSettings;
        string m_permutation;
        string m_reversePermutation;
        Rotor m_next;

        public Rotor(int offset, int settings, string permutation, int number, int notch)
        {
            m_ID = number;
            m_notch = notch;
            m_ringOffset = offset;
            m_ringSettings = settings;

            m_permutation = permutation;
            StringBuilder reverse = new StringBuilder();
            reverse.Append(permutation);
            for (int i = 0; i < 26; i++)
            {
                reverse[Helper.ABC.IndexOf(permutation[i])] = Helper.ABC[i];
            }
            m_reversePermutation = reverse.ToString();
        }
        private int mod(int x)
        {
            return (x % 26 + 26) % 26;
        }

        public void SetNextRotor(Rotor rt)
        {
            m_next = rt;
        }

        public string ForwardTranslation(string givenLetter)
        {
            string ret = Helper.ABC[mod(Helper.ABC.IndexOf(m_permutation[mod(Helper.ABC.IndexOf(givenLetter[0]) + m_ringOffset - m_ringSettings)]) - m_ringOffset + m_ringSettings)].ToString();
            return ret;
        }
        public bool isNotch()
        {
            return m_ringOffset == m_notch;
        }

        public string ReverseTranslation(string givenLetter)
        {
            string ret = Helper.ABC[mod(Helper.ABC.IndexOf(m_reversePermutation[mod(Helper.ABC.IndexOf(givenLetter[0]) + m_ringOffset - m_ringSettings)]) - m_ringOffset + m_ringSettings)].ToString();
            return ret;
        }

        public void OffsetIncrement()
        {
            if (m_ringOffset == 25)
            {
                m_ringOffset = 0;
            }
            else
            {
                m_ringOffset++;
            }

        }

        public string TranslateLetter(string givenMessage, Direction? dir)
        {
            switch (dir)
            {
                case Direction.Forward:
                    return ForwardTranslation(givenMessage);
                case Direction.Reverse:
                    return ReverseTranslation(givenMessage);
                default:
                    return null;
            }
        }
        public override string ToString()
        {
            return "Rotor " + m_ID + ": Permutation: " + m_permutation + ", Settings: " + Helper.ABC[m_ringSettings] + ", Initial Offset: " + Helper.ABC[m_ringOffset];
        }
        public int GetID()
        {
            return m_ID;
        }

    }
}
