using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PriorityQueue
{
    class Program
    {
        // метод для работы программы на основе приоритетной кучи
        
        private static List<int> resultElementUsePriorityQueueV1()
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
            return result;
        }

        private static List<int> resultElementUsePriorityQueueV2()
        {
            PriorityQueueGeneric<int> inputQueue = new PriorityQueueGeneric<int>();
            List<int> result = new List<int>();

            // получаем количество всех строк
            int countStringData;
            countStringData = int.Parse(Console.ReadLine());
            // массив с информацией о всех строках
            int[] allData = new int[countStringData];
            // массив для считанной текущей строки (0 - маркер, 1 - числовые данные)
            string[] interString = new string[2];
            // промежуточный массив для формирования кучи
            List<int> interDataForHeap = new List<int>();
            int interValue = 0;
            int resultInterValue = 0;
            //int h = 0; // номер вершины в куче

            // считываем в цикле все строки и заполняем массив с данными
            for (int i = 0; i < countStringData; i++)
            {
                interString = Console.ReadLine().Split(' ');
                if (interString[0] == "Insert")
                {
                    allData[i] = int.Parse(interString[1]);
                    // создаем кучу
                    if (i == 0 || (allData[i - 1] == -1))// && allData[i-2] != -1) )
                    {
                        interDataForHeap.Clear(); // перед каждым новым заданием корня кучи чистим список промежуточных элементов
                        interDataForHeap.Add(allData[i]); // добавляем корень кучи
                    }
                    else
                    {
                        interDataForHeap.Add(allData[i]);
                    }
                }
                // при первом обнаружении ExtractMax происходит построение кучи
                else if (interString[0] == "ExtractMax" && allData[i - 1] != -1)
                {
                    foreach (int elem in interDataForHeap)
                    {
                        inputQueue.Add(elem, interValue);
                    }
                    allData[i] = -1;
                    inputQueue.Poll(out resultInterValue, out resultInterValue);
                    result.Add(resultInterValue);
                }
                else if (interString[0] == "ExtractMax")
                {
                    allData[i] = -1; //-1 будет соответсвовать операции извлечь                  
                    inputQueue.Poll(out resultInterValue, out resultInterValue);
                    result.Add(resultInterValue);
                }
            }
            return result;
        }

        class BinaryHeap
        {
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
                    leftChild = 2 * i ;
                    rightChild = 2 * i + 1;
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

                for (int i = heapSize/2; i >= 0; i--)
                {
                    heapify(i);
                }
            }

            // Извлечение (удаление) максимального элемента
            public int getMax()
            {
                int result = Heap[0];
                Heap[0] = Heap[heapSize - 1];
                Heap.RemoveAt(0);
                heapify(0);
                return result;
            }
        }

        private static List<int> resultElementUseBinaryHeapV1()
        {
            BinaryHeap inputHeap = new BinaryHeap();
            List<int> result = new List<int>();

            // считываем количество входных строк
            int countLine;
            countLine = int.Parse(Console.ReadLine());

            // определяем переменные для хранения промежуточных элементов
            string[] lineFromConsole;
            int interValue = 0;
            string[] interMarkArrForAllElem = new string[countLine];
            int startArrForHeap = 0, finishArr = 0;
            int[] interArrValue = new int[countLine];
            int[] interArrValueForHeap;

            // прогоняем весь массив входных данных, парсим каждую строку и записываем все численные данные в общий "большой" численные массив
            for (int i = 0; i < countLine; i++)
            {
                lineFromConsole = Console.ReadLine().Split(' ');
                interMarkArrForAllElem[i] = lineFromConsole[0];
                if (lineFromConsole[0] != "ExtractMax")
                {
                    interValue = int.Parse(lineFromConsole[1]);
                    // опредеяем начальный элемент, с которого будет начинаться формироваться подмассив для записи в кучу
                    // если текущий элемент не ExtractMax, а предыдущий или не существует или ExtractMax
                    if (i == 0 || (interMarkArrForAllElem[i - 1] == "ExtractMax"))
                    {
                        startArrForHeap = i; interArrValue[i] = interValue;
                    }
                    else
                    {
                        interArrValue[i] = interValue;
                    }
                }
                else if (interMarkArrForAllElem[i] == "ExtractMax")
                {
                    // определяем конечный элемент подмассива
                    finishArr = i - 1;
                    interArrValueForHeap = new int[finishArr - startArrForHeap + 1];
                    // формируем подмассив, который затем подадим на для формирования кучи
                    for (int j = 0; j < interArrValueForHeap.Length; j++)
                    {
                        interArrValueForHeap[j] = interArrValue[startArrForHeap]; startArrForHeap++;
                    }
                    // строим кучу на основе промежуточного массива
                    inputHeap.buildHeap(interArrValueForHeap);
                    // извлекаем из кучи макс элемент и добавляем в список с другими максимальными элементами
                    result.Add(inputHeap.getMax());
                }
                else if (interMarkArrForAllElem[i] == "ExtractMax" && interMarkArrForAllElem[i - 1] == "ExtractMax")
                {
                    // определяем конечный элемент подмассива
                    finishArr = i - 2;
                    interArrValueForHeap = new int[finishArr - startArrForHeap + 1];
                    // формируем подмассив, который затем подадим на для формирования кучи
                    for (int j = 0; j < interArrValueForHeap.Length; j++)
                    {
                        interArrValueForHeap[j] = interArrValue[startArrForHeap]; startArrForHeap++;
                    }
                    // строим кучу на основе промежуточного массива
                    inputHeap.buildHeap(interArrValueForHeap);
                    // извлекаем из кучи макс элемент и добавляем в список с другими максимальными элементами
                    result.Add(inputHeap.getMax());
                }
                
            }
                return result;
            
        }
        
        private static List<int> resultElementUseBinaryHeapV2()
        {
            BinaryHeap interHeap = new BinaryHeap();
            List<int> result = new List<int>();

            // получаем количество всех строк
            int countStringData;
            countStringData = int.Parse(Console.ReadLine());
            // массив с информацией о всех строках
            int[] allData = new int[countStringData];
            // массив для считанной текущей строки (0 - маркер, 1 - числовые данные)
            string[] interString = new string[2];
            // промежуточный массив для формирования кучи
            List<int> interDataForHeap = new List<int>();

            //int h = 0; // номер вершины в куче

            // считываем в цикле все строки и заполняем массив с данными
            for ( int i =0; i < countStringData; i++ )
            {
                interString = Console.ReadLine().Split(' ');
                if (interString[0] == "Insert")
                {
                    allData[i] = int.Parse(interString[1]);
                    // создаем кучу
                    if (i == 0 || (allData[i-1] == -1) )// && allData[i-2] != -1) )
                    {
                        interDataForHeap.Clear(); // перед каждым новым заданием корня кучи чистим список промежуточных элементов
                        interDataForHeap.Add(allData[i]); // добавляем корень кучи
                    }
                    else
                    {
                        interDataForHeap.Add(allData[i]);
                    }                   
                }
                // при первом обнаружении ExtractMax происходит построение кучи
                else if (interString[0] == "ExtractMax" && allData[i-1] != -1)
                {
                    interHeap.buildHeap(interDataForHeap.ToArray());
                    allData[i] = -1;
                    result.Add(interHeap.getMax());
                }
                else if (interString[0] == "ExtractMax")
                {
                    allData[i] = -1; //-1 будет соответсвовать операции извлечь                  
                    result.Add(interHeap.getMax());
                }
            }     
            return result;
        }

        static void Main(string[] args)
        {
            List<int> resultUseBinaryHeap = resultElementUsePriorityQueueV2();

            foreach (int elemHeap in resultUseBinaryHeap)
            {
                Console.WriteLine(elemHeap);
            }

            //Console.ReadKey();

        }
    }
}
