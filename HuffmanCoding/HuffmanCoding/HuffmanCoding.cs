using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanCoding
{
    class HuffmanCode
    {
        class Node : IComparable<Node>
        {
            readonly public int sum; // суммарная частота встречающихся символов в каждом поддереве

            public Node(int sum)
            {
                this.sum = sum;
            }               
            public int CompareTo(Node other)
            {
                return sum.CompareTo(other.sum);
            }
        }

        // внутренний узел с двумя потомками: левый и правый
        class InternalNode : Node
        {
            Node left; Node right;

            public InternalNode(Node left, Node right) : base(left.sum + right.sum)
            {
                this.left = left;
                this.right = right;
                // sum = ;
            }
        }

        // узлы - листья (лист отвечает определенному символу
        class LeafNode : Node
        {
            char symbol;
            
            public LeafNode( char symbol , int count ) : base(count)  {
                this.symbol = symbol;
                //this.sum = count;
            }
        }

        public static void Run()
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

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            // добавим в приоритетную очередь элементы по одному как они встречаются у нас в списке

            foreach (KeyValuePair<char, int> kvp in count)
            {
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);

                LeafNode currentChar = new LeafNode(kvp.Key, kvp.Value);

                priorityQueue.Add(currentChar, kvp.Value);
            }
                int sum = 0;
                while (priorityQueue.NumItems > 1 )
                {
                    Node first; int firstPriority;
                    priorityQueue.Poll( out first , out firstPriority );

                    Node second; int secondPriority;
                    priorityQueue.Poll( out second , out secondPriority);

                    InternalNode node = new InternalNode(first, second);
                    sum += node.sum;
                    priorityQueue.Add( node , first.sum + second.sum );
                }
                Console.WriteLine(sum);



            

        }
    }
}
