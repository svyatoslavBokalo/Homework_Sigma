using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class WorkOntheString
    {
        private string[] mas;
        private string line;
        //private string[] sentences;

        public WorkOntheString()
        {
            this.mas = new string[0];
            this.line += mas;
        }
        public WorkOntheString(string line)
        {
            this.mas = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach(string el in mas)
            {
                this.line += el + " ";
            }
        }
        public WorkOntheString(StreamReader sr)
        {
            ReadFromFile(sr);
            foreach (string el in mas)
            {
                this.line += el + " ";
            }
        }

        public void ReadFromFile(StreamReader sr) //зчитання з файлу
        {
            try
            {
                string line1 = "";
                while (!sr.EndOfStream)
                {
                    line1 += sr.ReadLine();
                    mas = line1.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("not found file");
            }
        }

        public override string? ToString()
        {
            string res = "";
            for(int i = 0; i < mas.Length; i++)
            {
                res += mas[i]+" ";
            }
            return res;
        }


        public void Editing() //для редагування стрічки
        {
            Console.Write($"input the number of word from 1 to {mas.Length}: ");
            int number  = int.Parse(Console.ReadLine());

            if(number < 1 || number > mas.Length)
            {
                throw new IndexOutOfRangeException("inccorect number of word for editing");
            }

            Console.Write("input word: ");
            string editWord = Console.ReadLine();

            mas[number - 1] = editWord;

        }

        public string[] SentencesFromFile()//розбивання на речення
        {
            char[] delimiterChars = {'?', '!', '.'};
            string[] myMas = line.Split(delimiterChars);

            return myMas;
        }

        public void WriteToFile(string fileName, params string[] mas)   //запис у файл
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string el in mas)
                {
                    sw.WriteLine(el);
                }
            }
        }

        public void PrintInFileReadyText(string fileName = "Result.txt")  //Запис по абзацу кожне речення
        {
            string[] mas = SentencesFromFile();
            WriteToFile(fileName, mas);
        }

        public List<string> TheLongestWordInSentences(string str)   // найдовше слова
        {
            List<string> res = new List<string>();
            //List<string> lst = new List<string>();
            string[] mas = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int max = mas.Max(el => el.Length);
            //int max = lst.Max(el => el.Length);
            res = mas.Where(el => el.Length == max).ToList();
            return res;
        }

        public List<string> TheShortestWordInSentences(string str)   // найкоротше слово
        {
            List<string> res = new List<string>();

            string[] mas = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int min = mas.Min(el => el.Length);
            res = mas.Where(el => el.Length == min).ToList();
            return res;
        }

        public void PrintTheLongestAndTheShortestWord()   //збірка слів найкоротших і найдовших слів в речені
        {
            string[] mas = SentencesFromFile();
            foreach(string el in mas)
            {
                List<string> minWord = TheShortestWordInSentences(el);
                List<string> maxWord = TheLongestWordInSentences(el);
                foreach(string i in minWord)
                {
                    Console.Write($"min word: {i} \t");
                }
                Console.WriteLine();
                foreach(string i in maxWord)
                {
                    Console.Write($"max word: {i} \t");
                }
                Console.WriteLine();
                //Console.Write($"min word: {minWord} \t |||| \t max word: {maxWord} \n");
            }
        }
    }
}
