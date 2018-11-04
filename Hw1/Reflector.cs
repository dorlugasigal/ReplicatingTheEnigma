using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Reflector : Translator
    {
        private string m_configuration;

        public Reflector() : base()
        {
            m_configuration = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        }

        public new string LetterIndexConverter(string givenMessage)
        {
            givenMessage.ToUpper();        
            var result = new string(givenMessage.Select(c => m_configuration[Helper.ABC.IndexOf(c)]).ToArray());
            return result.ToString();
        }
    }
}
