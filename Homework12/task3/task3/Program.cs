// See https://aka.ms/new-console-template for more information
using task3;
Console.WriteLine("Hello, World!");

try
{
    UsePolandRecord.WriteLineFormul();
}
catch(PolandRecordException ex)
{
    Console.WriteLine(ex.Message);  
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
