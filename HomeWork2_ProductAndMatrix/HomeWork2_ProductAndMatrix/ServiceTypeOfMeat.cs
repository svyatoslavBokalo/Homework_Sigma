using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class ServiceTypeOfMeat
    {
        static public TypeOfMeat CheckTypeOfMeat(string s)
        {
            TypeOfMeat typeOfMeat = new TypeOfMeat();
            if (s.ToLower() == "pork")
            {
                typeOfMeat = TypeOfMeat.Pork;
                return typeOfMeat;
            }
            if (s.ToLower() == "beef")
            {
                typeOfMeat = TypeOfMeat.Beef;
                return typeOfMeat;
            }
            if (s.ToLower() == "chicken")
            {
                typeOfMeat = TypeOfMeat.Chicken;
                return typeOfMeat;
            }
            if (s.ToLower() == "mutton")
            {
                typeOfMeat = TypeOfMeat.Mutton;
                return typeOfMeat;
            }
            else
            {
                throw new ArgumentException("inccorect string for type of meat, input else");
            }

            return typeOfMeat;


        }

        static public TypeOfMeat CheckTypeOfMeat(int number)
        {
            TypeOfMeat typeOfMeat = new TypeOfMeat();
            switch (number)
            {
                case 1:
                    {
                        typeOfMeat = TypeOfMeat.Pork;
                    }
                    break;
                case 2:
                    {
                        typeOfMeat = TypeOfMeat.Beef;
                    }
                    break;
                case 3:
                    {
                        typeOfMeat = TypeOfMeat.Chicken;
                    }
                    break;
                case 4:
                    {
                        typeOfMeat = TypeOfMeat.Mutton;
                    }
                    break;
                default:
                    {
                        throw new Exception("number for type of meat is bad, input else");
                    }
                    break;
            }

            return typeOfMeat;
        }
    }
}
