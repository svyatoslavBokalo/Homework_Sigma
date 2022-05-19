// See https://aka.ms/new-console-template for more information
using HomeWork2_ProductAndMatrix;

Console.WriteLine("Hello, World!");

try
{
    int number = 0;
    bool check = true;
    Storage storage = new Storage();

    while (check)
    {
        UseStorage.ShowMenu();
        Console.WriteLine();
        Console.Write("input number: ");
        number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 1:
                {
                    check = false;
                }
                break;
            case 2:
                {
                    Console.Write("input file name: ");
                    string fileName = Console.ReadLine();
                    storage = new Storage(fileName);
                }
                break;
            case 3:
                {
                    UseStorage.Show(storage);
                }
                break;
            case 4:
                {
                    storage.Add(UseStorage.InputFromConsole());
                }
                break;
            case 5:
                {
                    Storage res = storage.JustProductOfName("meat");
                    UseStorage.Show(res);
                }
                break;
            case 6:
                {
                    Console.Write("input per cent: ");
                    double perCent = double.Parse(Console.ReadLine());
                    storage.PriceChange(perCent);
                }
                break;
            case 7:
                {
                    Console.Write("input number of list: ");
                    int n = int.Parse(Console.ReadLine());
                    Console.WriteLine(storage[n]);
                }
                break;
            default:
                {
                    Console.WriteLine("\t\t inccorect number!!!");
                }
                break;
        }

        Console.WriteLine();
    }
}
catch (ExceptionPrice ex)
{
    Console.WriteLine(ex.Message);
}
catch(ExpceptionWeight ex)
{
    Console.WriteLine(ex.Message);
}
catch(ArithmeticException ex)
{
    Console.WriteLine(ex.Message);
}
catch(ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}

