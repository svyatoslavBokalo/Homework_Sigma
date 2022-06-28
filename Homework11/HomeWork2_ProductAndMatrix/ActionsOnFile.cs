using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class ActionsOnFile
    {
        static public List<Product> ReadFromFile(string fileName = "data.txt")
        {
            //if (Validation.IsOpenFile("fileExceptionData.txt"))
            //{
            //    File.Copy("fileExceptionData.txt", "copyFileName");
            //}
            StreamReader sr = new StreamReader(fileName);
            StreamWriter sw = new StreamWriter("fileExceptionData.txt", append: true);
            List<Product> products = new List<Product>();
            string line = null;
            Exception ex;
            DateTime date = new DateTime();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (Validation.IsCorrectLineForStorage(line, out ex))
                {
                    string[] mas = line.Split();
                    Product product = new Product();
                    switch (mas[0].ToLower())
                    {
                        case "meat":
                            {
                                product = new Meat();
                            }
                            break;
                        case "dairy":
                            {
                                product = new DairyProducts();
                            }
                            break;
                    }
                    product.Parse(line);
                    products.Add(product);
                }
                else
                {
                    sw.WriteLine(String.Format("{0,-30} || {1,-35} || {2,-20}", line, ex.Message, DateTime.Now));
                }
            }
            sr.Close();
            sw.Close();

            return products;
        }
    }
}
