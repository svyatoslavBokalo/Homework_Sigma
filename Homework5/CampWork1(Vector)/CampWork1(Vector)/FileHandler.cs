using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CampWork1_Vector_
{
    internal class FileHandler
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public FileHandler() : this(null) { }
        public FileHandler(string path)
        {
            Path = path;
        }

        public void MergeWriteToFile(Vector firsVector, Vector secondVector, Trend trend)
        {
            int i = 0;
            int j = 0;
            using (StreamWriter reader = new StreamWriter(Path))
            {

                while (i < firsVector.Length && j < secondVector.Length)
                {
                    if (trend is Trend.increase)
                    {
                        if (firsVector[i] < secondVector[j])
                        {
                            reader.Write(firsVector[i++] + " ");
                        }
                        else
                        {
                            reader.Write(secondVector[j++] + " ");
                        }
                    }
                    else
                    {
                        if (firsVector[i] > secondVector[j])
                        {
                            reader.Write(firsVector[i++] + " ");
                        }
                        else
                        {
                            reader.Write(secondVector[j++] + " ");
                        }
                    }
                }
                if (i == firsVector.Length)
                {
                    while (j < secondVector.Length)
                    {
                        reader.Write(secondVector[j++] + " ");
                    }
                }
                else
                {
                    while (i < firsVector.Length)
                    {
                        reader.Write(firsVector[i++] + " ");
                    }
                }
            }

        }
        public IEnumerable<int> GetIntCollectionFromFile()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                string[] tmpString = reader.ReadToEnd().Trim().Split(' ');
                int[] tmpArray = new int[tmpString.Length];
                
                try
                {
                    for (int i = 0; i < tmpString.Length; i++)
                    {
                        tmpArray[i] = Convert.ToInt32(tmpString[i]);
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
                return tmpArray;
            };
        }
        public void WriteToFile(string data)
        {
            using (StreamWriter reader = new StreamWriter(Path))
            {
                reader.Write(data);
            }
        }
        public static string GetDirPath()
        {
            string exePath = Assembly.GetExecutingAssembly().Location;
            Console.WriteLine(exePath);
            string exeDir = System.IO.Path.GetDirectoryName(exePath);
            Console.WriteLine(exeDir);
            string binDir = Directory.GetParent(exeDir).ToString();
            Console.WriteLine(binDir);
            string myDir = Directory.GetParent(binDir).ToString();
            Console.WriteLine(myDir);
            Console.WriteLine(Directory.GetParent(myDir).ToString());
            return Directory.GetParent(myDir).ToString()+"\\";
        }

        public override string ToString()
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                return reader.ReadToEnd();
            }
        }
        public string ReadLineFromFile()//щоб не плутати назви
        {
            string line = null;
            using (StreamReader reader = new StreamReader(Path))
            {
                line = reader.ReadLine();
            }

            return line;
        }
    }
}
