using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

/*
Первая строка содержит число 1≤n≤10^4, вторая — n натуральных чисел, не превышающих 10.
Выведите упорядоченную по неубыванию последовательность этих чисел.
Sample Input:
6
2 10 3 9 2 9
Sample Output:
2 2 3 9 9 10
*/

namespace CountingSort
{
    class Program
    {

        // метод для считывания данных с консоли
        static int[] ReadArray()
        {
            int inputLenArr = Convert.ToInt32(Console.ReadLine());

            int[] inputArr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse );

            return inputArr;
        }

        // метод для сортировки подсчетом 
        static int[] CountingSort( int[] inputArr ) {

            int[] interArr = new int[11];
            int[] outputArr = new int[inputArr.Length];

            for (int j = 0; j < inputArr.Length; j++)
            {
                interArr[inputArr[j]] = interArr[inputArr[j]] + 1;
            }

            for ( int i = 1; i < interArr.Length; i++ )
            {
                interArr[i] = interArr[i] + interArr[i - 1];
            }

            int k;
            for (int j = 0 ; j < inputArr.Length ; j++ )
            {
                k = interArr[inputArr[j]];
                outputArr[k-1] = inputArr[j];
                interArr[inputArr[j]] = interArr[inputArr[j]] - 1;             
            }

            return outputArr;
        }

        static void Main(string[] args)
        {
            foreach (int x in CountingSort(ReadArray()))
            {
                Console.Write(x);
                Console.Write(' ');
            }

            Console.ReadKey();
        }
    }
}
