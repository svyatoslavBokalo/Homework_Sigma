using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampWork1_Vector_
{
    internal class Vector
    {
        int[] arr;


        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new Exception("Index out of range array");
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public Vector(int[] arr)
        {
            this.arr = arr;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public Vector() { }

        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()
        {
            //int index = Array.IndexOf(arr, 2);
            //Console.WriteLine(index);

            Random random = new Random();
            int x;
            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] == 0)
                {
                    x = random.Next(1, arr.Length + 1);
                    bool isExist = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (x == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        arr[i] = x;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];
            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair();
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }

        public void TheLongestSubsequence(out int index, out int maxLenght)
        {
            index = 0;
            maxLenght = 0;
            int currentIndex = 0;
            int currentLenght = 1;

            for(int i = 1; i < arr.Length; i++)
            {
                if(arr[i] == arr[i - 1])
                {
                    currentLenght++;
                }
                else
                {
                    if (currentLenght > maxLenght)
                    {
                        maxLenght = currentLenght;
                        index = currentIndex;
                    }
                    currentIndex = i;
                    currentLenght = 1;

                }
            }

            if (currentLenght > maxLenght)
            {
                maxLenght = currentLenght;
                index = currentIndex;
            }

        }

        public bool IsPalindrom()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    return false;
                }
            }
            return true;
        }

        public void MyReverse()
        {
            int[] buff = new int[arr.Length];
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                buff[arr.Length - i - 1] = arr[i];
            }

            this.arr = buff;
        }

        public void Swap(ref int x, ref int y)
        {
            int buff = x;
            x = y;
            y = buff;
        }

        public int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        public int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }

        public void QuickSort()
        {
            QuickSort(arr, 0, arr.Length - 1);
        }
        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }
    }
}
