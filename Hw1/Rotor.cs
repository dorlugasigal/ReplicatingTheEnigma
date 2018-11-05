using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hw1.Helper;

namespace Hw1
{
    class Rotor : Translator
    {
        int m_ringOffset;
        int m_ringSettings;
        string m_permutation;
        Direction m_rotorDirection;

        public Rotor(int offset, int settings, Direction dir, string permutation) : base()
        {
            m_ringOffset = offset;
            m_rotorDirection = dir;
            m_ringSettings = settings;
            switch (dir)
            {
                case Direction.Forward:
                    m_permutation = permutation;
                    break;
                case Direction.Reverse:
                    StringBuilder reverse = new StringBuilder();
                    reverse.Append(permutation);
                    for (int i = 0; i < 26; i++)
                    {
                        reverse[Helper.ABC.IndexOf(permutation[i])] = Helper.ABC[i];
                    }
                    m_permutation = reverse.ToString();
                    break;
            }
        }
        private int mod(int x)
        {
            return (x % 26 + 26) % 26;
        }
        public new string LetterIndexConverter(string givenLetter)
        {
            string ret = Helper.ABC[mod(Helper.ABC.IndexOf(m_permutation[mod(Helper.ABC.IndexOf(givenLetter[0]) + m_ringOffset - m_ringSettings)]) - m_ringOffset + m_ringSettings)].ToString();
            m_ringOffset++;
            return ret;
        }
    }
}
