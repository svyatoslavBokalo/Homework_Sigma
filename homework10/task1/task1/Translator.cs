using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Translator
    {
        private Dictionary<string, string> vocabluary;
        private StringBuilder text;
        private string pathToText;
        private string pathToDictionary;
        private const int countVariedle = 3;

        public Translator() : this(@"../../../Text.txt", @"../../../Dictionary.txt")
        {

        }

        public Translator(string pathToText, string pathToDictionary)
        {
            vocabluary = new Dictionary<string, string>();
            text = new StringBuilder();
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabluary, StringBuilder text, string pathToText, string pathToDictionary)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.vocabluary = vocabluary;
            this.text = text;
        }

        public void AddText(StringBuilder text)
        {
            this.text.Append(text);
        }

        public void AddDictionary(Dictionary<string, string> dictionary)
        {
            this.vocabluary = dictionary;
        }

        //public string ChangeWords()
        //{
        //    string result = "";
        //    string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        //    foreach (string word in words)
        //    {
        //        char temp = ' ';
        //        string tempWord = "";
        //        int i = 0;
        //        if (Char.IsPunctuation(word[word.Length - 1]))
        //        {
        //            temp = word[word.Length - 1];
        //            while (!vocabluary.ContainsKey(word[0..^1]) && i < countVariedle)
        //            {
        //                AddToDictionary(word[0..^1]);
        //                i++;
        //            }
        //            tempWord = vocabluary[word[0..^1]] + temp;
        //        }
        //        else
        //        {
        //            while (!vocabluary.ContainsKey(word) && i < countVariedle)
        //            {
        //                AddToDictionary(word);
        //                i++;
        //            }
        //            tempWord = vocabluary[word];
        //        }
        //        result += tempWord + " ";
        //    }

        //    return result;
        //}


        public StringBuilder ChangeWords()
        {

            StringBuilder result = text;
            int i = 0;
            var mas = result.ToString().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(string word in mas)
            {
                char temp = ' ';
                char letter = ' ';
                string tempWord = "";
                if (Char.IsPunctuation(word[word.Length - 1]))
                {
                    while (!vocabluary.ContainsKey(word[0..^1].ToLower()) && i < countVariedle)
                    {
                        AddToDictionary(word[0..^1]);
                        i++;
                    }
                    temp = word[word.Length - 1];
                    letter = char.IsUpper(word[0..^1][0]) ? char.ToUpper(vocabluary[word[0..^1].ToLower()][0]) : vocabluary[word[0..^1].ToLower()][0];
                    tempWord = letter + vocabluary[word[0..^1].ToLower()][1..] + temp;
                    result.Replace(word, tempWord);
                }
                else
                {
                    while (!vocabluary.ContainsKey(word.ToLower()) && i < countVariedle)
                    {
                        AddToDictionary(word);
                        i++;
                    }
                    letter = char.IsUpper(word[0]) ? char.ToUpper(vocabluary[word.ToLower()][0]) : vocabluary[word.ToLower()][0];
                    tempWord = letter + vocabluary[word.ToLower()][1..];
                    result.Replace(word, tempWord);
                }
            }
            return result;

        }

        

        private void AddToDictionary(string word)
        {
            Console.WriteLine($"Введiть замiну для слова {word}");
            string value = Console.ReadLine();
            vocabluary.Add(word, value);
            Reader.WriteToDictionary(word, value, @"../../../Dictionary.txt");
        }
    }
}
