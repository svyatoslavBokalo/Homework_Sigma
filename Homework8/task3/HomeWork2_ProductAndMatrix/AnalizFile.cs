using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class AnalizFile
    {
        static public void AnalizFileException(DateTime dateTime)
        {
            File.Copy("fileExceptionData.txt", "copyFileException");
            using (StreamReader sr = new StreamReader("fileExceptionData.txt"))
            {
                StreamWriter sw = new StreamWriter("copyFileException.txt");
                string line = null;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    string[] mas = line.Split("||", StringSplitOptions.RemoveEmptyEntries);
                    if(DateTime.TryParse(mas[2], out DateTime result))
                    {
                        if(result.Date > dateTime.Date)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
                sw.Close();
            }
        }
    }
}
