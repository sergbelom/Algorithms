using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace HuffmanDeconing
{
    public class AlgoHuffmanDecoding
    {
        // ПОЛЯ
        // поле для строкового входного массива
        private string[] InputArrString;
        // поле для информации о количестве и длине закодированной строки
        private int[] InputData;
        // поле для хранения информации о символах и частотах, которые им соответсвуют
        private Dictionary<string, char> CharHaffmanCode;
        // поле для последней строки начального датасета - закодированной кодом Хаффмена
        private string InputCodeString; 

        // СВОЙСТВА
        public Dictionary<string, char> DictionaryHaffmanCode
        {
            get { return CharHaffmanCode; }
        }
        public int[] IntInputData
        {
            get { return InputData; }
        }
        public string InputCodeHuffmanString
        {
            get { return InputCodeString; }
        }
        public AlgoHuffmanDecoding()
        {
            InputArrString = ReadFromFileOrConsole.ReadLineFromFile();
            InputData = ReadFromFileOrConsole.InitNumber(InputArrString[0]);
            CharHaffmanCode = ReadFromFileOrConsole.CharHaffmanCode(InputArrString);
            InputCodeString = InputArrString[ReadFromFileOrConsole.InitNumber(InputArrString[0])[0] + 1];
        }
        
        // парсим закодированную строку
        // TODO: не возвращает последний d
        public string ParseHuffmanString()
        {
            string interSTR = "";
            string resultSTR = "";
            char keyChar = ' ';
            // построчно считываем 
            for (int i = 0; i < InputCodeString.Length; i++)
            {
                //Console.WriteLine(huffmanCode[i]);
                interSTR += InputCodeString[i];

                if (InputCodeString[i] == '0')
                {
                    CharHaffmanCode.TryGetValue(interSTR, out keyChar);
                    resultSTR += keyChar;
                    interSTR = "";
                    continue;
                }
            }

            return resultSTR;
        }
    }
}
