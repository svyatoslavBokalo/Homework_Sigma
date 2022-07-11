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
            storage.OnProductEventHandler += Message;

            while (check)
            {
                UseStorage.ShowMenu();
                Console.WriteLine();
                Console.Write("input number: ");
                if (!int.TryParse(Console.ReadLine(), out number))
                {
                    throw new FormatException("inccorect number of menu,please input intenger digget");
                }         

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
                            ActionsOnFile.ReadFromFile(storage, fileName);
                            //storage.OnProductEventHandler += Message;
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
                        {// замінна методів із класу Storage на статичні методи класу StorageService
                            Storage res = StorageService.JustProductOfName("meat", storage);
                            //Storage res = storage.JustProductOfName("meat");  // минуле використання з класу Storage
                            UseStorage.Show(res);
                        }
                        break;
                    case 6:
                        {// замінна методів із класу Storage на статичні методи класу StorageService
                            Console.Write("input per cent: ");
                            double perCent = double.Parse(Console.ReadLine());
                            StorageService.PriceChange(perCent,ref storage); // заміна методу
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
                        {// замінна методів із класу Storage на статичні методи класу StorageService
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();   
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            //Storage res = Storage.StorageDifference(storage1, storage2); // заміна методу
                            Storage res = StorageService.StorageDifference(storage1,storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();

                            
                        }
                        break;
                    case 10:
                        {// замінна методів із класу Storage на статичні методи класу StorageService
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            //Storage res = Storage.StorageIntersection(storage1, storage2); // заміна методу
                            Storage res = StorageService.StorageIntersection(storage1,storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();


                        }
                        break;
                    case 11:
                        {// замінна методів із класу Storage на статичні методи класу StorageService
                            Storage storage1 = new Storage("data.txt");
                            Storage storage2 = new Storage("data2.txt");
                            Console.WriteLine(storage1);
                            Console.WriteLine();
                            Console.WriteLine(storage2);
                            Console.WriteLine();
                            //Storage res = Storage.StorageUnion(storage1, storage2); // заміна методу
                            Storage res = StorageService.StorageUnion(storage1,storage2);
                            Console.WriteLine(res);
                            Console.WriteLine();


                        }
                        break;
                    case 12:
                        {// завдання 2 - домашня робота 12

                            Console.Write("input name of product:  ");
                            string name = Console.ReadLine();
                            Storage res = new Storage();

                            if (name == "meat" || name == "dairyProduct")
                            {
                                res = StorageService.JustProductOfName(name, storage);
                                UseStorage.Show(res);
                            }
                            else
                            {
                                throw new FormatException("inccorect input name of product");
                            }
                        }
                        break;
                    case 13:
                        {// завдання 2 - домашня робота 12
                            Console.Write("input price of product:  ");
                            string str = Console.ReadLine();
                            double price =0;
                            Storage res = new Storage();
                            if(!double.TryParse(str, out price))
                            {
                                throw new Exception("inccorect input price, price must be digget, pleasy try again");
                            }
                            else
                            {
                                if (price < 0)
                                {
                                    throw new Exception("inccorect input price, price must <0, pleasy try again");
                                }
                                else
                                {
                                    res = StorageService.JustProductOfPrice(price, storage);
                                    UseStorage.Show(res);
                                }
                            }

                        }
                        break;
                    case 14:
                        {// завдання 2 - домашня робота 12
                            Console.Write("input weight of product:  ");
                            string str = Console.ReadLine();
                            double weight = 0;
                            Storage res = new Storage();
                            if (!double.TryParse(str, out weight))
                            {
                                throw new Exception("inccorect input weight, weight must be digget, pleasy try again");
                            }
                            else
                            {
                                if (weight < 0)
                                {
                                    throw new Exception("inccorect input weight, weight must <0, pleasy try again");
                                }
                                else
                                {
                                    res = StorageService.JustProductOfWeight(weight, storage);
                                    UseStorage.Show(res);
                                }
                            }
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


        static public void Message(string str)
        {
            Console.WriteLine(str);
        }
    }
}
