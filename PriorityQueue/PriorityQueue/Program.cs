using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueueGeneric<int> inputQueue = new PriorityQueueGeneric<int>();
            List<int> result = new List<int>();

            // считываем количество входных строк
            int countLine;
            countLine = int.Parse(Console.ReadLine());

            // определяем переменные для хранения промежуточных элементов
            string[] lineFromConsole;
            int interValue = 0;
            int resultInterValue = 0;

            for (int i = 0; i < countLine; i++)
            {
                lineFromConsole = Console.ReadLine().Split(' ');

                if (lineFromConsole[0] != "ExtractMax")
                {
                    interValue = int.Parse(lineFromConsole[1]);
                    inputQueue.Add(interValue, interValue);
                }
                else
                {
                    inputQueue.Poll(out resultInterValue, out resultInterValue);
                    result.Add(resultInterValue);
                }
            }

            foreach (int elem in result)
            {
                Console.WriteLine(elem);
            }
        }
    }
}
