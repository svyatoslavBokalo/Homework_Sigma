using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class AnalyzFile
    {
        static public bool IsSplitLine(string line)
        {
            if(line.Contains(','))
            {
                return true;
            }
            return false;
            
        }

        static public bool LineSplitForSpace(string line)
        {
            if (line.Contains('-'))
            {
                return true;
            }
            return false;
        }
    }
}
