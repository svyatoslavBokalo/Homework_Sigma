﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal class Meat: Product
    {
        private Category categoryOfMeat;
        private TypeOfMeat typeOfMeat;

        public Meat():base()
        {
            this.categoryOfMeat = Category.OneGrade;
            this.typeOfMeat = TypeOfMeat.Beef;
        }

        public Meat(double price, double weight, Category categoryOfMeat, TypeOfMeat typeOfMeat) :base("Meat", price, weight)
        {
            this.categoryOfMeat = categoryOfMeat;
            this.typeOfMeat = typeOfMeat;
        }

        public override bool Equals(object? obj)
        {
            bool res = true;
            if (obj == null || !(obj is Meat))
            {
                res = false;
            }
            else
            {
                Meat meat = (Meat)obj;
                if (meat.Name == this.Name && meat.Price == this.Price && meat.Weight == this.Weight && meat.categoryOfMeat == this.categoryOfMeat && meat.typeOfMeat == this.typeOfMeat)
                {
                    res = true;
                }
            }

            return res;
        }

        public override string? ToString()
        {
            return base.ToString() + ".\t category of meat:" + categoryOfMeat + ".\t view of meat:" + typeOfMeat;
        }

        public override double PriceChange(double perCent)
        {
            if (categoryOfMeat  == Category.TopGrade)
            {
                return this.Price = base.PriceChange(perCent) - this.Price / 100 * StorageConst.topGradeMeat;
            }
            if (categoryOfMeat  == Category.OneGrade)
            {
                return this.Price = base.PriceChange(perCent) - this.Price / 100 * StorageConst.oneGradeMeat;
            }
            if (categoryOfMeat == Category.TwoGrade)
            {
                return this.Price = base.PriceChange(perCent) - this.Price / 100 * StorageConst.twoGradeMeat;
            }

            return base.PriceChange(perCent);
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
                this.categoryOfMeat = ServiceCategory.ChooseCategory(mas[3]);
                this.typeOfMeat = ServiceTypeOfMeat.CheckTypeOfMeat(mas[4]);
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
    }
}
