using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AntAlgorithmForSalesmenTask
{
    // class for generate random number
    public static class RandomProvider
    {
        static int seed = Environment.TickCount;

        static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        static float GetThreadRandom()
        {
            return randomWrapper.Value.Next(0, int.MaxValue);
        }
        // generate random number special
        public static float getSRand()
        {
            return (((float)GetThreadRandom()) / (float)(int.MaxValue));
        }
        // generate random based on X
        public static int getRand(int x)
        {
            return (int)(x * getSRand());
        }
    }
}
