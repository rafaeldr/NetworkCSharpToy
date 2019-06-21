using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkCSharpToy.Algorithms
{
    static class Centrality
    {
        // TODO: AS-IS algorithms suppose a full component; all nodes reachable

        //Eccentricity
        static public int[] eccentricity(int[,] adjMatrix)
        {
            int n = adjMatrix.GetLength(0);
            int[] eccent = new int[n];

            int[] distance;
            int[] queue;
            int pRead = 0;  //read pointer
            int pWrite = 0; //write pointer
            int readingNode = -1;

            // BFS Strategy // Breadth-First Search
            for (int startNode = 0; startNode<n; startNode++) // Each possible node as Start Point
            {
                // RESET 
                distance = Enumerable.Repeat(-1, n).ToArray();
                queue = Enumerable.Repeat(-1, n).ToArray();
                pRead = pWrite = 0;

                queue[pWrite++] = startNode;
                distance[startNode] = 0; //Only start node at this level (d==0)

                // Walking through graph in BFS
                while (pRead<n) 
                {
                    readingNode = queue[pRead++];

                    if (readingNode == -1) // unreachable more components
                        break;

                    // Find Neighbors
                    for (int j = 0; j < n; j++)
                    {
                        if (adjMatrix[readingNode, j] == 1)
                        {
                            if (!queue.Contains(j))
                            {
                                queue[pWrite++] = j;
                                distance[j] = distance[readingNode]+1; // current d + 1
                            }
                        }
                    }
                }

                // Max?
                eccent[startNode] = distance.Max();
            }

            return eccent;
        }

        static public int[] closeness(int[,] adjMatrix)
        {
            int n = adjMatrix.GetLength(0);
            int[] closeness = new int[n];

            int[] distance; // From a specific start node to all other possible nodes
            int[] queue;
            int pRead = 0;  //read pointer
            int pWrite = 0; //write pointer
            int readingNode = -1;

            // BFS Strategy // Breadth-First Search
            for (int startNode = 0; startNode < n; startNode++) // Each possible node as Start Point
            {
                // RESET 
                distance = Enumerable.Repeat(-1, n).ToArray();
                queue = Enumerable.Repeat(-1, n).ToArray();
                pRead = pWrite = 0;

                queue[pWrite++] = startNode;
                distance[startNode] = 0; //Only start node at this level (d==0)

                // Walking through graph in BFS
                while (pRead < n)
                {
                    readingNode = queue[pRead++];

                    if (readingNode == -1) // unreachable -> more components
                        break;

                    // Find Neighbors
                    for (int j = 0; j < n; j++)
                    {
                        if (adjMatrix[readingNode, j] == 1)
                        {
                            if (!queue.Contains(j))
                            {
                                queue[pWrite++] = j;
                                distance[j] = distance[readingNode] + 1; // current d + 1
                            }
                        }
                    }
                }

                // Closeness: Accumulates distances (ignoring unreachable == -1)
                closeness[startNode] = 
                    distance.Select((x, i) => x == -1 ? 0 : x).Sum();
            }

            return closeness;
        }

    }

    static class Graph_Classical
    {
        static public int dijkstra(int[,] adjMatrix, int source, int destiny)
        {
            int n = adjMatrix.GetLength(0);
            int[] closeness = new int[n]; // ERASE

            int[] distance; // From a specific start node to all other possible nodes
            int[] previous; // Store shortest-path (always related to souce node) / precedent
            bool[] perm; // Node already DONE!
            int current;
            
            distance = Enumerable.Repeat(-1, n).ToArray(); // Presume no negative distances
            previous = Enumerable.Repeat(-1, n).ToArray();
            perm = Enumerable.Repeat(false, n).ToArray();
            
            // START
            current = source;
            distance[current] = 0;
            //perm[current] = true;

            // Mix Strategy // BFS predominates over DFS  (search with BFS walk with DFS)
            while (current != destiny)
            {
                perm[current] = true;

                // Find Neighbors
                for (int i = 0; i < n; i++)
                {
                    if (adjMatrix[current, i] != 0)
                    {
                        // Update distance if is SHORT  (OR never updated)
                        if(distance[i]==-1 ||
                            (distance[current] + adjMatrix[current, i]) < distance[i] )
                        {
                            distance[i] = distance[current] + adjMatrix[current, i];
                            previous[i] = current;
                        }
                    }
                }

                // Choose Next
                int smallest = -1;
                for (int i = 0; i < n; i++)
                {
                    if (perm[i] == true || distance[i] == -1) // Skip permanents and not reached yet
                        continue;

                    if(distance[i] < smallest || smallest == -1)
                    {
                        smallest = distance[i];
                        current = i;
                    }
                }
                if (smallest == -1)
                    break; // Destiny is UNREACHABLE

            }

            return distance[destiny];
        }
    }
}
