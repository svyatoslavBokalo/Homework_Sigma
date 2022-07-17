using CassApp.Data;
using Task12_3;

namespace CassApp
{
    internal class ClientGenerator
    {
        Random random = new Random();

        public List<Client> Generate()
        {
            Reader reader = new Reader();
            List<Client> persons = new List<Client>();
            List<string> otherPersons = reader.ReadExpresion();

            foreach (var item in otherPersons)
            {
                persons.Add(ClientsParser.Parse(item));
            }

            return persons;
        }

        public void WriteRandomGenerate(int UpRandomNumber)
        {
            for (int i = 0; i < UpRandomNumber; i++)
            {
                Writer write = new Writer();
                write.WritePerson(new Client($"status{random.Next(1, UpRandomNumber)}",
                    $"name{i}", random.Next(15, 40), random.NextDouble()*25,30
                    /*random.Next(1, UpRandomNumber + 10)*/));
            }

        }



    }
}
