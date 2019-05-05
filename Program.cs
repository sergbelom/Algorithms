using System;

namespace LongestIncreasingSubsequence
{
    public static class Program
    {
        private static int[] dataInt;

        private static void ReadData()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] data = Console.ReadLine().Split();
            dataInt = new int[n];
            for (int i = 0; i < n; i++)
            {
                dataInt[i] = Convert.ToInt32(data[i]);
            }
        }

        private static int calcSequenceLength()
        {
            int[] sequences = new int[dataInt.Length];

            for (int i = 0; i < dataInt.Length; i++)
            {
                sequences[i] = 1;
                for (int j = 0; j <= i - 1; j++)
                {
                    if ((dataInt[i] % dataInt[j] == 0)
                        && (sequences[j] + 1 > sequences[i]))
                    {
                        sequences[i] = sequences[j] + 1;
                    }
                }
            }

            int maxSequence = 0;
            for (int i = 0; i < dataInt.Length; i++)
            {
                if (sequences[i] > maxSequence)
                {
                    maxSequence = sequences[i];
                }
            }

            return maxSequence;
        }

        public static void Main(string[] args)
        {
            ReadData();

            Console.WriteLine(calcSequenceLength());
        }
    }
}