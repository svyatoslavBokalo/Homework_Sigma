using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class CheckString
    {
        static public bool TryGetString(StringBuilder stringBuilder, string word)
        {
            string check = stringBuilder.ToString();
            if (check.Contains(word))
            {
                return true;
            }
            return false;
        }
        
    }
}
