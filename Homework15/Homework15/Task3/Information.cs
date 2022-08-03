using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15
{
    internal class Information
    {
        public Information(int school, int year, string name)
        {
            this.School = school;
            this.Year = year;
            this.Name = name;   
        }
        public int School { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }

        public override string? ToString()
        {
            return $"{School} - {Year} - {Name}";
        }
    }
}
