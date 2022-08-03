using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15
{
    internal class Task1
    {
        private List<int> integerList;
        private List<string> stringList;

        public Task1(List<int> _integerList, List<string> _stringList)
        {
            this.integerList = new List<int>(_integerList);
            this.stringList = new List<string>(_stringList);
        }

        public List<string> MethodForTask1()
        {
            List<string> res = new List<string>();

            var res1 = stringList.
                Where(x => char.IsDigit(x.First())).
                ToList();
            //res = integerList.Aggregate(res, (x, y) => (List<string>)x.Where(el => el.Length == y)).ToList();
            //res = res.SelectMany(integerList, x => x.Length == integerList.GetRange(0, integerList.Count));
            //var step = res.Join(integerList, s => s, n => n, (s, n) => new { Str = s, Num = n }).ToList();
            //var step = integerList.Join(stringList, s => s, n => n, (s, n) => new { Str = s, Num = n }).ToList();
            int n = 5;
            var t = stringList.Where(el => el.Length == n && char.IsDigit(el.First()));


            var k = integerList
                .GroupJoin(stringList, i => i, str => str[0], (i, strCollection) => new
            {
                Number = i,
                    //Str = from el in (stringList
                    //      .Where(el => char.IsDigit(el.First()) && el.Length == i)
                    //      .Select(el => el))

                Str = stringList
                    .Where(el => char.IsDigit(el.First()) && el.Length == i)
                    .Select(el => el)
                    .Count() == 0 
                    ? "Не знайдено" : 
                    stringList
                    .Where(el => char.IsDigit(el.First()) && el.Length == i)
                    .Select(el => el)
                    .First()
        });

            //var myStr = stringList
            //        .Where(el => char.IsDigit(el.First()) && el.Length == 22)
            //        .Select(el => el).Count() == 0? "fefef": stringList
            //        .Where(el => char.IsDigit(el.First()) && el.Length == 22)
            //        .Select(el => el)
            //        .First();

            //if (myStr.Count() == 0)
            //{
            //    Console.WriteLine("nullll");
            //}

            foreach (var item in k)
            {
                Console.Write($"{item.Number}:\t {item.Str}\t");
                //foreach (string el in item.Str)
                //{
                //    Console.Write(el + "\t");
                //}
                Console.WriteLine();
            }

            //for (int i = 0; i<integerList.Count; i++)
            //{
            //    List<string> step = res1.Where(el=>el.Length == integerList[i]).ToList();

            //    if(step.Count>0)
            //    {
            //        res.Add(step[0]);
            //    }
            //    else
            //    {
            //        res.Add("Не знайдено");
            //    }
            //}
            return res;


        }
    }
    class Person
    {
        public string Name { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }
}
