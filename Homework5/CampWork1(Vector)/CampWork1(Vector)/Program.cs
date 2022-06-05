// See https://aka.ms/new-console-template for more information
using CampWork1_Vector_;

//Pair pair1 = new Pair(2, 5);
//Pair pair2 = new Pair(2, 5);
//Pair pair3 = pair1;
////Pair pair1 = null;
////Pair pair2 = null;

//Console.WriteLine(pair1.Equals(pair3));
//Console.WriteLine(ReferenceEquals(pair1, pair3));

//Console.WriteLine(pair1 == pair2);
//Console.WriteLine(pair1 == pair3);

//Console.WriteLine(pair1.GetHashCode());
//Console.WriteLine(pair2.GetHashCode());
//Console.WriteLine(pair3.GetHashCode());

//Console.WriteLine(pair1.GetType());


//Matrix.DiaginalSnake(6, Move.Right);
//Console.WriteLine();
//Matrix.DiaginalSnake(6, Move.Down);
//Console.WriteLine();
//Matrix.DiaginalSnake(7, Move.Right);
//Console.WriteLine();
//Matrix.DiaginalSnake(7, Move.Down);

//Matrix.SortDiagonalMatrix(6);


//Console.WriteLine("Hello, World!");
///////////////////////////////////////////////////////////////////////////
//Console.WriteLine();
//Vector arr = new Vector(5);
//arr.HardInitialization();
//Console.WriteLine(arr);

//Console.WriteLine(arr.IsPalindromNew());
//arr.MyReverse();
//Console.WriteLine(arr);

//string line = "   dsgsgds sgsgs grgrg ";
//Console.WriteLine(line);
//line = line.Trim();
//Console.WriteLine(line.Trim());
//Console.WriteLine(line);

///////////////////////////////////////////////////////////////////////////
//arr.QuickSort();
//Console.WriteLine();
//Console.WriteLine(arr);

//arr.HeapSort();
//Console.WriteLine();
//Console.WriteLine(arr);

//Vector first, second;
//Vector.ReadHalfMasFromFile("data.txt"/*,out first,out second*/);

//Vector arr1 = new Vector(8);
//arr1[0] = 2;
//arr1[1] = 3;
//arr1[2] = 3;
//arr1[3] = 4;
//arr1[4] = 2;
//arr1[5] = 51;
//arr1[6] = 23;
//arr1[7] = 23;


//try
//{
//    Console.WriteLine(arr);
//    int index;
//    int maxLenght;
//    arr.TheLongestSubsequence(out index, out maxLenght);

//    Console.WriteLine($"index = {index} \t max lenght = {maxLenght}");

//    Console.WriteLine();

//    Console.WriteLine(arr1.IsPalindrom());
//    Console.WriteLine();

//    arr.MyReverse();
//    Console.WriteLine(arr);
//    arr1.MyReverse();
//    Console.WriteLine(arr1);
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}


//Pair[] pairs = arr.CalculateFreq();

//for (int i = 0; i < pairs.Length; i++)
//{
//    Console.Write(pairs[i] + "\n");
//}
//Console.WriteLine();

//Console.WriteLine(pairs);
//arr.RandomInitialization();
//Console.WriteLine(arr);



StreamReader sr = new StreamReader("data.txt");
char c = (char)sr.Read();
Console.WriteLine(c);
sr.Close();

StreamReader sr1 = new StreamReader("data1.txt");
StreamReader sr2 = new StreamReader("data2.txt");
StreamWriter sw = new StreamWriter("data3.txt");

AttemptMergeFromFile.Merge(sr1, sr2, sw);

sr1.Close();
sr2.Close();
sw.Close();