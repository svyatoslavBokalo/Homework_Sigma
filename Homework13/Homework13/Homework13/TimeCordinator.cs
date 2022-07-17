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
            //for (int i = 0; i < casses.Count; i++)
            //{
            //    //this.casses[i].Cordinate = casses[i].Cordinate;
            //    while (!casses[i].IsEmpty())
            //    {
            //        this.casses[i].EnqueueOrAdd(casses[i].Dequeue());
            //    }
            //}

            foreach(Cassa cassa in casses)
            {
                this.casses.Add(cassa);
            }

        }

        public List<string> Cordinate(/*List<Cassa> casses,*/ string path)
        {
            //foreach(var casa in casses)
            //{
            //    casa.OnEventCassa += HandlerCassaEvent;
            //}

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
                    casses[indexMin].EnqueueOrAdd(persons[counter++]);
                    casses[indexMin].Sort();
                }

                //if(time == ConstCassa.timeCloseCassa)
                //{
                //    int rndCassa = random.Next(0, casses.Count);
                //    Console.WriteLine($"Close casse: {rndCassa}");
                //    CloseCassa(rndCassa/*, casses*/);
                //}

                int number = 0;
                foreach (var item in casses)
                {
                    ++number;
                    if (!item.IsEmpty() && --item.Peek().TimeServise <= 0)
                    {
                        IClient el = item.DequeueOrRemove();
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
            int min = 0;
            for (int i = 0; i < casses.Count; i++)
            {
                if(casses[i] != null)
                {
                    min = casses.Min(el => el.Count);
                }
            }
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

        //public void CloseCassa(int cassaNumber/*, List<Cassa> casses*/)
        //{
        //    while (!casses[cassaNumber].IsEmpty())
        //    {
        //        IClient client = casses[cassaNumber].Dequeue();
        //        Console.WriteLine($"my client is: \t\t{client.ToString()}");
        //        casses[GetNumberCassa(client, /*casses, */cassaNumber)].Enqueue(client);
        //    }
        //}

        //public void HandlerCassaEvent(string str, Cassa cassa)
        //{
        //    int number = random.Next(0, casses.Count);
            
        //}

    }
}
