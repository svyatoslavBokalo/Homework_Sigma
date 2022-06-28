using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class Adress
    {
        private string ip;
        private DateTime date;
        private string day;

        public string Ip 
        {
            get 
            {
                string[] mas = ip.Split('.');
                for(int i = 0;i< mas.Length; i++)
                {
                    if(!uint.TryParse(mas[i], out uint number))
                    {
                        throw new IndexOutOfRangeException("inccorect ip");
                    }
                }
                return ip;
            }
            set
            {
                string[] mas = value.Split('.');
                for (int i = 0; i < mas.Length; i++)
                {
                    if (!uint.TryParse(mas[i], out uint number))
                    {
                        throw new IndexOutOfRangeException("inccorect ip");
                    }
                }
                ip = value;
            } 
        }
        public DateTime Date { get => date; set => date = value; }
        public string Day { get => day; set => day = value; }

        public Adress()
        {
            this.Ip = "";
            this.date = new DateTime();
            this.day = "";
        }
        public Adress(string ip, DateTime date, string day)
        {
            this.Ip = ip;
            this.date = date;
            this.day = day;
        }

        public Adress(string str)
        {
            string[] mas = str.Split();
            this.Ip = mas[0];
            this.date = DateTime.Parse(mas[1]);
            this.day = mas[2];
        }

        public override string? ToString()
        {
            return $"ip adressa: {ip} \t || \t date = {date.TimeOfDay}\t || \t day = {day}";
        }
    }
}
