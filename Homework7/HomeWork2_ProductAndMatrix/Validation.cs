using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Validation
    {
        static public bool IsOpenFile(string fileName)//домашня робота 7, завдання 1 чи існує файл
        {
            if(File.Exists(fileName))
            {
                return true;
            }
            return false;
        }
        static public bool IsCorrectLineForStorage(string line, out Exception ex)//домашня робота 7, завдання 2 перевірка на коректність
        {// перевірка на коректність 
            bool res = true;
            ex = new Exception("good product");
            string[] mas = line.Split();
            switch (mas[0].ToLower())
            {
                case "meat":
                    {
                        if(!uint.TryParse(mas[1], out uint price))
                        {
                            res = false;
                            ex = new FormatException($"inccorect price of meat: {mas[1]}");
                        }
                        if(!uint.TryParse(mas[2], out uint weight))
                        {
                            res = false;
                            ex = new FormatException($"inccorect weight of meat: {mas[2]}");
                        }
                        if(!ServiceCategory.TryParse(mas[3], out Category category))
                        {
                            res = false;
                            ex = new ArgumentException($"inccorect catagery of meat: {mas[3]}");
                        }
                        if(!ServiceTypeOfMeat.TryParse(mas[4], out TypeOfMeat typeOfMeat))
                        {
                            res = false;
                            ex = new ArgumentException($"inccorect type of meat: {mas[4]}");
                        }
                    }
                    break;
                case "dairy":
                    {
                        if (!uint.TryParse(mas[1], out uint price))
                        {
                            res = false;
                            ex = new FormatException($"inccorect price of dairy: {mas[1]}");
                        }
                        if (!uint.TryParse(mas[2], out uint weight))
                        {
                            res = false;
                            ex = new FormatException($"inccorect weight of dairy: {mas[2]}");
                        }
                        if(!DateTime.TryParse(mas[3], out DateTime date))
                        {
                            res = false;
                            ex = new InvalidTimeZoneException($"inccorect time in dairy: {mas[3]}");
                        }   
                    }
                    break;
                default:
                    {
                        res = false;
                        ex = new ArgumentException("inccorect name of product");
                    }
                    break;
            }
            return res;
        }
    }
}
