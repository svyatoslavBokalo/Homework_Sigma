using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal delegate void CassaDelegate(string str, Cassa cassa);
    internal class Cassa: ICassa
    {
        private double cordinate;       
        PriorityQueue<IClient, IClient> queuePersons;

        public event CassaDelegate OnEventCassa;

        public int Count { get => queuePersons.Count; }
        public double Cordinate { get => cordinate;}

        public Cassa()
        {
            queuePersons = new PriorityQueue<IClient, IClient>(new CompererClientByStatusAndAge());
            cordinate = 0;
        }

        public Cassa(double cordinate)
        {
            queuePersons = new PriorityQueue<IClient, IClient>(new CompererClientByStatusAndAge());
            this.cordinate = cordinate;
        }

        public Cassa(Cassa cassa)
        {
            queuePersons = cassa.queuePersons;
            cordinate = 0;
        }
        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }

        public void Enqueue(IClient person)
        {
            if(queuePersons.Count >= ConstCassa.countOfClientInCassa)
            {
                Console.WriteLine("\t\t подія спрацювала \t\t");
                OnEventCassa?.Invoke($"cassa has more than {ConstCassa.countOfClientInCassa}", this);
            }
            else
            {
                queuePersons.Enqueue(person, person);
            }
        }

        public IClient Dequeue()
        {
            return queuePersons.Dequeue();
        }

        public IClient Peek()
        {
            return queuePersons.Peek();
        }

        public void Clear()
        {
            queuePersons.Clear();
        }
    }
}
