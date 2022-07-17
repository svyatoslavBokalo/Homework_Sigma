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
        List<IClient> queuePersons;

        public event CassaDelegate OnEventCassa;

        public int Count { get => queuePersons.Count; }
        public double Cordinate { get => cordinate;}

        public Cassa()
        {
            queuePersons = new List<IClient>();
            cordinate = 0;
        }

        public Cassa(double cordinate)
        {
            queuePersons = new List<IClient>();
            this.cordinate = cordinate;
        }

        public Cassa(Cassa cassa)
        {
            queuePersons = new List<IClient>();
            foreach(IClient client in cassa.queuePersons)
            {
                this.queuePersons.Add(client);
            }
            cordinate = cassa.Cordinate;
        }

        public bool IsEmpty()
        {
            return queuePersons.Count == 0;
        }

        public void EnqueueOrAdd(IClient person)
        {
            if(queuePersons.Count >= ConstCassa.countOfClientInCassa)
            {
                OnEventCassa?.Invoke($"cassa has more than {ConstCassa.countOfClientInCassa}", this);
            }
            else
            {
                queuePersons.Add(person);
            }
        }

        public IClient DequeueOrRemove()
        {
            queuePersons.Remove(queuePersons[0]);
            return queuePersons[0];
        }
        public IClient DequeueOrRemove(IClient person)
        {
            queuePersons.Remove(person);
            return person;
        }

        public void Sort()
        {
            queuePersons.Sort(new CompererClientByStatusAndAge());
        }

        public IClient Peek()
        {
            return queuePersons[0];
        }

    }
}
