using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_ProductAndMatrix
{
    internal static class StorageService
    {

        static public Storage PriceChange(double perCent,ref Storage storage)
        {
            Storage res = new Storage();
            for(int i = 0; i< storage.Products.Count; i++)
            {
                res[i].Price = storage.Products[i].PriceChange(perCent);
            }
            return res;
        }


        #region "Storage Operation Set"
        static public Storage StorageDifference(Storage storage1, Storage storage2)// завдання 3.а для 8 домашної роботи
        {
            Storage res = new Storage();

            foreach (Product el in storage1.Products)
            {
                if (!storage2.Products.Contains(el))
                {
                    res.Add(el);
                }
            }

            return res;
        }
        static public Storage StorageIntersection(Storage storage1, Storage storage2)// завдання 3.b для 8 домашної роботи
        {
            Storage res = new Storage();

            foreach (Product el in storage1.Products)
            {
                if (storage2.Products.Contains(el))
                {
                    res.Add(el);
                }
            }
            return res;
        }

        static public Storage StorageUnion(Storage storage1, Storage storage2)// завдання 3.c для 8 домашної роботи
        {
            Storage res = new Storage();

            foreach (Product el in storage1.Products)
            {
                if (!storage2.Products.Contains(el))
                {
                    res.Add(el);
                }
            }
            foreach (Product el in storage2.Products)
            {
                res.Add(el);
            }
            return res;
        }

        #endregion

        #region Search Product in Storage
        static public Storage JustProductOfName(string nameProduct, Storage storage)
        {
            Storage res = new Storage();

            List<Product> products1 = storage.Products.Where(el => el.Name.ToLower() == nameProduct.ToLower()).ToList();
            foreach (Product product in products1)
            {
                res.Add(product);
            }

            return res;
        }

        static public Storage JustProductOfPrice(double price, Storage storage)
        {
            Storage res = new Storage();

            List<Product> products1 = storage.Products.Where(el => el.Price == price).ToList();
            foreach (Product product in products1)
            {
                res.Add(product);
            }

            return res;
        }

        static public Storage JustProductOfWeight(double weight, Storage storage)
        {
            Storage res = new Storage();

            List<Product> products1 = storage.Products.Where(el => el.Weight == weight).ToList();
            foreach (Product product in products1)
            {
                res.Add(product);
            }

            return res;
        }
        #endregion
    }
}
