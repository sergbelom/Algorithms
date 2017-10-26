using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class HuffmanCode
    {
        class Node
        {
            int sum; // суммарная частота встречающихся символов в каждом поддереве
        }

        // внутренний узел с двумя потомками: левый и правый
        class InternalNode : Node
        {
            Node left;
            Node right;

            public InternalNode(Node left, Node right)
            {
                this.left = left;
                this.right = right;
            }
        }

        // узлы - листья (лист отвечает определенному символу
        class LeafNode : Node
        {
            char symbol;
        }

        public static void ReadFile()
        {
            string sLine = "";
            StreamReader objReader;
            try
            {
                objReader = new StreamReader("test.txt");
            }
            catch ( FileNotFoundException )
            {
                 throw new FileNotFoundException( string.Format("File not found!"));
            }
          
            sLine = objReader.ReadLine();
            Console.WriteLine(sLine);

            Dictionary<char, int> count = new Dictionary<char, int>();

            // анализируем считанную строку и считаем количество симовлов в строчке
            for (int i = 0; i < sLine.Length; i++)
            {
                char c = sLine[i];
                Console.WriteLine(c);

                if (count.ContainsKey(c))
                {
                    count[c]++;
                }
                else
                {
                    count.Add(c, 1);
                }
            }

            char[] keyVal = new char[count.Count];

            count.Keys.CopyTo(keyVal, 0);

            for (int j = 0; j < count.Values.Count; j++)
            {
                Console.WriteLine("{0} : {1}", keyVal[j], count[keyVal[j]]);
            }
            objReader.Close();
        }
    }
}
