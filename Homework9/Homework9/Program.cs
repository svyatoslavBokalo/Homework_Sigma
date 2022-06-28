// See https://aka.ms/new-console-template for more information
using Homework9;
Console.WriteLine("Hello, World!");
string keyProduct = null;
try
{
    Menu menu = new Menu("Menu.txt");
    Console.WriteLine(menu);

    Dictionary<string, double> tryWeight = null;
    MenuService.TryWeight(menu, out tryWeight);
    foreach (KeyValuePair<string, double> pair in tryWeight)
    {
        Console.WriteLine($"{pair.Key}:{pair.Value}");
    }
    Console.WriteLine();

    PriceKurant priceKurant = new PriceKurant("Prices.txt");
    Console.WriteLine(priceKurant);

    Dictionary<string, double> totalSum = MenuService.TotalSumProduct(menu, priceKurant,out keyProduct);
    foreach (KeyValuePair<string, double> pair in totalSum)
    {
        Console.WriteLine($"{pair.Key}:{pair.Value}");
    }

}
catch(InvalidDataException ex)
{
    Console.WriteLine(ex.Message);
}
catch(FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch(KeyNotFoundException ex)
{
    Console.WriteLine(ex.Message);
    if(keyProduct != null)
    {
        ActionOnFile.WritePriceProductOnFile(keyProduct, UseMenu.WritePrice(), "Prices.txt");
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
