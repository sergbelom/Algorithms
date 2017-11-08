using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BinarySearch
{
    class Program
    {
        static int[] readArray()
        {
            // считываем входной массив
            // скорее всего C# позволяет считать массив int[] напрямую
            string[] inputLenArr = Console.ReadLine().Split(' ');
            int lenArr = Convert.ToInt32(inputLenArr[0]);

            int[] inputArr = new int[lenArr];

            for ( int i = 0; i < lenArr; i++ )
            {
                inputArr[i] = Convert.ToInt32(inputLenArr[i + 1]);
            }
            return inputArr;

        }

        // метод для бинарного поиска
        static int binarySearch(ref int[] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return binarySearch(ref x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return binarySearch(ref x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        static void Main(string[] args)
        {
            // входной упорядоченный массив
            int[] inputArr = readArray();
            int lenArr = inputArr.Length;

            // входной массив чисел для проверки
            int[] checkArr = readArray();
            int lenCheckArr = checkArr.Length;

            // строка для вывода результата
            StringBuilder outArr = new StringBuilder();
            int result;

            foreach ( int elem in checkArr)
            {
                result = binarySearch(ref inputArr, elem, 0, lenArr-1);
                if (result == -1) { outArr.Append("-1 "); }
                else { outArr.Append((result+1).ToString() + ' '); }
            }

            Console.WriteLine(outArr);

            Console.ReadKey();

        }
    }
}
