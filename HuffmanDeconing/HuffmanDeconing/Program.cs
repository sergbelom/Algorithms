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
            AlgoHuffmanDecoding HuffmanDecode = new AlgoHuffmanDecoding();

            int countTest = HuffmanDecode.IntInputData[0];

            Dictionary<string, char> dictCharCodeHuffman = HuffmanDecode.DictionaryHaffmanCode;

            string initCodeString = HuffmanDecode.InputCodeHuffmanString;

            Console.WriteLine(HuffmanDecode.ParseHuffmanString());

            Console.ReadKey();
        }
    }
}
