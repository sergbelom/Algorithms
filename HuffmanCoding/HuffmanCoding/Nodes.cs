using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    //КЛАССЫ ДЛЯ УЗЛОВ
    // класс узел
    class Node : IComparable<Node>
    {
        readonly public int sum; // суммарная частота встречающихся символов в каждом поддереве
        public String code;

        public virtual void BuildCode(String code)
        {
            this.code = code;
        }

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

        public override void BuildCode(String code)
        {
            base.BuildCode(code);
            left.BuildCode(code + "0");
            right.BuildCode(code + "1");
        }

        public InternalNode(Node left, Node right) : base(left.sum + right.sum)
        {
            this.left = left;
            this.right = right;
        }

    }
    // узлы - листья (лист отвечает определенному символу
    class LeafNode : Node
    {
        char symbol;

        public override void BuildCode(String code)
        {
            base.BuildCode(code);
            Console.WriteLine(symbol + ": " + code);

        }

        public LeafNode(char symbol, int count) : base(count)
        {
            this.symbol = symbol;
        }
    }
}
