using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWorkAndElectricityClass
{
    public class AccountCheck
    {
        public static string QuarterParse(string line)
        {
            string res = "";
            string[] mas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Quarter quarter;
            if (int.TryParse(mas[1], out int id))
            {
                switch (id)
                {
                    case 1:
                        {
                            quarter = Quarter.first;
                            mas[1] = Enum.GetName(typeof(Quarter), quarter);
                        }
                        break;
                    case 2:
                        {
                            quarter = Quarter.second;   
                            mas[1] = Enum.GetName(typeof(Quarter), quarter);
                        }
                        break;
                    case 3:
                        {
                            quarter = Quarter.third;
                            mas[1] = Enum.GetName(typeof(Quarter), quarter);
                        }
                        break;
                    case 4:
                        {
                            quarter = Quarter.fourth;
                            mas[1] = Enum.GetName(typeof(Quarter), quarter);
                        }
                        break;
                    default:
                        {
                            throw new IndexOutOfRangeException("inccorect number of quarter! please take from 1 to 4");
                        }
                }
            }
            else
            {
                throw new FormatException("inccorect number of quarter! don't parse to int");
            }

            foreach (string s in mas)
            {
                res += s + " ";
            }
            return res;
        }

        public static void CheckLine(string line)
        {
            string[] mas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            uint apartment;
            double inputIndector;
            double outputIndecator;
            DateTime dateTaken;
            if(!uint.TryParse(mas[0], out apartment))
            {
                throw new FormatException("number of appartment inccorect");
            }
            if(!double.TryParse(mas[2], out inputIndector))
            {
                throw new FormatException("inccorect input indecator electricity");
            }
            if (!double.TryParse(mas[3], out outputIndecator))
            {
                throw new FormatException("inccorect output indecator electricity");
            }
            if(!DateTime.TryParse(mas[4], out dateTaken))
            {
                throw new FormatException("inccorect date! example: 3/08/2022");
            }


            if(inputIndector > outputIndecator)
            {
                throw new InvalidDataException("invalid input indecator besause it is more than output indecator");
            }

        }
    }
}
