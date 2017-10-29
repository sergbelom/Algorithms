using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PriorityQueue
{
    class DataFromConsole
    {
        public static Dictionary<string, int> ReadDataFromConsole()
        {
            Dictionary<string, int> InputData = new Dictionary<string, int>();

            int countLine;
            countLine = int.Parse(Console.ReadLine());

            string[] lineFromConsole;
            int interValue = 0;
            for (int i = 0; i < countLine; i++)
            {
                lineFromConsole = Console.ReadLine().Split(' ');

                if (lineFromConsole[0] != "ExtractMax")
                {
                    interValue = int.Parse(lineFromConsole[1]);
                }

                InputData.Add(lineFromConsole[0], interValue);
            }

            return InputData;
        }
    }
}
