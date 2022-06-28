// See https://aka.ms/new-console-template for more information
using task2;
Console.WriteLine("Hello, World!");
try
{
    StatisticOfSite statisticOfSite = new StatisticOfSite("data.txt");
    Console.WriteLine(statisticOfSite);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("count of visit ip");
    Console.ForegroundColor = ConsoleColor.Gray;
    statisticOfSite.CountVisit();

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("count of the days");
    Console.ForegroundColor = ConsoleColor.Gray;
    List<KeyValuePair<string, int>> list = statisticOfSite.VisitingDayOfTheWeek();
    foreach(KeyValuePair<string, int> el in list)
    {
        Console.WriteLine($"{el.Key} - {el.Value}");
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("the most popular days");
    Console.ForegroundColor = ConsoleColor.Gray;
    List<KeyValuePair<string, int>> theMostPopularDays = statisticOfSite.TheMostPopularDay();
    foreach (KeyValuePair<string, int> el in theMostPopularDays)
    {
        Console.WriteLine($"{el.Key} - {el.Value}");
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("unique hour and visit in this hour");
    Console.ForegroundColor = ConsoleColor.Gray;
    List<KeyValuePair<int, int>> hours = statisticOfSite.HoursStatistic();
    foreach(KeyValuePair<int, int> el in hours)
    {
        Console.WriteLine($"hour: {el.Key} - count: {el.Value}");
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("the most popular hours");
    Console.ForegroundColor = ConsoleColor.Gray;
    hours = statisticOfSite.TheMostPopularHours();
    foreach (KeyValuePair<int, int> el in hours)
    {
        Console.WriteLine($"hour: {el.Key} - count: {el.Value}");
    }
}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch(IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}