// See https://aka.ms/new-console-template for more information
using task2;
Console.WriteLine("Hello, World!");
/// <summary>
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                     task 2
/// </summary>
WorkOntheString line = new WorkOntheString();
try
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\t\t TASK 2 \t\t");
    Console.ForegroundColor = ConsoleColor.Gray;
    using (StreamReader sr = new StreamReader("dataText.txt"))
    {
        line = new WorkOntheString(sr);
    }

    Console.WriteLine(line);
    Console.WriteLine();

    line.Editing();
    Console.WriteLine(line);

    Console.WriteLine();
    line.PrintInFileReadyText();

    line.PrintTheLongestAndTheShortestWord();
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}