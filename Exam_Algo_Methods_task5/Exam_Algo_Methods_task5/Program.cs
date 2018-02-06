using System;
using System.Linq;

namespace Exam_Algo_Methods_task5
{
    class Program
    {


        static void Main(string[] args)
        {

            int inputLenArr = Convert.ToInt32(Console.ReadLine());
            int[] arrForAnaliz = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Array.Sort(arrForAnaliz);

            Console.WriteLine(Convert.ToInt64(arrForAnaliz[inputLenArr - 1]) * Convert.ToInt64(arrForAnaliz[inputLenArr - 2]));
            Console.ReadKey();

        }
    }
}
