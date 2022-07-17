namespace CassApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ClientGenerator cGen = new ClientGenerator();
            //cGen.WriteRandomGenerate(25);

            TimeCordinator timeCordinator = new TimeCordinator(new List<Cassa>
            {
                (new Cassa (22.0)),
                (new Cassa (11.0)),
                (new Cassa (00.0))
            });

            //timeCordinator.Print();
            timeCordinator.Cordinate(
            @"C:\Users\PC\source\repos\C#\SigmaTestProject\30.06.2022 queue\CassApp\CassApp\Client.txt");




            //Console.ReadLine();

        }
    }
}