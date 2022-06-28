// See https://aka.ms/new-console-template for more information
using StringWorkAndElectricityClass;
using System;
using System.Globalization;

Console.WriteLine("Hello, World!");

/// <summary>
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///                                     task 1
/// </summary>
/// 

AccountingElectricity accounting = new AccountingElectricity();
try
{
    Console.ForegroundColor= ConsoleColor.Red;
    Console.WriteLine("\t\t TASK 1 \t\t");
    Console.ForegroundColor= ConsoleColor.Gray;
    using (StreamReader sr = new StreamReader("electricityAccountingData.txt"))
    {
        accounting = new AccountingElectricity(sr);
    }
    Console.WriteLine(accounting);

    //// зберігання у файл
    //Console.Write("input file name for data storage: \t");
    //string fileName = Console.ReadLine();
    //accounting.WriteToFile(fileName);
    ////


    // найбільший боржник
    Console.WriteLine(accounting.SurnameArrears());
    //

    // не використовують електроенергію
    Console.WriteLine(accounting.SurnameWhoIsNotConsumeElectricity());
    //

    // сума витрат
    accounting.AmountOfCost();
    //

    // різниця між датами
    accounting.ShowDifferenceDate();
    //

    // друк інформації по номеру квартири
    Console.WriteLine(accounting.CheckOneApartment(42));
    //

}
catch (FileNotFoundException ex)
{
    Console.WriteLine(ex.Message);
}
catch (FormatException ex)
{
    Console.WriteLine(ex.Message);
}
catch (IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidDataException ex)
{
    Console.WriteLine(ex.Message);
}
catch (InvalidTimeZoneException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}