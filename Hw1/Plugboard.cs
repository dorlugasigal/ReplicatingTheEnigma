using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Plugboard : Translator
    {
        private Dictionary<char, char> m_configuration;


        public Plugboard(string configuration) : base()
        {            
            var configurationCouples = configuration.ToUpper().Split(' ');
            if (configurationCouples != null && configurationCouples.Length > 10)
            {
                Console.WriteLine("Too much arguments inserted to configuration string");
                return;
            }
            m_configuration = new Dictionary<char, char>();
            foreach (var item in configurationCouples)
            {
                m_configuration.Add(item[0], item[1]);
                m_configuration.Add(item[1], item[0]);
            }
        }

        public new string LetterIndexConverter(string givenMessage)
        {
            givenMessage= givenMessage.ToUpper();
            var result = new string(givenMessage.Select(c => (m_configuration.Keys.Contains(c) ? m_configuration[c] : c )).ToArray());
            return result.ToString();       
        }
}
    }
