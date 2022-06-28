using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringWorkAndElectricityClass
{
    public enum Quarter
    {
        first,
        second,
        third,
        fourth
    }

    //internal class QuarterParse
    //{
    //    public static string Parse(string line)
    //    {
    //        string res = "";
    //        string[] mas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    //        if (int.TryParse(mas[1], out int id))
    //        {
    //            switch (id)
    //            {
    //                case 1:
    //                    {
    //                        mas[1] = Quarter.first.ToString();
    //                    }
    //                    break;
    //                case 2:
    //                    {
    //                        mas[1] = Quarter.second.ToString();
    //                    }
    //                    break;
    //                case 3:
    //                    {
    //                        mas[1] = Quarter.third.ToString();
    //                    }
    //                    break;
    //                case 4:
    //                    {
    //                        mas[1] = Quarter.fourth.ToString();
    //                    }
    //                    break;
    //                default:
    //                    {
    //                        throw new IndexOutOfRangeException("inccorect number of quarter! please take from 1 to 4");
    //                    }
    //            }
    //        }
    //        else
    //        {
    //            throw new FormatException("inccorect number of quarter! don't parse to int");
    //        }

    //        foreach(string s in mas)
    //        {
    //            res += s + " ";
    //        }
    //        return res;
    //    }
    //}
}
