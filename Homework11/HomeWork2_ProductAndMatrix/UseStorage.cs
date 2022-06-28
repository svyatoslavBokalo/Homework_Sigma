using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class UseStorage
    {
        static public void Show(Storage storage)
        {
            Console.WriteLine(storage);
        }

        static public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1) exit");
            Console.WriteLine("2) read from file");
            Console.WriteLine("3) show");
            Console.WriteLine("4) input number for сreate product");
            Console.WriteLine("5) just meat product");
            Console.WriteLine("6) change price");
            Console.WriteLine("7) this[int i]");
            Console.WriteLine("8) analiz file of exception with date|||  it 7 homework:");
            Console.WriteLine("9) difference between storage|||  it 8 task 3.a homework:");
            Console.WriteLine("10) Intersection between storage|||  it 8 task 3.b homework:");
            Console.WriteLine("11) Union between storage|||  it 8 task 3.c homework:");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public Product InputFromConsole()
        {
            Product res = new Product();

            Console.WriteLine("\t\t choose number: 1 - meat, 2 - dairy");
            int number = int.Parse(Console.ReadLine());
            if (number != 1 && number != 2)
            {
                throw new ArithmeticException("inccorect number, please input 1 or 2");
            }

            Console.WriteLine("\t\t input");

            if (number == 1)
            {
                Console.Write("input price: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("input weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("input category of meat: topgrade,\t onegrade,\t twograde;\t");
                Category categoryOfMeat = ServiceCategory.ChooseCategory(Console.ReadLine());

                Console.Write("input view of meat: ");
                TypeOfMeat viewOfMeat = ServiceTypeOfMeat.CheckTypeOfMeat(Console.ReadLine());

                res = new Meat(price, weight, categoryOfMeat, viewOfMeat);
            }
            if (number == 2)
            {
                Console.Write("input price: ");
                double price = double.Parse(Console.ReadLine());

                Console.Write("input weight: ");
                double weight = double.Parse(Console.ReadLine());

                Console.Write("input expiration date of product: ");
                DateTime expirationDate = DateTime.Parse(Console.ReadLine());


                res = new DairyProducts(price, weight, expirationDate);
            }

            return res;
        }
    }
}
