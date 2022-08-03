using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    public enum Category
    {
        TopGrade,
        OneGrade,
        TwoGrade
    }

    public enum TypeOfMeat
    {
        Pork,
        Beef,
        Chicken,
        Mutton
    }
    internal class StorageConst
    {
        static public int topGradeMeat = 5;
        static public int oneGradeMeat = 10;
        static public int twoGradeMeat = 15;
        static public int expirationDateDairy = 10;


        static public int countOfDaysExpiration = 90;
    }
}
