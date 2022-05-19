using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class ServiceCategory
    {
        static public Category ChooseCategory(int number)
        {

            Category category = new Category();
            switch (number)
            {
                case 1:
                    {
                        category = Category.TopGrade;
                    }
                    break;
                case 2:
                    {
                        category = Category.OneGrade;
                    }
                    break;
                case 3:
                    {
                        category = Category.TwoGrade;
                    }
                    break;
                default:
                    {
                        throw new Exception("number for category is bad, input else");
                    }
                    break;
            }

            return category;
        }

        static public Category ChooseCategory(string s)
        {

            Category category = new Category();
            switch (s.ToLower())
            {
                case "topgrade":
                    {
                        category = Category.TopGrade;
                    }
                    break;
                case "onegrade":
                    {
                        category = Category.OneGrade;
                    }
                    break;
                case "twograde":
                    {
                        category = Category.TwoGrade;
                    }
                    break;
                default:
                    {
                        throw new Exception("inccorect string, input else");
                    }
                    break;
            }

            return category;
        }
    }
}
