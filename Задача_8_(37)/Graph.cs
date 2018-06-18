using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Задача_8__37_
{
    /// <summary>
    /// Класс, задающий граф, который определён матрицей инцидентности
    /// </summary>
    class Graph
    {
        public const int MaxNumberNodes = 10;
        public const int MinNumberNodes = 1;
        /// <summary>
        /// Матрица инцидентности (строки - вершины, столбцы - рёбра)
        /// </summary>
        private int [,] incidenceMatr;
        private static bool isConnected(Graph graph, int[] verge)
        {
            for (int i = 0; i < graph.NumVerges; ++i)
            {
                int[] curVerge = new int[2];
                int it = 0;
                for (int k = 0; k < graph.NumNodes; ++k)
                {
                    if (it == 2)
                        break;
                    if (graph[k, i] == 1)
                        curVerge[it++] = k;
                }
                if (verge[0] == curVerge[0] && verge[1] == curVerge[1] || verge[0] == curVerge[1] && verge[1] ==
                    curVerge[0])
                    return true;
            }
            return false;
        }
        private static Random rnd= new Random();
        private void GenerateGraph()
        {
            for (int i = 0; i < NumVerges; ++i)
            {
                int node1 = 0, node2 = 0;
                bool flag = false;
                while (!flag)
                {
                    flag = true;
                    node1 = rnd.Next(0, NumNodes);
                    Thread.Sleep(15);
                    do
                    {
                        node2 = rnd.Next(0, NumNodes);
                    } while (node1 == node2);
                    flag = !isConnected(this, new int[] { node1, node2 });
                }
                incidenceMatr[node1, i] = incidenceMatr[node2, i] = 1;
            }
        }
        public int NumNodes { get { return incidenceMatr.GetLength(0); } }
        public int NumVerges { get { return incidenceMatr.GetLength(1); } }
        public int this[int node, int verge]
        {
            get
            {
                if (node < 0 || verge < 0 || node >= NumNodes || verge >= NumVerges)
                    throw new Exception("Номер ребра или вершины задан некорректно");
                return incidenceMatr[node, verge];

            }
        }
        public Graph(int[,] matrValue)
        {
            incidenceMatr = matrValue;
        }
        public Graph(int numNodes, int numVerges)
        {
            if (numVerges > numNodes * (numNodes - 1) / 2)
                throw new Exception("Граф не может содержать более n*(n-1)/2 рёбер, где n - кол-во вершин");
            incidenceMatr = new int[numNodes, numVerges];
            GenerateGraph();
        }
        public Graph()
        {
            int numNodes = rnd.Next(MinNumberNodes, MaxNumberNodes + 1);
            Thread.Sleep(15);
            int numVerges = rnd.Next(numNodes - 1, numNodes * (numNodes - 1) / 2 + 1);
            incidenceMatr = new int[numNodes, numVerges];
            GenerateGraph();
        }
        public void Show()
        {
            Console.WriteLine(@"Граф имеет {0} вершин и {1} рёбер
Матрица инцидентности:", NumNodes, NumVerges);
            Console.WriteLine("+" + new string('-', 2 * NumVerges - 1) + "+");
            for (int i = 0; i < NumNodes; ++i)
            {
                Console.Write("|");
                for (int j = 0; j < NumVerges; ++j)
                    Console.Write("{0}|", this[i, j]);
                Console.WriteLine();
                Console.WriteLine("+" + new string('-', 2*NumVerges-1) + "+");
            }
        }
    }
}
