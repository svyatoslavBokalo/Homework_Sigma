using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Buy
    {
        private List<Product> products;

        internal List<Product> Products { get => products; set => products = value; }

        public Buy()
        {
            this.products = new List<Product>();    
        }

        public Buy(List<Product> products)
        {
            this.products = products;
        }
        public Buy(int count)
        {
            this.products = new List<Product>();

            Product product = new Product();
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("input name product: ");
                string name = Console.ReadLine();
                Console.WriteLine("input price product: ");
                double price = double.Parse(Console.ReadLine());
                Console.WriteLine("input weight product: ");
                double weight = double.Parse(Console.ReadLine());
                product = new Product(name, price, weight);
                this.products.Add(product);
            }
        } 

        //public Buy(string fileName = "data.txt")
        //{
        //    this.products = Storage.ReadFromFile(fileName);
        //}

        public Buy(int count, Product product)
        {
            this.products = new List<Product>();
            for(int i = 0; i < count; i++)
            {
                this.products.Add(product);
            }
        }

        public int Count()
        {
            return this.products.Count;
        }

        public double Price()
        {
            double price = 0;
            foreach(Product el in this.products)
            {
                price +=el.Price;
            }
            return price;
        }

        public double Weight()
        {
            double weight = 0;
            foreach (Product el in this.products)
            {
                weight += el.Weight;
            }
            return weight;
        }

        public override string? ToString()
        {
            return $"count = {Count()}. {Count()}*price = {Price()}. {Count()}*weight = {Weight()}";
        }
        
        public Buy JustProductOfName(string nameProduct)
        {
            Buy buy = new Buy();

            List<Product> products1 = products.Where(el=>el.Name.ToLower() == nameProduct.ToLower()).ToList();
            buy = new Buy(products1);

            return buy;
        }

        public void Add(Product product)
        {
            this.Products.Add(product); 
        }
    }   
}
