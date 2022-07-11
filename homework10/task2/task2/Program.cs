// See https://aka.ms/new-console-template for more information
using task2;
Console.WriteLine("Hello, World!");
try
{
    Matrix matrix = new Matrix(4, 5);
    matrix.RandomFill();

    Console.WriteLine(matrix.ToString());
    Console.WriteLine();

    Console.Write("input number of view matrix(vertical - 1 or gorizontal - 2): \t");
    matrix.ViewMatrix = int.Parse(Console.ReadLine());
    int j = 0;
    int i = 0;

    foreach (var el in matrix)
    {
        j++;
        i++;
        Console.Write(el.ToString() + " ");
        if(matrix.ViewMatrix == 1)
        {
            if (j % matrix.M == 0)
            {
                Console.WriteLine();
            }
        }
        else
        {
            if (i % matrix.N == 0)
            {
                Console.WriteLine();
            }
        }
        
    }
    Console.WriteLine();
}
catch(IndexOutOfRangeException ex)
{
    Console.WriteLine(ex.Message);
}