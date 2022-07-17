// See https://aka.ms/new-console-template for more information

using CassApp;

Console.WriteLine("Hello, World!");
Cassa cassa = new Cassa();
TimeCordinator timeCordinator = new TimeCordinator(new List<Cassa>
            {
                (new Cassa (22.0)),
                (new Cassa (11.0)),
                (new Cassa (00.0))
            });


timeCordinator.Cordinate(@"C:\Users\PC\homework\Homework_Sigma\Homework13\Homework13\Files\ResultCassa.txt");
