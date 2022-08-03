using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{

    public delegate void ProductEventHandler(string str);
    internal class Storage
    {
        private List<Product> products;
        public event ProductEventHandler OnProductEventHandler;

        public Storage()
        {
            products = new List<Product>();
        }

        public Storage(List<Product> products)
        {
            foreach(Product product in products)
            {
                this.products.Add(product);
            }
        }

        public Storage(string fileName)
        { 
            this.products = new List<Product>();
            ActionsOnFile.ReadFromFile(fileName);
        }
        public void Add(Product product)
        {
            if((product is DairyProducts) && (product as DairyProducts).ExpirationDate >= DateTime.Today.AddDays(StorageConst.countOfDaysExpiration))
            {
                this.OnProductEventHandler($"is dont good: {product.Name} - {product.Price} - {product.Weight} - {(product as DairyProducts).ExpirationDate}");
            }
            else
            {
                products.Add(product);
            }
        }
        public List<Product> Products
        {
            get
            {
                return products;
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
