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
            //if (Validation.IsOpenFile("fileExceptionData.txt"))
            //{
            //    File.Copy("fileExceptionData.txt", "copyFileName");
            //}
            StreamReader sr = new StreamReader(fileName);
            StreamWriter sw = new StreamWriter("fileExceptionData.txt", append: true);
            products = new List<Product>();
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
                else//домашня робота 7, завдання 3 якщо стрічка неправильна записати її у файл реєстрації помилок
                {
                    sw.WriteLine(String.Format("{0,-30} || {1,-35} || {2,-20}", line, ex.Message, DateTime.Now));
                }
            }
            sr.Close();
            sw.Close();
        }

        public void Add(Product product)
        {
            products.Add(product);
        }

        public Storage JustProductOfName(string nameProduct)
        {
            Storage storage = new Storage();

            List<Product> products1 = products.Where(el => el.Name.ToLower() == nameProduct.ToLower()).ToList();
            foreach(Product product in products1)
            {
                storage.Add(product);   
            }

            return storage;
        }

        public void PriceChange(double perCent)
        {
            foreach(Product product in products)
            {
                product.Price = product.PriceChange(perCent);
            }
        }

        public Product this[int i]
        {
            get
            {
                if (i < 0 || i >= products.Count)
                {
                    throw new ArgumentOutOfRangeException("inccorect number for index of list");
                }
                return products[i];
            }
            set
            {
                if (i < 0 || i >= products.Count)
                {
                    throw new ArgumentOutOfRangeException("inccorect number for index of list");
                }
                this.products[i] = value;
            }
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
