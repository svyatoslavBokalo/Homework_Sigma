﻿using CassApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_3
{
    internal class Writer
    {
        private string filePath;

        public string FilePAth
        {
            get => filePath;
            set
            {
                if (value != null) filePath = value;
            }
        }

        public Writer(string filePath)
        {
            this.filePath = filePath;
        }

        public Writer()
        {

            filePath = @"C:\Users\PC\homework\Homework_Sigma\Homework13\Homework13\Files\Client.txt";
        }

        public void WritePerson(Client person, string filePath = @"C:\Users\PC\homework\Homework_Sigma\Homework13\Homework13\Files\Client.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                    sw.WriteLine(person.ToString());
                sw.Close();
            }
        }

        public void WriteOnFile(string str)
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath)) File.Create(filePath);

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine(str);
                sw.Close();
            }
        }
    }
}
