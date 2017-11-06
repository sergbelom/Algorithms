using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntAlgorithmForSalesmenTask
{
    // class AntType
    class AntType
    {
        // current Node
        public int currentNode;
        // next Node
        public int nextNode;
        // tabu list
        public int[] tabu;
        // path index
        public int pathIndex;
        // path
        public int[] path;
        // lenght path
        public double tourLength;
        // constructor for init filed class
        public AntType()
        {
            currentNode = 0;
            nextNode = 0;
            pathIndex = 0;
            tabu = new int[Constants.MAX_NODES];
            path = new int[Constants.MAX_NODES];
            tourLength = 0;
        }

    }
}
