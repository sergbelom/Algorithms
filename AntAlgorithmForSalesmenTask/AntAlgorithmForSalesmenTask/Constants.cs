using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntAlgorithmForSalesmenTask
{
    // class with definitions contants
    // max count of node , max distance , max tour , max count of ants , init count of pheremone , coefficient for AntAlgorithm: ALPHA, BETA, RHO, QVAL
    public static class Constants
    {
        // max count of NODE
        public const int MAX_NODES = 15;
        // max distance
        public const int MAX_DISTANCE = 100;
        // max tour (max path)
        public const int MAX_TOUR = (MAX_NODES * MAX_DISTANCE);
        // max count of ants
        public const int MAX_ANTS = 10;
        // ALPHA (parameter for AntAlgorithm)
        public const double ALPHA = 1.0;
        // BETA (parameter for AntAlgorithm)
        public const double BETA = 5.0;
        // RHO (parameter for AntAlgorithm)
        public static double RHO = 0.5;
        // QVAL (parameter for AntAlgorithm)
        public static int QVAL = 100;
        // max count of tours
        public const int MAX_TOURS = 20;
        // max time
        public const int MAX_TIME = (MAX_TOURS * MAX_NODES);
        // init count of pheremone
        public const double INIT_PHEROMONE = (1.0 / MAX_NODES);
    }
}
