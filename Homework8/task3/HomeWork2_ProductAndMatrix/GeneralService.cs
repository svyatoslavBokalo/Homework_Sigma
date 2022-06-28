using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class GeneralService
    {
        static public void Run()
        {
            int number = 0;
            bool check = true;
            Storage storage = new Storage();

            while (check)
            {
                UseStorage.ShowMenu();
                Console.WriteLine();
                Console.Write("input number: ");
                number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        {
                            check = false;
                        }
                        break;
                    case 2:
                        {
                            Console.Write("input file name: ");
                            string fileName = Console.ReadLine();
                            while (!Validation.IsOpenFile(fileName))
                            {
                                Console.Write($"file not found: {fileName}\t || input file name again: ");
                                fileName = Console.ReadLine();
                            }
                            storage = new Storage(fileName);
                        }
                        break;
                    case 3:
                        {
                            UseStorage.Show(storage);
                        }
                        break;
                    case 4:
                        {
                            storage.Add(UseStorage.InputFromConsole());
                        }
                        break;
                    case 5:
                        {
                            Storage res = storage.JustProductOfName("meat");
                            UseStorage.Show(res);
                        }
                        break;
                    case 6:
                        {
                            Console.Write("input per cent: ");
                            double perCent = double.Parse(Console.ReadLine());
                            storage.PriceChange(perCent);
                        }
                        break;
                    case 7:
                        {
                            Console.Write("input number of list: ");
                            int n = int.Parse(Console.ReadLine());
                            Console.WriteLine(storage[n]);
                        }
                        break;
                    case 8:
                        {
                            Console.Write("input date|| for example 26.04.2022 ||  : ");
                            DateTime dateTime = DateTime.Parse(Console.ReadLine());
                            AnalizFile.AnalizFileException(dateTime);
                        }
                        break;
                    case 9:
                        {
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();   
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            Storage res = Storage.StorageDifference(storage1, storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();

                            
                        }
                        break;
                    case 10:
                        {
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            Storage res = Storage.StorageIntersection(storage1, storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();


                        }
                        break;
                    case 11:
                        {
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            Storage res = Storage.StorageUnion(storage1, storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();


                        }
                        break;
                    default:
                        {
                            Console.WriteLine("\t\t inccorect number!!!");
                        }
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
