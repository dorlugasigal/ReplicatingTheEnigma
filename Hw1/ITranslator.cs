using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hw1.Helper;

namespace Hw1
{
    interface ITranslator
    {
        string TranslateLetter(string givenMessage, Direction? dir);
    }
}
