using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Dish
    {
        private Dictionary<string, double> _ingridients;
        
        public double this[string key]
        {
            get
            {
                return _ingridients[key];
            }
        }
        public int Length => _ingridients.Count;
        public IEnumerable<string> Keys => _ingridients.Keys;

        public Dish()
        {
            _ingridients = new();
        }
        public Dish(Dictionary<string, double> ingridients) : this()
        {
            _ingridients = ingridients;
        }

        public override string? ToString()
        {
            string? res = "";
            foreach(KeyValuePair<string, double> kvp in _ingridients)
            {
                res += $"{kvp.Key} - {kvp.Value} \n";
            }
            return res;
        }

        public void Add(KeyValuePair<string, double> ingridient)
        {
            _ingridients.Add(ingridient.Key, ingridient.Value);
        }
    }
}
