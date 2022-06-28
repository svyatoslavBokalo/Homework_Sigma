using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class DairyProducts: Product
    {
        private DateTime expirationDate;

        public DateTime ExpirationDate { get => expirationDate; set => expirationDate = value; }

        public DairyProducts() : base() { }

        public DairyProducts(Product product, DateTime expirationDate): base(product.Name, product.Price, product.Weight)
        {
            this.expirationDate = expirationDate;
        }

        public DairyProducts(double price, double weight, DateTime expirationDate) : base("Dairy", price, weight)
        {
            this.expirationDate = expirationDate;
        }

        public override double PriceChange(double perCent)
        {
            return base.PriceChange(perCent) - this.Price / 100 * StorageConst.expirationDateDairy;
        }

        //public override bool Equals(object? obj)
        //{
        //    bool res = true;
        //    if (obj == null || !(obj is DairyProducts))
        //    {
        //        res = false;
        //    }
        //    else
        //    {
        //        DairyProducts dairy = (DairyProducts)obj;
        //        if (dairy.Name == this.Name && dairy.Price == this.Price && dairy.Weight == this.Weight && dairy.expirationDate == this.expirationDate)
        //        {
        //            res = true;
        //        }
        //    }

        //    return res;
        //}

        public override string? ToString()
        {
            return base.ToString() + ".\t expiration date:" + expirationDate; 
        }

        public override void Parse(string str)
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
                this.ExpirationDate = DateTime.Parse(mas[3]);
            }
            catch (ExceptionPrice ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (ExpceptionWeight ex)
            {
                throw new FormatException(ex.Message);
            }
        }

        static public bool operator ==(DairyProducts? dairyProducts1, DairyProducts? dairyProducts2)
        {
            if (dairyProducts1.Price == dairyProducts2.Price && dairyProducts1.Weight == dairyProducts2.Weight && dairyProducts1.ExpirationDate == dairyProducts2.ExpirationDate)
            {
                return true;
            }
            return false;
        }

        static public bool operator !=(DairyProducts? dairyProducts1, DairyProducts? dairyProducts2)
        {
            return !(dairyProducts1 == dairyProducts2);
        }
    }
}
