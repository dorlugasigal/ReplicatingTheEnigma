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
        #region Properties
        int m_ID;
        int m_notch;
        int m_ringOffset;
        int m_ringSettings;
        string m_permutation;
        string m_reversePermutation;
        //Rotor m_next; 
        #endregion

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
                reverse[Helper.LetterToIndexConverter(permutation[i])] = Helper.IndexToLetterConverter(i);
            }
            m_reversePermutation = reverse.ToString();
        }
        //public void SetNextRotor(Rotor rt)
        //{
        //    m_next = rt;
        //}

        #region Getters

        public int GetID()
        {
            return m_ID;
        }
        public bool isNotch()
        {
            return m_ringOffset == m_notch;
        }
        public void OffsetIncrement()
        {
            if (m_ringOffset == 25) //make sure that the offset is 0-25
            {
                m_ringOffset = 0;
            }
            else
            {
                m_ringOffset++;
            }

        } 
        #endregion

        #region Translation

        public string ForwardTranslation(string givenLetter)
        {
            //ABC(Permutation(input+offset-settings)-offset+settings)
            string ret = Helper.IndexToLetterConverter(modulo(Helper.LetterToIndexConverter(m_permutation[modulo(Helper.LetterToIndexConverter(givenLetter[0]) + m_ringOffset - m_ringSettings)]) - m_ringOffset + m_ringSettings)).ToString();
            return ret;
        }

        public string ReverseTranslation(string givenLetter)
        {
            //ABC(REVERSEPermutation(input+offset-settings)-offset+settings)
            string ret = Helper.IndexToLetterConverter(modulo(Helper.LetterToIndexConverter(m_reversePermutation[modulo(Helper.LetterToIndexConverter(givenLetter[0]) + m_ringOffset - m_ringSettings)]) - m_ringOffset + m_ringSettings)).ToString();
            return ret;
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
        #endregion

        #region ETC

        public override string ToString()
        {
            return "Rotor " + m_ID + ": Permutation: " + m_permutation + ", Settings: " + Helper.IndexToLetterConverter(m_ringSettings) + ", Initial Offset: " + Helper.IndexToLetterConverter(m_ringOffset);
        }

        #endregion

    }
}
