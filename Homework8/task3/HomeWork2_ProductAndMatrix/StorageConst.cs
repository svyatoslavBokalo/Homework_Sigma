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
        public static int topGradeMeat = 5;
        public static int oneGradeMeat = 10;
        public static int twoGradeMeat = 15;
        public static int expirationDateDairy = 10;
    }
}
