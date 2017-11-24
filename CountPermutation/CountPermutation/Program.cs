using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CountPermutation
{
    class Program
    {
        // поле хранит количество инверсий
        static long countPermutation = 0;

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

        // сортировка слиянием
        static int[] Merge_Sort(int[] massive)
        {
            if (massive.Length == 1)
                return massive;

            int mid_point = massive.Length / 2;
            return Merge(Merge_Sort(massive.Take(mid_point).ToArray()), Merge_Sort(massive.Skip(mid_point).ToArray()));
        }
        static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int[] merged = new int[mass1.Length + mass2.Length];

            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                {
                    if (mass1[a] > mass2[b])
                    {
                        merged[i] = mass2[b++];
                        countPermutation += mass1.Length-a;
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }

                }
                else
                {
                    if (b < mass2.Length)
                    {
                        merged[i] = mass2[b++];
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }
                }
            }
            return merged;
        }

        // сортировка вставками
        static int[] Paste_Sort( int[] workArr )
        {                     
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
                    countPermutation++;
                }
            }
            return workArr;            
        }

        static void Main(string[] args)
        {
            //в теле методов просиходит редактирование поля класса countPermutation, для подсчета количества инверсий

            Merge_Sort(readArray());

            //Paste_Sort(readArray());

            Console.WriteLine(countPermutation);
            Console.ReadKey();
        }
    }
}
