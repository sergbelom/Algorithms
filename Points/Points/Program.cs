using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/* РЕЗУЛЬТАТ:
Для каждой точки в порядке появления во вводе выведите,
скольким отрезкам она принадлежит
test1:
input
2 3
0 5
7 10
1 6 11
output
1 0 0

test2:
6 5
0 5
7 10
0 8
10 12
1 2
2 8
11 6 1 2 8
output
1 2 3 4 3

*/

namespace Points
{
    class Program
    {
        // поле для хранения количества отрезков и точек
        private static int[] countsSegmentsAndPoints = new int[2];

        // считать отрезки -> 2мерный массив координат отрезков
        static int[,] CountSegments()
        {
            int[,] segmentsX_L_R = new int[countsSegmentsAndPoints[0],2];
            int[] inter = new int[2];
            string[] str = new string[2];
            for ( int i =0 ; i < countsSegmentsAndPoints[0] ; i++ )
            {
                str = Console.ReadLine().Split(' ');
                segmentsX_L_R[i,0] = Convert.ToInt32(str[0]); // левая координата
                segmentsX_L_R[i,1] = Convert.ToInt32(str[1]); // правая координата
            }
            return segmentsX_L_R;
        }

        // считать все точки -> 1мерный массив координат точек
        // проверить кажду точку на принадлежность отрезкам
        static void CountPoints( int[,] sortSegmentsRead )
        {

            int j = 0, result = 0;
            int[] input = new int[countsSegmentsAndPoints[1]];
            int[] output = new int[countsSegmentsAndPoints[1]];
            input = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            StringBuilder res = new StringBuilder();
            // поиск подъодящих отрезков методом бинарного поиска
                
                for (int i = 0; i < countsSegmentsAndPoints[1]; i++)
                {
                    while(input[i] >= sortSegmentsRead[j, 0])
                    {
                        if (input[i] <= sortSegmentsRead[j, 1])
                        {
                            result++;
                        }
                        j++;
                        if (j == countsSegmentsAndPoints[0])
                        {
                            break;
                        }
                    }
                    res.Append(result);
                    res.Append(" "); 
                    j = 0; result = 0;
                }
            Console.Write(res);
            }

        // метод для бинарного поиска
        public static int binarySearch(int[,] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid,0])
            {
                return binarySearch(x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid,0])
            {
                return binarySearch(x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        // подсчет и вывод отрезков, в которые входит данная точка
        static void CountSegmentsForSelectedPoint( int[] pointsRead , int[,] sortSegmentsRead )
        {
            int j = 0, result = 0;
            
            for (int i = 0; i < pointsRead.Length; i++)
            {
                while (pointsRead[i] >= sortSegmentsRead[j, 0])
                {
                    if (pointsRead[i] <= sortSegmentsRead[j, 1])
                    {
                        result++;
                    }
                    j++;
                    if (j == countsSegmentsAndPoints[0])
                    {
                        break;
                    }
                }
                j = 0; result = 0;
            }
            Console.Write(result + " ");
        }

        // быстрая сортировка
        static int[,] QuickSort(int[,] inputArrForSort, int l, int r)
        {
            while (l < r)
            {
                int m; m = Partition(inputArrForSort, l, r);
                QuickSort(inputArrForSort, l, m - 1);
                l = m + 1;
            }

            return inputArrForSort;
        }

        static int Partition(int[,] inputArr, int l, int r)
        {
            int x = inputArr[l,0];
            int j = l;
            int interX_L, interX_R;

            for ( int i=l+1; i<=r; i++ )
            {
                if ( inputArr[i,0] <= x)
                {
                    j++;

                    // TODO: реализовать обмен значениями без использования третьей переменной
                    interX_L = inputArr[j, 0];
                    inputArr[j, 0] = inputArr[i, 0];
                    inputArr[i, 0] = interX_L;

                    interX_R = inputArr[j, 1];
                    inputArr[j, 1] = inputArr[i, 1];
                    inputArr[i, 1] = interX_R;

                }
            }

            // TODO: реализовать обмен значениями без использования третьей переменной
            interX_L = inputArr[l,0];
            inputArr[l, 0] = inputArr[j, 0];
            inputArr[j, 0] = interX_L;

            interX_R = inputArr[l,1]; 
            inputArr[l,1] = inputArr[j,1];
            inputArr[j,1] = interX_R;

            return j;
        }
        
        static void Main(string[] args)
        {
            // СЧИТЫВАНИЕ С КОНСОЛИ
            // считываем с консоли два числа n - кол-во отрезков и m - кол-во точек на прямой и изменяем поле countsSegmentsAndPoints
            //countsSegmentsAndPoints = Array.ConvertAll(Console.ReadLine().Split(' ') , int.Parse);
            string[] str = Console.ReadLine().Split(' ');
            countsSegmentsAndPoints[0] = Convert.ToInt32(str[0]);
            countsSegmentsAndPoints[1] = Convert.ToInt32(str[1]);

            // считываем массив из 2мерного массива координат отрезков
            int[,] segmentsReadX_L_R = CountSegments();
            //сортируем массив координат отрезков по левой координате
            int[,] sortSegmentsReadX_L_R = QuickSort(segmentsReadX_L_R, 0, countsSegmentsAndPoints[0] - 1);


            // считываем массив координат точек и сразу ищем подходящие отрезки
            //int[] pointsRead = 
            CountPoints(sortSegmentsReadX_L_R);

            //CountSegmentsForSelectedPoint(pointsRead, sortSegmentsReadX_L_R);

            // ВЫВОД ИНФОРМАЦИИ О КОРРЕКТНОЙ РАБОТЕ ПРОГИ
            // вывод контрольной информации после считывания
            //Console.WriteLine(countsSegmentsAndPoints[0] * countsSegmentsAndPoints[1]);
            //Console.WriteLine(segmentsRead[1][1]);
            //Console.WriteLine(pointsRead[1]);

            // тест сортировки на примере массива координат точек
            //int[] pointsReadAfterSort = QuickSort(pointsRead, 0 , countsSegmentsAndPoints[1]-1);
            //Console.WriteLine(pointsReadAfterSort[0] + " " + pointsReadAfterSort[1] + " " + pointsReadAfterSort[2] + " last: " + pointsReadAfterSort[countsSegmentsAndPoints[1] - 1]);
            
            //Console.ReadKey();
        }
    }
}
