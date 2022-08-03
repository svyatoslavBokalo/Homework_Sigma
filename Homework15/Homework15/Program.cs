// See https://aka.ms/new-console-template for more information
using Homework15;

Console.WriteLine("Hello, World!");
List<int> integerList = new List<int> { 3, 22, 5, 2 };
List<string> stringList = new List<string>
{
    "2e",
    "fefjmesifj",
    "4dnwi",
    "3dgdg",
    "ds"
};

Console.WriteLine();
Console.WriteLine("\t\t Task1");
Console.WriteLine();

Task1 task1 = new Task1(integerList, stringList);
List<string> res = task1.MethodForTask1();
//foreach (string el in res)
//{
//    Console.WriteLine(el);
//}

Console.WriteLine();
Console.WriteLine("\t\t Task2");
Console.WriteLine();

Task2 task2 = new Task2(stringList);
task2.LinqTask2();

Console.WriteLine();
Console.WriteLine("\t\t Task3");
Console.WriteLine();

List<Information> nameList = new List<Information>()
{
    new Information(75, 2002, "bokalo"),
    new Information(34, 2001, "gggg"),
    new Information(75, 1999, "nnnn"),
    new Information(23, 2002, "fefef"),
    new Information(74, 2002, "efefe"),
    new Information(34, 2001, "3333333"),
    new Information(75, 2002, "3ewrttewewe3")
};

List<int> years = new List<int>()
{
    2002,
    1998,
    2001
};
Task3 task3 = new Task3(nameList, years);
task3.LinqTask3();

//Person magnus = new Person { Name = "Hedlund, Magnus" };
//Person terry = new Person { Name = "Adams, Terry" };
//Person charlotte = new Person { Name = "Weiss, Charlotte" };

//Pet barley = new Pet { Name = "Barley", Owner = terry };
//Pet boots = new Pet { Name = "Boots", Owner = terry };
//Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
//Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

//List<Person> people = new List<Person> { magnus, terry, charlotte };
//List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

// Create a list where each element is an anonymous
// type that contains a person's name and
// a collection of names of the pets they own.
//var query =
//    people.GroupJoin(pets,
//                     person => person,
//                     pet => pet.Owner,
//                     (person, pets) =>
//                         new
//                         {
//                             OwnerName = person.Name,
//                             Pets = pets.Where().Select(pet => pet.Owner)
//                         });

//foreach (var obj in query)
//{
//     Output the owner's name.
//    Console.WriteLine("{0}:", obj.OwnerName);
//     Output each of the owner's pet's names.
//    foreach (string pet in obj.Pets)
//    {
//        Console.WriteLine("  {0}", pet);
//    }
//}