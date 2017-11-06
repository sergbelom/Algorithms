using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntAlgorithmForSalesmenTask
{
    //TODO: добавить развернутый комментарий по классу-песочнице
    // the Ant Algorithm based on C code from book Tim Jones AI Application Programming
    // the class used for study Ant Algorithm and not used in TicTacToe
    class AntAlgorithmTravelingSalesman
    {
        // TODO: переделать некоторые логические конструкции на тернарные операторы
        // nodes
        static NodeType[] nodes = new NodeType[Constants.MAX_NODES];
        // ants
        static AntType[] ants = new AntType[Constants.MAX_ANTS];
        // two-dimensional array for distance between i and j nodes
        static double[,] distance = new double[Constants.MAX_NODES, Constants.MAX_NODES];
        // two-dimensional array for pheremon between i and j nodes
        static double[,] pheromone = new double[Constants.MAX_NODES, Constants.MAX_NODES];
        // best Tour
        static double best = (double)(Constants.MAX_TOUR);
        // best Index
        static int bestIndex;

        // method for initialisation
        public static void Init()
        {

            int from, to, ant;
            // creates nodes and location of nodes
            for (from = 0; from < Constants.MAX_NODES; from++)
            {
                // random distrubution nodes on map
                nodes[from].x = RandomProvider.getRand(Constants.MAX_DISTANCE); nodes[from].y = RandomProvider.getRand(Constants.MAX_DISTANCE);
                // getRand(Constants.MAX_DISTANCE);
                for (to = 0; to < Constants.MAX_NODES; to++)
                {
                    distance[from, to] = 0.0;
                    pheromone[from, to] = Constants.INIT_PHEROMONE;
                }
            }
            // calculate distanes for each nodes on map
            for (from = 0; from < Constants.MAX_NODES; from++)
            {
                for (to = 0; to < Constants.MAX_NODES; to++)
                {
                    if ((to != from) && (distance[from, to] == 0.0))
                    {
                        int xd = Math.Abs(nodes[from].x - nodes[to].x); int yd = Math.Abs(nodes[from].y - nodes[to].y);
                        distance[from, to] = Math.Sqrt((xd * xd) + (yd * yd));
                        distance[to, from] = distance[from, to];
                    }
                }
            }

            // ant init
            to = 0;
            for (ant = 0; ant < Constants.MAX_ANTS; ant++)
            {
                ants[ant] = new AntType();
                // distrubution ants at each site evenly
                if (to == Constants.MAX_NODES) to = 0;
                ants[ant].currentNode = to++;

                for (from = 0; from < Constants.MAX_NODES; from++)
                {
                    ants[ant].tabu[from] = 0;
                    ants[ant].path[from] = -1;
                }
                ants[ant].pathIndex = 1;
                ants[ant].path[0] = ants[ant].currentNode;
                ants[ant].nextNode = -1;
                ants[ant].tourLength = 0.0;

                // download current nodes of ant in tabu list
                ants[ant].tabu[ants[ant].currentNode] = 1;

            }
        }

        // reinitialisation ants for start in another round in the graph
        static void RestartAnts()
        {
            int ant, i, to = 0;

            for (ant = 0; ant < Constants.MAX_ANTS; ant++)
            {
                if (ants[ant].tourLength < best)
                {
                    best = ants[ant].tourLength;
                    bestIndex = ant;
                }

                ants[ant].nextNode = -1;
                ants[ant].tourLength = 0.0;

                for (i = 0; i < Constants.MAX_NODES; i++)
                {
                    ants[ant].tabu[i] = 0;
                    ants[ant].path[i] = -1;
                }

                if (to == Constants.MAX_NODES) to = 0;
                ants[ant].currentNode = to++;

                ants[ant].pathIndex = 1;
                ants[ant].path[0] = ants[ant].currentNode;

                ants[ant].tabu[ants[ant].currentNode] = 1;

            }

        }

        // calculate denominator for equation probability path
        // concantration pheromon current path on sum all concantration avalabli paths
        static double AntProduct(int from, int to)
        {
            return Math.Pow(pheromone[from, to], Constants.ALPHA) * Math.Pow((1.0 / distance[from, to]), Constants.BETA);
        }

        // using algorithm select probability path and current level pheremon of graph , select next node for ant trip
        static int SelectnextNode(int ant)
        {
            int from, to;
            double denom = 0.0;

            // select next node for trip
            from = ants[ant].currentNode;

            // culculate denominator
            for (to = 0; to < Constants.MAX_NODES; to++)
            {
                if (ants[ant].tabu[to] == 0)
                {
                    denom += AntProduct(from, to);
                }
            }

            Debug.Assert(denom != 0.0);

            double p;

            do
            {
                to++;
                if (to >= Constants.MAX_NODES) to = 0;

                if (ants[ant].tabu[to] == 0)
                {

                    p = AntProduct(from, to) / denom;

                    if (RandomProvider.getSRand() < p) break;

                }

            } while (true);

            return to;
        }

        // modeling single step for each ant
        // the function will retirn 0 if all ants ends tour (trip)
        static int SimulateAnts()
        {

            int k;
            int moving = 0;

            for (k = 0; k < Constants.MAX_ANTS; k++)
            {
                // TODO: translate to english language
                // убедимся в том, что муравей до сих пор имеет узлы для посещения
                if (ants[k].pathIndex < Constants.MAX_NODES)
                {
                    ants[k].nextNode = SelectnextNode(k);
                    ants[k].tabu[ants[k].nextNode] = 1;
                    ants[k].path[ants[k].pathIndex++] = ants[k].nextNode;
                    ants[k].tourLength += distance[ants[k].currentNode, ants[k].nextNode];
                    // TODO: translate to english language
                    // обработка финального сулчая (последний узел для первого)
                    if (ants[k].pathIndex == Constants.MAX_NODES)
                    {
                        ants[k].tourLength +=
                          distance[ants[k].path[Constants.MAX_NODES - 1], ants[k].path[0]];
                    }
                    ants[k].currentNode = ants[k].nextNode;
                    moving++;
                }

            }

            return moving;
        }

        // TODO: translate to english language
        // обновление троп (следов)
        // обновление уровня феромонов на каждом реьре на основе количества муравьев,
        // которые путешестовали по нему, включая испарение существующего феромона

        static void UpdateTrails()
        {
            int from, to, i, ant;
            // TODO: translate to english language
            // испарение феромона
            for (from = 0; from < Constants.MAX_NODES; from++)
            {
                for (to = 0; to < Constants.MAX_NODES; to++)
                {
                    if (from != to)
                    {
                        pheromone[from, to] *= (1.0 - Constants.RHO);
                        if (pheromone[from, to] < 0.0) pheromone[from, to] = Constants.INIT_PHEROMONE;
                    }
                }
            }
            // TODO: translate to english language
            // добавление нового феромона к следам
            // смотрим туры каждого муравья
            for (ant = 0; ant < Constants.MAX_ANTS; ant++)
            {
                // TODO: translate to english language
                // обновление каждого этапа тура, заданного длинной тура
                for (i = 0; i < Constants.MAX_NODES; i++)
                {
                    if (i < Constants.MAX_NODES - 1)
                    {
                        from = ants[ant].path[i];
                        to = ants[ant].path[i + 1];
                    }
                    else
                    {
                        from = ants[ant].path[i];
                        to = ants[ant].path[0];
                    }
                    pheromone[from, to] += (Constants.QVAL / ants[ant].tourLength);
                    pheromone[to, from] = pheromone[from, to];
                }
            }

            for (from = 0; from < Constants.MAX_NODES; from++)
            {
                for (to = 0; to < Constants.MAX_NODES; to++)
                {
                    pheromone[from, to] *= Constants.RHO;
                }
            }

        }
        // TODO: translate to english language
        // для каждого муравья с лучшего тура (кратчайший путь на гафе), генерируются вместе два файла
        static void GenerateDataFile(int ant)
        {
            int node;
            StreamWriter fp;

            fp = new StreamWriter("nodes.dat");
            for (node = 0; node < Constants.MAX_NODES; node++)
            {
                fp.WriteLine("узел {0} X: {1} Y: {2} \n", node, nodes[node].x, nodes[node].y);
            }
            fp.Close();

            fp = new StreamWriter("solution.dat");
            for (node = 0; node < Constants.MAX_NODES; node++)
            {
                fp.WriteLine(" муравей ants[ant].path[node]: {0} X: {1} Y: {2}\n", ants[ant].path[node], nodes[ants[ant].path[node]].x, nodes[ants[ant].path[node]].y);
            }
            fp.WriteLine(" path_0 X: {0} Y: {1}\n", nodes[ants[ant].path[0]].x, nodes[ants[ant].path[0]].y);

            fp.Close();
        }

        static void EmitTable()
        {
            int from, to;

            for (from = 0; from < Constants.MAX_NODES; from++)
            {
                for (to = 0; to < Constants.MAX_NODES; to++)
                {
                    Console.WriteLine("{0} ", pheromone[from, to]);
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("\n");
        }
        // TODO: translate to english language
        // метод Main для запуска алгоритмы Муравья
        static void Main(string[] args)
        {
            int curTime = 0;

            //srand(time(0));
            //var dt = DateTime.Now();

            Init();

            while (curTime++ < Constants.MAX_TIME)
            {

                if (SimulateAnts() == 0)
                {

                    UpdateTrails();

                    if (curTime != Constants.MAX_TIME)
                        RestartAnts();

                    Console.WriteLine("Time is {0} ({1})\n", curTime, best);
                }
            }

            Console.WriteLine("best tour {0}\n", best);
            Console.WriteLine("\n\n");
            Console.ReadKey();

            GenerateDataFile(bestIndex);

        }
    }
}

