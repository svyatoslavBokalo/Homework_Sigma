using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal static class MenuService
    {
        static public bool TryGetMenuTotalSum(Menu menu, PriceKurant priceKurant, out double menuTotalSum)
        {
            menuTotalSum = default;
            for (int i = 0; i < menu.Length; i++)
            {
                if (!TryGetDishPrice(menu[i], priceKurant, out double sumPrice))
                {
                    return false;
                }
                menuTotalSum+=sumPrice;
            }
            return true;
        }
        static public bool TryGetDishPrice(Dish dish, PriceKurant priceKurant, out double sumPrice)
        {
            sumPrice = default;
            foreach (string key in dish.Keys)
            {
                if (!priceKurant.TryGetProductPrice(key, out double poductPrice))
                {
                    return false;
                }
                sumPrice += poductPrice * dish[key];
            }
            return true;          
           
        }

        static public bool TryWeight(Menu menu, out Dictionary<string, double> tryWeight)
        {
            IEnumerable<string> difference = new SortedSet<string>();
            for(int i = 0; i < menu.Length; i++)
            {
                difference = menu[i].Keys.Union<string>(difference);
            }

            tryWeight = new Dictionary<string, double>();

            foreach(string el in difference)
            {
                for(int i = 0; i < menu.Length; i++)
                {
                    if (menu[i].Keys.Contains(el))
                    {
                        if (!tryWeight.Keys.Contains(el))
                        {
                            tryWeight.Add(el, menu[i][el]);
                        }
                        else
                        {
                            tryWeight[el] += menu[i][el];
                        }
                    }
                }
            }
            return true;
        }

        static public Dictionary<string, double> TotalSumProduct(Menu menu, PriceKurant priceKurant, out string keyProduct)
        {
            Dictionary<string, double> sum = new Dictionary<string, double>();
            Dictionary<string, double> dictWeight;
            TryWeight(menu, out dictWeight);
            keyProduct = null;
            foreach (string el in dictWeight.Keys)
            {
                //Console.WriteLine("foreach - yes");
                //foreach(string key in priceKurant.Keys.ToList())
                //{
                //    Console.Write($"{key} \t");
                //}
                //Console.WriteLine();
                if (priceKurant.Keys.Contains(el))
                {
                    //Console.WriteLine("if - yes");
                    sum.Add(el, dictWeight[el] / 1000 * priceKurant[el]);
                }
                else
                {
                    //Console.WriteLine("else - yes");
                    keyProduct = el;
                    throw new KeyNotFoundException($"{el} is not found");
                }
            }

            return sum;
        }
        
    }
}
