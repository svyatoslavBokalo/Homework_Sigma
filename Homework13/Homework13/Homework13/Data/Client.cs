using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Data
{
    internal class Client: IClient
    {
        string name;
        int timeServise;
        int age;
        double coordinate;
        string status;

        public Guid Id { get; }
        public int TimeServise 
        { 
            get => timeServise;
            set
            {
                timeServise = value;
            }
        }

        public string Status { get => status; }

        public double Coordinate
        {
            get
            {
                return coordinate;
            }
        }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        //double IClient.Coordinate => throw new NotImplementedException();

        public Client() : this("", default, default, default, default) { }

        public Client(string status,string name, int age, double coordinate, int timeServise)
        {
            Id = Guid.NewGuid();
            this.name = name;
            this.age = age;
            this.coordinate = coordinate;
            this.status = status;
            this.timeServise = timeServise;
        }

        public override string ToString()
        {
            return $"[{status}] - {name} {age} {Math.Round(coordinate, 3)} {timeServise}";
        }
    }
}
