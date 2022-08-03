using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15
{
    internal class Task2
    {
        private List<string> stringList;

        public List<string> StringList { get => stringList; set => stringList = value; }

        public Task2(List<string> stringList)
        {
            this.stringList = stringList;
        }

        public void LinqTask2()
        {
            var list = stringList.GroupBy(el => el.First(), el => el.Length, (letter, lenghtString) => new
            {
                Key = letter,
                Count = lenghtString.Count(),
                LenghtString = lenghtString.Sum()
            });

            foreach (var el in list)
            {
                Console.WriteLine("Key = " + el.Key + " LenghtString = " + el.LenghtString + " Count = " + el.Count);
            }
        }
    }
}
