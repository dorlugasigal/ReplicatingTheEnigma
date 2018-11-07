using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hw1.Helper;

namespace Hw1
{
    class Plugboard : ITranslator
    {
        private Dictionary<char, char> m_configuration;

        public Plugboard(string[] configurationCouples) : base()
        {
            
            m_configuration = new Dictionary<char, char>();
            foreach (var item in configurationCouples)
            {
                if (item.Length > 0)
                {
                    m_configuration.Add(item[0], item[1]);
                    m_configuration.Add(item[1], item[0]);
                }
            }
        }

        public string TranslateLetter(string givenMessage,Direction? dir)
        {
            givenMessage = givenMessage.ToUpper();
            var result = new string(givenMessage.Select(c => (m_configuration.Keys.Contains(c) ? m_configuration[c] : c)).ToArray());
            return result.ToString();
        }


    }
}
