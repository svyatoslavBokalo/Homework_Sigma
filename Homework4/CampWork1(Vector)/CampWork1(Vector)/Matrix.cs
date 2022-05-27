using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampWork1_Vector_
{
    public enum Move
    {
        Right,
        Down
    }
    public class Matrix
    {

        static public void Triangular(int n)
        {
            //int count = 0;
            //for(int i = n; i > 0; i--)
            //{
            //    count += i;
            //}
            int[][] triangular = new int[n][];

            for (int i = 0; i < n; i++)
            {
                triangular[i] = new int[n - i];
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    triangular[i][j] = i + 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(triangular[i][j] + " ");
                }
                Console.WriteLine();
            }
        }

        static public void TringularPascal(int n)
        {

            int[][] matrix = new int[n][];
            int middle = n / 2;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[i+1];
            }
            
            for (int i = 0; i < n; i++)
            {
                matrix[i][0] = 1;
                matrix[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                    //matrix[i][j] = 0;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i+1; j++)
                {
                    Console.Write(String.Format("{0,-3}", matrix[i][j]));
                    //Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();

            }
        }

        static public void VerticalSnake(int n, int m)
        {
            int[,] matrix = new int[n, m];

            int count = 1;
            for(int j = 0; j < m; j++)
            {
                //for (int i = n - 1; i >= 0; i--)
                //{
                //    matrix[i, j] = count;
                //    count++;
                //}
                if (j % 2 != 0)
                {
                    for (int i = n - 1; i >= 0; i--)
                    {
                        matrix[i, j] = count;
                        count++;
                    }
                }
                else
                {
                    for (int i = 0; i < n; i++)
                    {
                        matrix[i, j] = count;
                        count++;
                    }

                }
            }
            
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        static public void DiaginalSnake(int n, Move move)
        {
            int[,] matrix = new int[n, n];

            int k = 1;
            //int count = 0;
            //if (n % 2 == 0)
            //{
            //    count = n / 2;
            //    Console.WriteLine("n/2== 0: count = " + count);
            //}
            //else
            //{
            //    count = n / 2 + 1;
            //    Console.WriteLine("n/2 != 0: count = " + count);
            //}
            if (move == Move.Right)
            {
                for (int v = 0; v < n; v++)
                {
                    if (v % 2 == 0)
                    {
                        for (int j = 0; j < v + 1; j++)
                        {
                            matrix[v - j, j] = k;
                            k++;
                        }

                    }
                    else
                    {
                        for (int j = v; j >= 0; j--)
                        {
                            matrix[v - j, j] = k;
                            k++;
                        }
                    }
                }

                if (n % 2 != 0)
                {
                    for (int v = 1; v < n; v++)
                    {
                        if (v % 2 == 0)
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[n - j - 1, v + j] = k;
                                k++;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[v + j, n - j - 1] = k;
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    for (int v = 1; v < n; v++)
                    {
                        if (v % 2 == 0)
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[v + j, n - j - 1] = k;
                                k++;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[n - j - 1, v + j] = k;
                                k++;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int v = 0; v < n; v++)
                {
                    if (v % 2 == 0)
                    {
                        for (int j = v; j >= 0; j--)
                        {
                            matrix[v - j, j] = k;
                            k++;
                        }

                    }
                    else
                    {
                        for (int j = 0; j < v + 1; j++)
                        {
                            matrix[v - j, j] = k;
                            k++;
                        }
                    }
                }

                if (n % 2 != 0)
                {
                    for (int v = 1; v < n; v++)
                    {
                        if (v % 2 == 0)
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[v + j, n - j - 1] = k;
                                k++;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[n - j - 1, v + j] = k;
                                k++;
                            }
                        }
                    }
                }
                else
                {
                    for (int v = 1; v < n; v++)
                    {
                        if (v % 2 == 0)
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[n - j - 1, v + j] = k;
                                k++;
                            }

                        }
                        else
                        {
                            for (int j = 0; j < n - v; j++)
                            {
                                matrix[v + j, n - j - 1] = k;
                                k++;
                            }
                        }
                    }
                }
            }
            //for(int v = n-1; v >= 0; v--)
            //{
            //    if (v % 2 == 0)
            //    {
            //        for (int j = 0; j <v+1; j++)
            //        {
            //            matrix[n-j,v+j] = k;
            //            k++;
            //        }

            //    }
            //    //else
            //    //{
            //    //    for (int j = v; j >= 0; j--)
            //    //    {
            //    //        matrix[] = k;
            //    //        k++;
            //    //    }
            //    //}
            //}
            //if (n % 2 != 0)
            //{
            //    for (int v = 1; v < n; v++)
            //    {
            //        if (v % 2 == 0)
            //        {
            //            for (int j = 0; j < n - v; j++)
            //            {
            //                matrix[n - j - 1, v + j] = k;
            //                k++;
            //            }

            //        }
            //        else
            //        {
            //            for (int j = 0; j < n - v; j++)
            //            {
            //                matrix[v + j, n - j - 1] = k;
            //                k++;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    for (int v = 1; v < n; v++)
            //    {
            //        if (v % 2 == 0)
            //        {
            //            for (int j = 0; j < n - v; j++)
            //            {
            //                matrix[v + j, n - j - 1] = k;
            //                k++;
            //            }

            //        }
            //        else
            //        {
            //            for (int j = 0; j < n - v; j++)
            //            {
            //                matrix[n - j - 1, v + j] = k;
            //                k++;
            //            }
            //        }
            //    }
            //}

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0,-3}",matrix[i,j]));
                }
                Console.WriteLine();
            }
        }

        static public void SpiralSnake(int n, int m)
        {
            int[,] matrix = new int[n, m];

            int k = 1;
            int count = 0;
            if(n%2 == 0)
            {
                count = n / 2;
            }
            else
            {
                count = n - n / 2;
            }

            for(int v = 0; v < count; v++)
            {
                for(int  i = v; i < n - v; i++)
                {
                    matrix[i, v] = k;
                    k++;
                }

                for(int j = v+1; j < m - v; j++)
                {
                    matrix[n - v - 1, j] = k;
                    k++;
                }

                for(int i = n-v-2; i >= v; i--)
                {
                    matrix[i,m - v - 1] = k;
                    k++;
                }

                for (int j = m - v - 2; j >= v+1; j--)
                {
                    matrix[v,j] = k;
                    k++;
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(String.Format("{0,-3}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }

        static public void RombInSquare(int n)
        {
            int[,] matrix = new int[n, n];

            int middle = n / 2;

            // 1
            for (int i = 0; i < middle; i++)
            {
                for (int j = 0; j < middle - i; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            // 2
            for (int i = 0; i < middle; i++)
            {
                for (int j = middle + i + 1; j < n; j++)
                {
                    matrix[i, j] = 2;
                }
            }

            // 3
            for (int i = middle + 1; i < n; i++)
            {
                for (int j = n - 1; j >= n - (i - middle); j--)
                {
                    matrix[i, j] = 3;
                }
            }

            // 4
            for (int i = middle + 1; i < n; i++)
            {
                for (int j = 0; j < i - middle; j++)
                {
                    matrix[i, j] = 4;
                }
            }

            // 5
            for (int i = 0; i < middle; i++)
            {
                for (int j = middle - i; j <= middle + i; j++)
                {
                    matrix[i, j] = 0;
                }
            }
            for (int i = middle; i < n; i++)
            {
                for (int j = i - middle; j < n + middle - i; j++)
                {
                    matrix[i, j] = 0;
                }
            }



            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0,-3}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }

        static public void SortDiagonalMatrix(int n)
        {
            int[,] array = new int[n, n];
            int number = 0;
            for (int line = 0; line < n; line++)
            {
                if (line % 2 == 0)
                {
                    int i1 = line;
                    int j1 = 0;
                    for (int i = 0; i < line + 1; i++)
                    {
                        array[i1, j1] = ++number;
                        i1--;
                        j1++;
                    }
                }
                else
                {
                    int i1 = 0;
                    int j1 = line;
                    for (int i = 0; i < line + 1; i++)
                    {
                        array[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(String.Format("{0,-3}", array[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
