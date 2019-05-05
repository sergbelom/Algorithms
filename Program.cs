//TODO: Прототип на C# на основе прошлого решения. Переделать на cpp11 под линукс.

using System;
using System.Text;

namespace BinarySearch
{
    class Program
    {
        static int[] inputArr;
        static int[] checkArr;
        static StringBuilder outArr;

        /// <summary>
        /// Read array from Console.
        /// </summary>
        /// <returns></returns>
        static int[] ReadArray()
        {
            // считываем входной массив
            // скорее всего C# позволяет считать массив int[] напрямую
            string[] inputLenArr = Console.ReadLine().Split(' ');
            int lenArr = Convert.ToInt32(inputLenArr[0]);

            int[] inputArr = new int[lenArr];

            for (int i = 0; i < lenArr; i++)
            {
                inputArr[i] = Convert.ToInt32(inputLenArr[i + 1]);
            }
            return inputArr;

        }

        /// <summary>
        /// Binary Search.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="searchValue"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        static int BinarySearch(ref int[] x, int searchValue, int left, int right)
        {
            if (right < left)
            {
                return -1;
            }
            int mid = (left + right) >> 1;
            if (searchValue > x[mid])
            {
                return BinarySearch(ref x, searchValue, mid + 1, right);
            }
            else if (searchValue < x[mid])
            {
                return BinarySearch(ref x, searchValue, left, mid - 1);
            }
            else
            {
                return mid;
            }
        }

        static void ItemSearch()
        {
            int lenArr = inputArr.Length;

            int result;

            foreach (int elem in checkArr)
            {

                result = BinarySearch(ref inputArr, elem, 0, lenArr - 1);

                if (result == -1)
                {
                    outArr.Append("-1 ");
                }
                else
                {
                    outArr.Append((result + 1).ToString() + ' ');
                }
            }
        }

        static void Main(string[] args)
        {           
            inputArr = ReadArray();
            checkArr = ReadArray();
            outArr = new StringBuilder();
            ItemSearch();


            Console.WriteLine(outArr);

            Console.ReadKey();

        }
    }
}