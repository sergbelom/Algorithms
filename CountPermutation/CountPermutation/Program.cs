using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CountPermutation
{
    class Program
    {
        // считываем входной массив
        static int[] readArray()
        {
            int inputLenArr = Convert.ToInt32(Console.ReadLine());
            string[] inputArrStr = Console.ReadLine().Split(' ');

            int[] inputArr = new int[inputLenArr];

            for (int i = 0; i < inputLenArr; i++)
            {
                inputArr[i] = Convert.ToInt32(inputArrStr[i]);
            }
            return inputArr;
        }
        
        // функция сравнения
        static int compareElement()
        {
            return 0;
        }
        
        static void Main(string[] args)
        {
            // работаем со считанным массивом
            int[] workArr = readArray();
            int result = 0;

            /*
            для i от 2 до n:
            j ← i
            пока j > 1 и A[j] < A[j − 1]:
            обменять A[j] и A[j − 1]
            j ← j − 1
            */
            int resLen = workArr.Length;
            int j;
            int inter;
            
            for ( int i = 1; i < workArr.Length; i++ )
            {
                j = i;
                while (j > 0 && workArr[j] < workArr[j-1])
                {
                    inter = workArr[j];
                    workArr[j] = workArr[j - 1];
                    workArr[j - 1] = inter;
                    j = j - 1;
                    result++;
                }
            }

            Console.WriteLine(result);
            Console.ReadKey();

        }
    }
}
