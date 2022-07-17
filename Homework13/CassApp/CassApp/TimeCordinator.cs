using CassApp.Data;
using Task12_3;

namespace CassApp
{
    internal class TimeCordinator
    {
        int timeCounter = 5;
        Random random = new Random();
        Writer writer;
        List<Cassa> casses;

        public TimeCordinator(List<Cassa> casses)
        {
            this.casses = new List<Cassa>();
            foreach(Cassa cassa in casses)
            {
                this.casses.Add(cassa);
            }
            //for (int i = 0; i < casses.Count; i++)
            //{
            //    //this.casses[i].Cordinate = casses[i].Cordinate;
            //    while (!casses[i].IsEmpty())
            //    {
            //        this.casses[i].Enqueue(casses[i].Dequeue());
            //    }
            //}
        }


        public List<string> Cordinate(/*List<Cassa> casses,*/ string path)
        {
            foreach (var casa in casses)
            {
                casa.OnEventCassa += HandlerCassaEvent;
            }

            bool isProcess = true;
            int counter = 0;
            int time = 0;
            ClientGenerator cGen = new ClientGenerator();
            List<Client> persons = cGen.Generate();
            List<string> result = new List<string>();
            writer = new Writer(@"C:\Users\PC\source\repos\C#\SigmaTestProject\30.06.2022 queue\CassApp\CassApp\Files\ResultCassa.txt");

            while (isProcess)
            {
                time++;

                if (time % timeCounter == 0 && counter < persons.Count)
                {
                    int indexMin = GetNumberCassa(persons[counter]/*, casses*/);
                    Console.WriteLine($"{persons[counter]}");
                    writer.WriteOnFile(persons[counter].ToString());

                    //if(casses[indexMin].Count > ConstCassa.countOfClientInCassa)
                    //{
                    //    casses[indexMin].OnEventCassa("cassa is full") += CassaService.Message;
                    //}
                    casses[indexMin].Enqueue(persons[counter++]);
                }

                if (time == ConstCassa.timeCloseCassa)
                {
                    int rndCassa = random.Next(1, casses.Count);
                    Console.WriteLine($"Close casse: {rndCassa}");
                    CloseCassa(rndCassa/*, casses*/);
                    casses.Remove(casses[rndCassa]);
                }

                int number = 0;
                foreach (var item in casses)
                {
                    ++number;
                    if (!item.IsEmpty() && --item.Peek().TimeServise <= 0)
                    {
                        var el = item.Dequeue();
                        result.Add($"Cassa_{number}: {el} has been observed");
                        writer.WriteOnFile($"Cassa_{number}: {el} has been observed");
                        Console.WriteLine(result[result.Count-1]);
                    }
                    Thread.Sleep(10);
                }
               
            }

            return result;
        }


        public int GetNumberCassa(IClient client,/*List<Cassa> casses, */int cassaNumber = -1)
        {
            //int min = 0;
            //for (int i = 0; i < casses.Count; i++)
            //{
            //    if(casses[i] != null)
            //    {
            //        min = casses.Min(el => el.Count);
            //    }
            //}
            int min = casses.Min(el => el.Count);
            int indexMin = 0;
            bool isSame = true;

            for(int i = 0; i < casses.Count; i++)
            {
                if (i != cassaNumber)
                {
                    if (casses[i].Count == min)
                    {
                        indexMin = i;
                    }
                    else
                    {
                        isSame = false;
                    }
                }
            }

            if (isSame)
            {
                double distance = double.MaxValue;
                for(int i = 0; i < casses.Count; i++)
                {
                    if (i != cassaNumber)
                    {
                        if (Math.Abs(casses[i].Cordinate - client.Coordinate) < distance)
                        {
                            distance = Math.Abs(casses[i].Cordinate - client.Coordinate);
                            indexMin = i;
                        }
                    }
                }
            }

            return indexMin;
        }

        public void CloseCassa(int cassaNumber/*, List<Cassa> casses*/)
        {
            while (!casses[cassaNumber].IsEmpty())
            {
                IClient client = casses[cassaNumber].Dequeue();
                Console.WriteLine($"my client is: \t\t{client.ToString()}");
                casses[GetNumberCassa(client, /*casses, */cassaNumber)].Enqueue(client);
            }
            //casses.Remove(casses[cassaNumber]);
        }

        public void HandlerCassaEvent(string str, Cassa cassa)
        {
            //int number = random.Next(1, casses.Count);
            //switch (eventBoolResult)
            //{
            //    case true:
            //        {
            //            MethodForEventHandler(str, cassa);
            //            Const
            //        }
            //        break;
            //}
            List<IClient> clientsCopy = new List<IClient>();
            List<IClient> cassaClients = new List<IClient>();
            List<Cassa> cassaList = new List<Cassa>();
            int indexCassa = casses.IndexOf(cassa);

            foreach (Cassa el in casses)
            {
                cassaList.Add(el);
            }
            foreach (var el in cassaList)
            {
                while (!el.IsEmpty())
                {
                    clientsCopy.Add(el.Dequeue());
                }
            }

            cassaClients = clientsCopy.Where(el => el.Status == "[status1]").ToList();
            cassa.Clear();
            foreach (var client in cassaClients)
            {
                cassa.Enqueue(client);
            }
            clientsCopy.RemoveAll(el => el.Status == "[status1]");
            foreach (var client in clientsCopy)
            {
                casses[GetNumberCassa(client, indexCassa)].Enqueue(client);
            }
        }


    }
}
