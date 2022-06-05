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

        public int Length { get => arr.Length; }

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

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }
            return str;
        }

        public void HardInitialization()
        {
            arr = new int[7] {12, 34, 5, 34, 12, 23, 67};
            
        }

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


        public bool IsPalindromNew()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
            //    if (arr[i] != arr[arr.Length - i - 1])
                if(arr[i] != arr[^(i+1)])
                {
                    return false;
                }
            }
            return true;
        }

        public void MyReverse()
        {
            //int[] buff = new int[arr.Length];
            //for(int i = arr.Length - 1; i >= 0; i--)
            //{
                
            //    buff[arr.Length - i - 1] = arr[i];
            //}

            //this.arr = buff;

            for(int i = 0; i < arr.Length / 2; i++)
            {
                (arr[i], arr[arr.Length - i - 1]) = (arr[arr.Length - i - 1], arr[i]);
            }
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

        void Merge(int l, int r, int q)
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
        public void SplitMergeSort()
        {
            SplitMergeSort(0, arr.Length);
        }
        public void SplitMergeSort(int start, int end)
        {
            if (end - start <= 1) return;
            int middle = (end + start) / 2;
            SplitMergeSort(start, middle);
            SplitMergeSort(middle, end);
            Merge(start, middle, end);
        }

        public void ReadFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            string line = null;

            while ((line = sr.ReadLine()) != null)
            {
                string[] mas = line.Split(' ');
                arr = new int[mas.Length];

                for(int i = 0; i < mas.Length; i++)
                {
                    arr[i] = int.Parse(mas[i]);
                }
            }

            sr.Close();
        }

        public static void ReadHalfMasFromFile(string fileName/*, out Vector first, out Vector second*/)
        {
            //StreamReader sr = new StreamReader (fileName);
            //string line = sr.ReadToEnd();
            //string[] mas = line.Split(' ');
            //first = new Vector(mas.Length/2);
            //second = new Vector(mas.Length - mas.Length / 2);
            //for (int i = 0; i < mas.Length/2; i++)
            //{
            //    first[i] = int.Parse(mas[i]);
            //    Console.Write(first[i]+ " ");
            //}
            //Console.WriteLine();
            //for (int i = mas.Length / 2; i < mas.Length; i++)
            //{
            //    second[i] = int.Parse(mas[i]);
            //    Console.Write(second[i] + " ");
            //}
            //sr.Close();
            //Console.WriteLine();

            //Console.WriteLine(line);
            using (StreamReader sr = new StreamReader(fileName))
            {
                string[] line = sr.ReadToEnd().Trim().Split();
            }
        }

        public void HeapSort()
        {
            int n = arr.Length;

            for(int i = n/2 - 1; i >= 0; i--)
            {
                Heapify(n, i);
            }

            for(int i = n - 1; i >= 0; i--)
            {
                Swap(ref arr[0], ref arr[i]);
                Heapify(i, 0);
            }
        }

        private void Heapify(int n, int i)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;
            
            if(left < n && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < n && arr[right] > arr[largest])
            {
                largest = right;
            }

            if(largest != i)
            {
                Swap(ref arr[i], ref arr[largest]);
                Heapify(n, largest);
            }
        }
    }
}
