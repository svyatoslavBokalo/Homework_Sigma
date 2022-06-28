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
            this.products = new List<Product>();
            this.products = ActionsOnFile.ReadFromFile(fileName); // замінна внутрішнього методу класу зчитування з файлу
        }
        

        public void Add(Product product)
        {
            products.Add(product);
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
