using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    static public class UsePolandRecord
    {
        static public void WriteLineFormul()
        {
            Console.WriteLine("input eqeshion: \t");
            string line = "(1.3*5+4*(43-34)+sin(45))";
            //line = "((2+4)-5.5)+2*(3-(4+5))";
            //line = "((2+4)-5.5)+2*(3-(4+5))";

            PolandRecord record = new PolandRecord(line);
            List<string> lst = record.CreateLexems2();
            foreach (string s in lst)
            {
                Console.WriteLine(s);
            }
            //record.CreatePoland();
            Console.WriteLine(record.FormulaPoland);
        }
    }
}
