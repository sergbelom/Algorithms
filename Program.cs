using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knapsack
{
    public class Program
    {

        private static int volumeKnapsack;
        private static int countThing;
        private static int[] weightItem;

        private static void ReadData()
        {
            var str = Console.ReadLine().Split(' ');
            volumeKnapsack = Convert.ToInt32(str[0]);
            countThing = Convert.ToInt32(str[1]);
            string[] str2 = Console.ReadLine().Split(' ');
            weightItem = new int[countThing];

            for (int i = 0; i < countThing; i++)
            {
                weightItem[i] = Convert.ToInt32(str2[i]);
            }
        }
       
        public static int KnapsackWithoutReps()
        {
            int c = 0;
            int[,] D = new int[volumeKnapsack + 1, weightItem.Length + 1];
            for (int w = 0; w <= volumeKnapsack; w++)
            {
                D[w,0] = 0;
            }

            for (int i = 0; i <= weightItem.Length; i++)
            {
                D[0,i] = 0;
            }

            for (int i = 1; i <= weightItem.Length; i++)
            {
                for (int w = 1; w <= volumeKnapsack; w++)
                {
                    D[w,i] = D[w,i - 1];
                    if (weightItem[c] <= w)
                    {
                        D[w,i] = Math.Max(D[w,i], D[w - weightItem[c],i - 1] + weightItem[c]);
                    }
                }
                c++;
            }
            return D[volumeKnapsack, weightItem.Length];
        }

        public static void Main(string[] args)
        {
            ReadData();
            
            Console.WriteLine(KnapsackWithoutReps());
        }
    }
}
