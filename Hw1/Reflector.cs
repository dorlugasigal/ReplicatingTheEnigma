using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hw1.Helper;

namespace Hw1
{
    class Reflector : ITranslator
    {
        private string m_configuration;

        public Reflector()
        {
            m_configuration = "YRUHQSLDPXNGOKMIEBFZCWVJAT";
        }

        public string TranslateLetter(string givenMessage,Direction ? dir)
        {
            givenMessage.ToUpper();        
            var result = new string(givenMessage.Select(c => m_configuration[Helper.ABC.IndexOf(c)]).ToArray());
            return result.ToString();
        }
    }
}
