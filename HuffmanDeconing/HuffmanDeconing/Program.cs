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
            //создаем экземпляр алгоритма
            AlgoHuffmanDecoding HuffmanDecode = new AlgoHuffmanDecoding();

            //получаем словарь (код-символ) из исходного датасета
            Dictionary<string, char> dictCharCodeHuffman = HuffmanDecode.DictionaryHaffmanCode;

            //выводим результат декодирования (результат принят системой Stepik)
            Console.WriteLine(HuffmanDecode.ParseHuffmanString());

            Console.ReadKey();
        }
    }
}
