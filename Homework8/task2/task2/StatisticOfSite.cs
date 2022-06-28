using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class StatisticOfSite
    {
        List<Adress> adresses;

        public StatisticOfSite()
        {
            this.adresses = new List<Adress>();
        }
        public StatisticOfSite(List<Adress> adresses)
        {
            this.adresses = adresses;
        }

        public StatisticOfSite(string fileName)
        {
            this.adresses = new List<Adress>();
            ReadFromFile(fileName);
        }

        public void ReadFromFile(string fileName)
        {
            if(File.OpenRead(fileName) == null) 
            {
                throw new FileNotFoundException($"not found the file: {fileName}");
            }
            using(StreamReader sr = new StreamReader(fileName))
            {
                string line = "";

                while ((line = sr.ReadLine()) != null)
                {
                    adresses.Add(new Adress(line));
                }
            }
        }

        public override string? ToString()
        {
            string res = "";
            foreach(Adress adress in adresses)
            {
                res+=adress.ToString()+"\n";
            }
            return res;
        }

        public List<string> UniqueIpAdress()
        {
            List<Adress> lst = adresses.DistinctBy(el => el.Ip).ToList();
            List<string> res = new List<string>();
            foreach(Adress adress in lst)
            {
                res.Add(adress.Ip);
            }
            return res;
        }

        public void CountVisit()
        {
            try
            {
                List<string> unique = UniqueIpAdress();
                int[] count = new int[unique.Count];
                for (int i = 0; i < unique.Count; i++)
                {
                    for (int j = 0; j < adresses.Count; j++)
                    {
                        if (unique[i] == adresses[j].Ip)
                        {
                            count[i]++;
                        }
                    }
                }

                for (int i = 0; i < unique.Count; i++)
                {
                    Console.WriteLine($"{unique[i]} - {count[i]}");
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine("inccorect. count of unique ip");
            }
            
        }

        public List<string> DaysOfTheWeek()
        {
            List<Adress> lst = adresses.DistinctBy(el => el.Day).ToList();
            List<string> days = new List<string>();
            foreach(var adress in lst)
            {
                days.Add(adress.Day);
            }
            return days;
        }
        public List<KeyValuePair<string, int>> VisitingDayOfTheWeek()
        {
            List<string> days = DaysOfTheWeek();
            int[] count  = new int[days.Count];
            for (int i = 0; i < days.Count; i++)
            {
                for (int j = 0; j < adresses.Count; j++)
                {
                    if (days[i] == adresses[j].Day)
                    {
                        count[i]++;
                    }
                }
            }
            List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>();
            for(int i = 0; i < days.Count; i++)
            {
                result.Add(new KeyValuePair<string, int>(days[i], count[i]));
            }
            return result;
        }
        public List<KeyValuePair<string, int>> TheMostPopularDay()
        {
            List<KeyValuePair<string, int>> lst = VisitingDayOfTheWeek();
            int max = lst.Max(el=>el.Value);
            List<KeyValuePair<string, int>> res = lst.Where(el=>el.Value == max).ToList();
            return res;
        }

        public List<int> ListOfHours()
        {
            List<Adress> lst = adresses.DistinctBy(el => el.Date.Hour).ToList();
            List<int> res = new List<int>();
            foreach (var adress in lst)
            {
                res.Add(adress.Date.Hour);
            }
            return res;
        }

        public List<KeyValuePair<int,int>> HoursStatistic()
        {
            List<int> lst = ListOfHours();
            int[] count = new int[lst.Count];
            for (int i = 0; i < lst.Count; i++)
            {
                for (int j = 0; j < adresses.Count; j++)
                {
                    if (lst[i] == adresses[j].Date.Hour)
                    {
                        count[i]++;
                    }
                }
            }
            List<KeyValuePair<int, int>> res = new List<KeyValuePair<int, int>>();
            for (int i = 0; i < lst.Count; i++)
            {
                res.Add(new KeyValuePair<int, int>(lst[i], count[i]));
            }
            return res;
        }

        public List<KeyValuePair<int, int>> TheMostPopularHours()
        {
            List<KeyValuePair<int, int>> lst = HoursStatistic();
            int max = lst.Max(el => el.Value);
            List<KeyValuePair<int, int>> res = lst.Where(el => el.Value == max).ToList();
            return res;
        }
    }
}
