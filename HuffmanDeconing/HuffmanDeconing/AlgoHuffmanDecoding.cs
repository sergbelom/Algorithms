using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanDeconing
{
    class AlgoHuffmanDecoding
    {
        // статический метод для построчного считывания текстового файла со входной информацией
        public static string[] ReadLineFromFile()
        {
            StreamReader objReader;
            
            try
            {
                objReader = new StreamReader("text.txt");
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(string.Format("File not found!"));
            }

            // считываем первую строку
            string[] firstInputData = objReader.ReadLine().Split(' ');
            
            int countChar = int.Parse(firstInputData[0]); // число символов
            int lengthStr = int.Parse(firstInputData[1]); // длина закодированного сообщения

            string[] inputStr = new string[countChar+1];

            for ( int i = 0; i <= countChar ; i++ )
            {
                inputStr[i] = objReader.ReadLine();
            }
            
            objReader.Close();

            Console.WriteLine(inputStr[countChar]);

            return inputStr;
        }

        // статический метод для построчного считывания входных данных с комндной строки
        public static string[] ReadLineFromConsole()
        {
            string[] firstInputData = Console.ReadLine().Split(' ');

            int countChar = int.Parse(firstInputData[0]); // число символов
            int lengthStr = int.Parse(firstInputData[1]); // длина закодированного сообщения

            string[] inputDataFromConsole = new string[countChar+1];

            for (int i = 0; i <= countChar; i++)
            {
                inputDataFromConsole[i] = Console.ReadLine();
            }

            Console.WriteLine(inputDataFromConsole[countChar]);


            return inputDataFromConsole;
        }

    }
}
