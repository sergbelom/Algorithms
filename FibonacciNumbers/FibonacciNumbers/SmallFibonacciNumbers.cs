using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciNumbers
{
    static class SmallFibonacciNumbers
    {

        public static void GenerateSmallFibonacciNumbers()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] finNum = new int[n + 1];
            finNum[0] = 0;
            finNum[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                finNum[i] = finNum[i - 1] + finNum[i - 2];
            }

            Console.WriteLine(finNum[n]);
        }
    }
}
