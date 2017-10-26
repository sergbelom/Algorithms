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
            HuffmanCode algo = new HuffmanCode();
            // считывание 
            HuffmanCode.Run();

            // программа закончит свою работу после нажатия на любую клавишу
            Console.ReadKey();
        }
    }
}
