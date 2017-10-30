using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PriorityQueue
{
    // двоичная куча
    // хорошая статья: http://neerc.ifmo.ru/wiki/index.php?title=%D0%94%D0%B2%D0%BE%D0%B8%D1%87%D0%BD%D0%B0%D1%8F_%D0%BA%D1%83%D1%87%D0%B0
    //class BinaryHeap
    //{
        /* Общая информация по бинарной куче:
        Двоичная куча (пирамида) - двоичное подвешенное дерево, для которого выполняются следующие три условия:
        - значение в любой вершине не меньше (если куча для максимума), чем значение ее потомков
        - на i-ом слое 2^i вершин, кроме последней, слои нумеруются с нуля
        - последний слой заполнен слева направо
        
        Удобнее всего кучу хранить в виде массива с нулевым элементом - элементом в корне.
        Двоичные кучи используют, например, для того, чтобы извлекать минимум (максимум) из набора числе за O(log n).
        Двоичные кучи являются частным случаем приоритетных очередей.

        Базовые процедуры бинарной кучи:
        1. Воссатновление свойств кучи:
            siftDown - просеивание вниз (если значение измененного элемента увеличивается)
            siftUp - просевивание вверх (если значение измененного элемента уменьшается)
        2. Извлечение минимального (максимального) элемента:
            Значение корневого элемента (он и является минимальным) сохраняется для последующего возврата.
            Последний элемент копируется в корень, после чего удаляется из кучи.
            Вызывается \mathrm {siftDown} для корня.
            Сохранённый элемент возвращается.
        3. Добавление нового элемента
            Выполняет добавление элемента в кучу за время O(log n).
            Добавление произвольного элемента в конец кучи, и восстановление свойства упорядоченности с помощью процедуры siftUp.
        4. Построение кучи на О(n)
        5. Слияние двух куч
        6. Поиск k-ого элемента
        */
        /*
        private List<int> Heap;

        public int heapSize
        {
            get
            {
                return this.Heap.Count();
            }
        }

        // добавление нового элемента
        public void add(int value)
        {
            Heap.Add(value);
            int i = heapSize - 1;
            int parent = (i - 1) / 2;

            while (i > 0 && Heap[parent] < Heap[i])
            {
                int temp = Heap[i];
                Heap[i] = Heap[parent];
                Heap[parent] = temp;

                i = parent;
                parent = (i - 1) / 2;
            }
        }

        // восстанавливает основное свойство кучи для дерева с корнем в i-ой вершине при условии, что оба поддерева ему удовлетворяют
        public void heapify(int i)
        {
            int leftChild;
            int rightChild;
            int largestChild;

            for (;;)
            {
                leftChild = 2 * i + 1;
                rightChild = 2 * i + 2;
                largestChild = i;

                if (leftChild < heapSize && Heap[leftChild] > Heap[largestChild])
                {
                    largestChild = leftChild;
                }

                if (rightChild < heapSize && Heap[rightChild] > Heap[largestChild])
                {
                    largestChild = rightChild;
                }

                if (largestChild == i)
                {
                    break;
                }

                int temp = Heap[i];
                Heap[i] = Heap[largestChild];
                Heap[largestChild] = temp;
                i = largestChild;
            }
        }
        
        // построение кучи
        public void buildHeap(int[] sourceArray)
        {
            Heap = sourceArray.ToList();
            for (int i = heapSize / 2; i >= 0; i--)
            {
                heapify(i);
            }
        }

        // Извлечение (удаление) максимального элемента
        public int getMax()
        {
            int result = Heap[0];
            Heap[0] = Heap[heapSize - 1];
            Heap.RemoveAt(heapSize - 1);
            return result;
        }

    }*/


}
