using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp
{
    internal class CompererClientByStatusAndAge : IComparer<IClient>
    {
        public int Compare(IClient? x, IClient? y)
        {
            return x.Status.CompareTo(y.Status)>0? 1 :
                x.Status.CompareTo(y.Status)<0? -1:
                x.Age.CompareTo(y.Age)<=0? 1:-1;
        }
    }
}
