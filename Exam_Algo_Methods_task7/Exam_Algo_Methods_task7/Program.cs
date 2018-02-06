using System;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Exam_Algo_Methods_task7
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1_test = Console.ReadLine();
            string str2_pattern = Console.ReadLine();

                int i = 0;
                int x = -1;
                int count = -1; 
                while (i != -1)
                {
                    i = str1_test.IndexOf(str2_pattern, x + 1); 
                    x = i; 
                    count++; 
                }

                Console.WriteLine(count);

            Console.ReadKey();
        }
    }
}
