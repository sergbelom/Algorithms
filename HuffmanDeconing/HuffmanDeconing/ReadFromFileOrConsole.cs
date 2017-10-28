using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanDeconing
{
    // TODO: добавить в выходной строковый массив элементом с индексом 0 данные первой строки консоли или файла
    // статический класс для считывания из файлов проекта или консоли
    public static class ReadFromFileOrConsole
    {
        // статический метод для построчного считывания текстового файла со входной информацией
        public static string[] ReadLineFromFile()
        {
            // открываем файл
            StreamReader inputData;
            try
            {
                inputData = new StreamReader("text.txt");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(string.Format("File not found!"));
            }

            // считываем первую строку из текстового файла
            string firstLineDataStr = inputData.ReadLine();
            // получаем число символов, на основе которого будем формировать выходной массив
            int countChar = int.Parse(firstLineDataStr.Split(' ')[0]) + 2;

            //выходной массив строк
            string[] inputDataStr = new string[countChar];
            inputDataStr[0] = firstLineDataStr;

            for (int i = 1; i < countChar; i++)
            {
                inputDataStr[i] = inputData.ReadLine();
            }
            inputData.Close();

            return inputDataStr;
        }

        // статический метод для считывания первой строки данных, содержащей число символов и длину закодированной строки
        public static int[] InitNumber( string firstInputString )
        {
            int[] initData = new int[2];
            // считываем первую строку
            string[] firstInputData = firstInputString.Split(' ');

            initData[0] = int.Parse(firstInputData[0]); // число символов
            initData[1] = int.Parse(firstInputData[1]); // длина закодированного сообщения

            return initData;
        }

        // статический метод для формирования на оснвое входных данных словаря символов с соответсвующим кодом
        public static Dictionary<string, char> CharHaffmanCode( string[] arrInputString )
        {
            Dictionary<string, char> dictCharCode = new Dictionary<string, char>();
            
            for ( int i = 0; i < arrInputString.Length-2; i++ )
            {
                dictCharCode.Add(arrInputString[i+1].Substring(3) , arrInputString[i+1][0] );
            }

            return dictCharCode;
        }

        // статический метод для построчного считывания входных данных с консоли
        public static string[] ReadLineFromConsole()
        {
            string firstInputData = Console.ReadLine();

            int countChar = int.Parse(firstInputData.Split(' ')[0]) + 2; // число символов
            int lengthStr = int.Parse(firstInputData.Split(' ')[1]); // длина закодированного сообщения

            string[] inputDataFromConsole = new string[countChar];
            inputDataFromConsole[0] = firstInputData;

            for (int i = 1; i < countChar; i++)
            {
                inputDataFromConsole[i] = Console.ReadLine();
            }
            
            return inputDataFromConsole;
        }

    }

}
