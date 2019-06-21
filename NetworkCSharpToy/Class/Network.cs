using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCSharpToy
{ 
    class Network
    {
        public Network()
        {
            this.adjacencyMatrix = NetworkSamples.ZacharyKarate;
        }

        public Network(int[,] adjacencyMatrix)
        {
            this.adjacencyMatrix = adjacencyMatrix;
        }

        //AdjacencyMatrix
        private int[,] adjacencyMatrix;
        public int[,] AdjacencyMatrix { get => adjacencyMatrix; }



    }
}
