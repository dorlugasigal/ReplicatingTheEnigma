using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    public abstract class Substitutor
    {

        public string LetterIndexConverter(string message)
        {
            return message;
        }
        public void CircularShift()
        {

        }

        public abstract string ForwardTranslation();
        public abstract string ReverseTranslation();
    }
}
