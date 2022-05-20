using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Product
    {
        protected string name;
        protected double price;
        protected double weight;


        public Product()
        {
            this.name = "";
            this.price = 0;
            this.weight = 0;
        }

        public Product(string name, double price, double weight)
        {
            this.name = name;
            this.Price = price;
            this.Weight = weight;
        }

        //public Product(string name, double price, double weight)
        //{
        //    this.name = name;
        //    this.price = price;
        //    this.weight = weight;
        //}

        public string Name { get => name; set => name = value; }
        public double Price 
        {
            get => price;
            set
            {
                if(value>= 0)
                {
                    price = value;
                }
                else
                {
                    throw new ExceptionPrice("Incorrect price must be positive number");
                }
            }
        }
        public double Weight 
        { 
            get => weight;
            set
            {
                if (value >= 0)
                {
                    weight = value;
                }
                else
                {
                    throw new ExpceptionWeight("Incorrect weight must be positive number");
                }

            } 
        }

        public override string? ToString()
        {
            return "Name: " + name + ".\t" + "price = " + price + ".\t" + "weight = " + weight;
        }

        public virtual double PriceChange(double perCent)
        {
            return this.Price = price - price / 100 * perCent;
        }

        public override bool Equals(object? obj)
        {
            bool res = true;
            if(obj == null || !(obj is Product))
            {
                res = false;
            }
            else
            {
                Product? p = obj as Product;
                if(p.Name == this.Name && p.Price == this.Price && p.Weight == this.Weight)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }

            return res;
        }

        public virtual void Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            try
            {
                string[] mas = str.Split();
                this.Name = mas[0].ToLower();
                this.Price = double.Parse(mas[1]);
                this.Weight = double.Parse(mas[2]);
            }
            catch (ExceptionPrice ex)
            {
                throw new FormatException(ex.Message);
            }
            catch(ExpceptionWeight ex)
            {
                throw new FormatException(ex.Message);
            }
        }

    }
}
