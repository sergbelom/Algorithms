using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

/* РЕЗУЛЬТАТ:
 *  Для каждой точки в порядке появления во вводе выведите,
 *  скольким отрезкам она принадлежит
 */

namespace Points
{
    class Program
    {

        private static int[] countsSegmentsAndPoints = { 0, 0 };
       
        // считать отрезки -> 2мерный массив координат отрезков
        static int[,] CountSegmants( )
        {

            return null;
        }
        
        // считать все точки -> 1мерный массив координат точек
        static int[] CountPoints( )
        {

            return null;
        }

        // подсчет и вывод отрезков, в которые входит данная точка
        static void CountSegmantsForSelectedPoint(  )
        {

        }

        // алгоритм быстрой сортировки

        
        static void Main(string[] args)
        {
            // считываем с консоли два числа n - кол-во отрезков и m - кол-во точек на прямой и изменяем поле countsSegmentsAndPoints
            countsSegmentsAndPoints = Array.ConvertAll(Console.ReadLine().Split(' ') , int.Parse);
            


        }
    }
}
