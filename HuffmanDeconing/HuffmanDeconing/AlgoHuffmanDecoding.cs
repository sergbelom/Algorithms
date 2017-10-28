using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            InputArrString = ReadFromFileOrConsole.ReadLineFromFile(); //можно изменить на считывание с консоли
            InputData = ReadFromFileOrConsole.InitNumber(InputArrString[0]);
            CharHaffmanCode = ReadFromFileOrConsole.CharHaffmanCode(InputArrString);
            InputCodeString = InputArrString[ReadFromFileOrConsole.InitNumber(InputArrString[0])[0] + 1];
        }
        
        // парсим закодированную строку
        // TODO: не возвращает последний d (косяк с выводом символов, не имеющих 0, например, 111)
        public string ParseHuffmanString()
        {
            string interSTR = "";
            string resultSTR = "";
            char keyChar = ' ';
            // посимвольно считываем 
            for (int i = 0; i < InputCodeString.Length; i++)
            {
                // считываем один следующий символ из закодированной строки
                interSTR += InputCodeString[i];
                // попытаемся найти interSTR в словаре "код-символ"
                CharHaffmanCode.TryGetValue(interSTR, out keyChar);
                if (CharHaffmanCode.ContainsKey(interSTR))
                {
                    //Console.WriteLine(interSTR + "   " + keyChar);
                    resultSTR += keyChar;
                    keyChar = ' ';
                    interSTR = "";
                    continue;
                }
            }

            return resultSTR;
        }
    }
}
