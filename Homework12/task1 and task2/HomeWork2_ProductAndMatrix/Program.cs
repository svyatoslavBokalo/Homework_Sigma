// See https://aka.ms/new-console-template for more information
using HomeWork2_ProductAndMatrix;

Console.WriteLine("Hello, World!");
//Console.BackgroundColor = ConsoleColor.Red;
try
{
    GeneralService.Run();
    //Storage storage = new Storage();
    //storage.OnProductEventHandler += UseStorage.Message;
    //storage.ReadFromFile();
    //UseStorage.Show(storage);
}
catch(FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);  
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

