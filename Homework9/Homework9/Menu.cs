using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework9
{
    internal class Menu
    {
        private List<Dish> _dishes;
        public Dish this[int index]
        {
            get => _dishes[index];  
        }
        public int Length => _dishes.Count;  
        public Menu()
        {
            _dishes = new List<Dish>();
        }
        public Menu(List<Dish> dishes) :this()
        {
            _dishes = dishes;
        }

        public Menu(string fileName)
        {
            _dishes = new List<Dish>();
            _dishes = ActionOnFile.ReadFromFileDish(fileName);
        }

        public override string? ToString()
        {
            string? result = "";
            foreach(Dish dish in _dishes)
            {
                result +=dish.ToString();
            }
            return result;
        }

        //public Dictionary<>
    }
}
