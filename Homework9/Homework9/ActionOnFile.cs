using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class ActionOnFile
    {
        static public List<string> ReadFromFileInListString(string fileName)
        {
            List<string> list = new List<string>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            return list;
        }

        static public List<Dish> ReadFromFileDish(string fileName)
        {
            List<Dish> list = new List<Dish>();
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = null;
                Dish dish = new Dish();
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    if (!String.IsNullOrEmpty(line))
                    {
                        //Console.WriteLine("\t\t yes of course");
                        if (AnalyzFile.IsSplitLine(line))
                        {
                            //Console.WriteLine(line);    
                            string[] mas = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                            if(double.TryParse(mas[1], out double weight))
                            {
                                dish.Add(new KeyValuePair<string, double>(mas[0], weight));
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine("\t\tyes ");
                        list.Add(dish);
                        dish = new Dish();
                    }
                }
                list.Add(dish);
            }

            return list;
        }

        static public List<Dish> ReadFromFileDish(List<string> lst)
        {
            List<Dish> list = new List<Dish>();
            Dish dish = new Dish();
            foreach(string line in lst)
            {
                if (!String.IsNullOrEmpty(line))
                {
                    if (AnalyzFile.IsSplitLine(line))
                    {
                        //Console.WriteLine(line);
                        string[] mas = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        //Console.WriteLine($"{mas[0]} - {mas[1]}");
                        if (double.TryParse(mas[1], out double weight))
                        {
                            dish.Add(new KeyValuePair<string, double>(mas[0], weight));
                        }
                    }
                }
                else
                {
                    list.Add(dish);
                    dish = new Dish();
                }
            }
            return list;
        }

        static public Dictionary<string, double> ReadPriceKurant(string fileName = "Prices.txt")
        {
            Dictionary<string, double> priceKurant = new Dictionary<string, double>();
            using(StreamReader sr = new StreamReader(fileName))
            {
                string line = null;
                while((line = sr.ReadLine()) != null)
                {
                    if (!AnalyzFile.LineSplitForSpace(line))
                    {
                        throw new InvalidDataException($"inccorect price kurant line: {line}");
                    }
                    else
                    {
                        string[] mas = line.Split('-', StringSplitOptions.RemoveEmptyEntries);
                        if(!double.TryParse(mas[1], out double price))
                        {
                            throw new FormatException($"inccorect price in txt file PriceKurant.txt in line - {line}");
                        }
                        else
                        {
                            if(price < 0)
                            {
                                throw new FormatException($"value price is {price} <0, so it's not good price");
                            }
                            priceKurant.Add(mas[0], price);
                        }
                    }
                }
            }
            return priceKurant;
        }

        static public void WritePriceProductOnFile(string keyProduct,double valuePrice, string fileName = "Prices.txt")
        {
            using(StreamWriter sw = new StreamWriter(fileName, append: true))
            {
                sw.WriteLine($"{keyProduct} - {valuePrice}");
            }
        }
    }
}
