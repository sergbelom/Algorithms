using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HuffmanCoding
{

    class HuffmanCode
    {
        // считывание происходит с файла text.txt, который лежит в исходниках
        public static string ReadFile()
        {

            StreamReader objReader;
            try
            {
                objReader = new StreamReader("text.txt");
            }
            catch ( FileNotFoundException )
            {
                throw new FileNotFoundException( string.Format("File not found!"));
            }

            string inputStr = objReader.ReadLine();
            objReader.Close();

            return inputStr;
        }
        
        // запуск процесса получения оптимального кода (сам алгоритм)
        public static void Run()
        {

            ReadFile();

            string sLine = "";
            
            sLine = Console.ReadLine();

            // словарь для (символ,частота)
            Dictionary<char, int> count = new Dictionary<char, int>();

            // анализируем считанную строку и считаем количество симовлов в строчке
            for (int i = 0; i < sLine.Length; i++)
            {
                char c = sLine[i];

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
            
            // словарь для (символ,узел)
            Dictionary<char, Node> charNodes = new Dictionary<char, Node>();

            PriorityQueue<Node> priorityQueue = new PriorityQueue<Node>();

            // добавим в приоритетную очередь элементы по одному как они встречаются у нас в списке
            foreach (KeyValuePair<char, int> kvp in count)
            {
                //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);

                LeafNode currentChar = new LeafNode(kvp.Key, kvp.Value);
                charNodes.Add(kvp.Key, currentChar);

                priorityQueue.Add(currentChar, kvp.Value);
            }

            int sum = 0;
            InternalNode node;
            while (priorityQueue.NumItems > 1 )
            {
                 Node first; int firstPriority;
                 priorityQueue.Poll( out first , out firstPriority );

                 Node second; int secondPriority;
                 priorityQueue.Poll( out second , out secondPriority);

                 node = new InternalNode(first, second);
                    
                 sum += node.sum;

                 priorityQueue.Add(node, first.sum + second.sum);
            }
            // для случае с одним элементом
            if ( count.Count == 1 )
            {
                sum = sLine.Length;
            }

            Console.WriteLine(count.Count + " " + sum);

            // создаем корень как последний оставшийся элемент очереди
            Node root;
            int rootPrior;

            priorityQueue.Poll(out root , out rootPrior);

            // для случае с одним элементом
            if (count.Count == 1)
            {
                root.code = "0";
                root.BuildCode("0");
            }
            else
            {
                root.BuildCode("");
            }
            
            // строка с результатом кодирования (собираем все символы в одну сроку)
            //string resultEncoding = "";

            //добавлено использование класса StringBuilder
            StringBuilder strBuilder = new StringBuilder();
            for ( int i = 0; i < sLine.Length; i++ )
            {
                char c = sLine[i];
                strBuilder.Append(charNodes[c].code);
            }

            Console.WriteLine(strBuilder.ToString());
                      
        }
    }
}

// можно использовать для вывода частоты появления символов
//for (int j = 0; j < count.Values.Count; j++)
//{
//Console.WriteLine("{0} : {1}", keyVal[j], count[keyVal[j]]);
//}
