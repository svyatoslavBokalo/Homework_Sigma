using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CassApp.Data
{
    internal static class ClientsParser
    {

        public static Client Parse(string text)
        {
            Random random = new Random();
            string[] atributes = text.Split();
          
            return new Client
                (atributes[0], 
                atributes[2],
                int.Parse(atributes[3]),
                double.Parse(atributes[4]),
                int.Parse(atributes[5]));
        }
    }
}
