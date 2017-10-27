using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanDeconing
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] inputData = new string[AlgoHuffmanDecoding.ReadLineFromFile().Length];
            inputData = AlgoHuffmanDecoding.ReadLineFromFile();

            Console.WriteLine(inputData[3]);


            Console.ReadKey();
        }
    }
}
