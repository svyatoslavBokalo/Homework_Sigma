// See https://aka.ms/new-console-template for more information
using System.Text;
using task1;
Console.WriteLine("Hello, World!");

Dictionary<string, string> dictionary;
List<StringBuilder> text;
try
{
    text = Reader.ReadText(@"../../../Text.txt");
    dictionary = Reader.ReadDictionre(@"../../../Dictionary.txt");
    Translator translator = new Translator();
    translator.AddDictionary(dictionary);
    foreach (StringBuilder i in text)
    {
        translator.AddText(i);
    }

    StringBuilder changedText = translator.ChangeWords();
    Console.WriteLine(changedText);
}
catch (FileNotFoundException)
{
    Console.WriteLine("FileNotFoundException");
}
catch (ArgumentException)
{
    Console.WriteLine("ArgumentException");
}
