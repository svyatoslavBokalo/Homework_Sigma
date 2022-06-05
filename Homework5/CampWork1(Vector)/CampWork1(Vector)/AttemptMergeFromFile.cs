using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampWork1_Vector_
{
    public class AttemptMergeFromFile
    {
        private int[] arr;

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
        public void Merge(int l, int r, int q)
        {
            int i = l, j = q;
            int[] temp = new int[r - l + 1];
            int k = 0;
            while (i < q && j < r)
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i++];
                }
                else
                {
                    temp[k] = arr[j++];
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < r; m++)
                {
                    temp[k++] = arr[m];
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k] = arr[i];
                    i++;
                    k++;
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                this.arr[n + l] = temp[n];
            }
        }

        public static void Merge(StreamReader sr1, StreamReader sr2, StreamWriter sw)
        {
            int number1 = ReadNumberFromFile(sr1);
            int number2 = ReadNumberFromFile(sr2);
            //Console.WriteLine($"number1 = {number1}   number 2 = {number2}");
            while (!sr1.EndOfStream && !sr2.EndOfStream)
            {
                Console.WriteLine($"number1 = {number1}   number 2 = {number2}");
                if(number1 < number2)
                {
                    sw.Write(number1+ " ");
                    number1 = ReadNumberFromFile(sr1);
                    
                }
                else
                {
                    sw.Write(number2 + " ");
                    number2 = ReadNumberFromFile(sr2);
                }
            }

            if (!sr1.EndOfStream)
            {
                sw.Write(number2 + " ");
                while (!sr1.EndOfStream)
                {
                    sw.Write(number1 + " ");
                    number1 = ReadNumberFromFile(sr1);
                }
                sw.Write(number1 + " ");
            }
            else
            {
                sw.Write(number1 + " ");
                while (!sr2.EndOfStream)
                {
                    sw.Write(number2 + " ");
                    number2 = ReadNumberFromFile(sr2);
                }
            }
        }

        public static int ReadNumberFromFile(StreamReader sr)
        {
            string numberStr = "";
            char c;
            while (!sr.EndOfStream && (c = (char)sr.Read()) != ' ' )
            {
                if(c != ' ')
                {
                    numberStr += c;
                }
            }
            return int.Parse(numberStr);
        }
    }
}
