﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_3
{
    internal class Reader : IExpresionReader
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

        public Reader(string filePath)
        {
            this.filePath = filePath;
        }

        public Reader()
        {
            filePath = "..\\..\\Files\\Client.txt";
        }

        public List<string> ReadExpresion(string filePath = @"C:\Users\PC\homework\Homework_Sigma\Homework13\Homework13\Files\Client.txt")
        {
            if (filePath == null || filePath == "") throw new FileNotFoundException();
            if (!File.Exists(filePath))  File.Create(filePath);

            List<string> result = new();
            using(StreamReader sr = new(filePath))
            {
                while (!sr.EndOfStream)
                {
                    result.Add(sr.ReadLine());
                }
                sr.Close();
            }

            return result;
        }
    }
}
