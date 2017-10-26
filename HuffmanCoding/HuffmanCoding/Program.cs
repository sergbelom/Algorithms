using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            // считывание 
            HuffmanCode.ReadFile();

            // PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            // priorityQueue.Enqueue

            // программа закончит свою работу после нажатия на любую клавишу
            Console.ReadKey();
        }
    }
}
