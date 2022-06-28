using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class PriceKurant
    {
        private Dictionary<string, double> _productPrice;
        public PriceKurant()
        {
            _productPrice = new();
        }
        public PriceKurant(Dictionary<string, double> productPrice) : this()
        {
            _productPrice = productPrice;
        }

        public PriceKurant(string fileName = "Prices.txt")
        {
            _productPrice = ActionOnFile.ReadPriceKurant(fileName);
        }

        public double this[string key]
        {
            get
            {
                return _productPrice[key];
            }
        }
        public int Length => _productPrice.Count;
        public IEnumerable<string> Keys => _productPrice.Keys;
        public bool TryGetProductPrice(string productName, out double price)
        {
            if (!_productPrice.TryGetValue(productName, out double result))
            {             
                price = default;  
                return false;
            }
            price = result;
            return true;
        }

        public override string? ToString()
        {
            string res = "";
            foreach(KeyValuePair<string, double> kvp in _productPrice)
            {
                res += $"{kvp.Key} - {kvp.Value}\n";
            }
            return res;
        }
    }
}
