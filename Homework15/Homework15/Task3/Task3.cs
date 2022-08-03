using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework15
{
    internal class Task3
    {
        List<Information> nameList;
        List<int> years;

        public Task3(List<Information> _nameList, List<int> _years)
        {
            this.nameList = new List<Information>(_nameList);
            this.years = new List<int>(_years);
        }

        public void LinqTask3()
        {

            var res = years
                .Distinct()
                .GroupJoin(nameList, year => year, name => name.School, (year, schoolCollection) => new
                {
                    Year = year,
                    CountSchool = nameList.DistinctBy(el=>el.School).Count(el=> el.Year == year)
                });

            foreach(var item in res)
            {
                Console.Write($"{item.Year}: \t {item.CountSchool}");
                Console.WriteLine();
                
            }
            //List<KeyValuePair<int, int>> res = new List<KeyValuePair<int, int>>();
            //for(int i = 0; i < years.Count; i++)
            //{
            //    List<string> step = nameList.Where(x=> int.Parse(x.Split()[1]) == years[i]).ToList();
            //    if(step.Count > 0)
            //    {
            //        res.Add(new KeyValuePair<int, string>(i, step.Where(el=> el.Split()[0].)
            //    }            
            //}
        }
    }
}
