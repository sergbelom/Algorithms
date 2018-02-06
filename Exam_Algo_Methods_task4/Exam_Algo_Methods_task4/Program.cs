using System;
using System.Collections.Generic;
using System.Linq;

public class Exam_Algo_Methods_task4
{
    public static string solve_sum(List<ulong> num_array, ulong value)
    {
        List<ulong> dividers = num_array.Where(i => i < value).ToList();
        dividers.Sort((a, b) => -1 * a.CompareTo(b));
        List<ulong> res = new List<ulong>();
        int n = 0;
        while (value != 0)
        {
            for (int i = 0; i < (int)(value / dividers[n]); i++)
            {
                res.Add(dividers[n]);
            };
            value %= dividers[n];
            n++;
        }
        return res.Count + " " + string.Join(" ", res);
    }

    public static void Main()
    {
        List<ulong> s = Console.ReadLine().Split(' ').Select(x => Convert.ToUInt64(x)).ToList();
        if (s[0] == 1 || s[1] == 1)
        {
            Console.WriteLine(1 + " " + s[1]);
            return;
        }
        ulong n = s[0];
        ulong w = s[1];
        s.RemoveAt(0);
        s.RemoveAt(0);

        Console.WriteLine(solve_sum(s, w));
        Console.ReadKey();
    }
}
