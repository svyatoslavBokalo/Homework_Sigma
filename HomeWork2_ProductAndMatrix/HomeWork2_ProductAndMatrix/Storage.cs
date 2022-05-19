using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Storage
    {
        private List<Product> products;

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(string fileName)
        {
            this.ReadFromFile(fileName);
        }
        public void ReadFromFile(string fileName = "data.txt")
        {
            StreamReader sr = new StreamReader(fileName);
            products = new List<Product>();
            string line = null;

            while (!sr.EndOfStream)
            {
                try
                {
                    line = sr.ReadLine();
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
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new StorageException(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new StorageException(ex.Message);
                }
                
            }
            sr.Close();
        }

  
        static public void JustMeatProduct(Buy buy)
        {
            Buy buy1 = new Buy();
            buy1 = buy.JustProductOfName("meat");
        }

        public override string? ToString()
        {
            string res = "";
            foreach(Product product in products)
            {
                res += product.ToString() + "\n";
            }

            return res;
        }
    }
}
