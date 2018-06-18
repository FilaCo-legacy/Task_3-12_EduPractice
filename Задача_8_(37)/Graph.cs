using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Задача_8__37_
{
    /// <summary>
    /// Класс, задающий неориентированный граф, который определён матрицей инцидентности
    /// </summary>
    class Graph
    {
        public const int MaxNumberNodes = 10;
        public const int MinNumberNodes = 2;
        /// <summary>
        /// Матрица инцидентности (строки - вершины, столбцы - рёбра)
        /// </summary>
        private int [,] incidenceMatr;
        private int _numNodes;
        private int _numVerges;
        private List<int> cutPoints;
        private void DFS(int node, ref bool [] used, ref int timer, ref int[] tin, ref int [] fup, int parent = -1)
        {
            used[node] = true;
            tin[node] = fup[node] = timer++;
            int children = 0;
            for (var curV = 0; curV < NumVerges; ++curV)
            {
                if (this[node, curV] != 1)
                    continue;
                for (var curN = 0; curN < NumNodes; ++curN)
                {
                    if (this[curN, curV] == 1 && curN != node)
                    {
                        if (curN == parent)
                            break;
                        if (used[curN])
                            fup[node] = Math.Min(fup[node], tin[curN]);
                        else
                        {
                            DFS(curN, ref used, ref timer,ref tin, ref fup, node);
                            fup[node] = Math.Min(fup[node], fup[curN]);
                            if (fup[curN] >= tin[node] && parent != -1 && !cutPoints.Contains(node + 1))
                                cutPoints.Add(node+1);
                            ++children;
                        }
                        break;
                    }
                }
                if (parent == -1 && children > 1 && !cutPoints.Contains(node + 1))
                    cutPoints.Add(node+1);
            }
        }
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
        private static Random rnd = new Random();
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
        public int NumNodes { get { return _numNodes; } }
        public int NumVerges { get { return _numVerges; } }
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
            for (int curV = 0; curV < matrValue.GetLength(1); ++curV)
            {
                int cnt = 0;
                for (int curN = 0; curN < matrValue.GetLength(0); ++curN)
                {
                    cnt += matrValue[curN, curV];
                    if (cnt > 2 || matrValue[curN, curV] != 0 && matrValue[curN, curV] != 1)
                        throw new Exception("Матрица инцидентности задана некорректно");
                }
            }
            _numNodes = matrValue.GetLength(0);
            _numVerges = matrValue.GetLength(1);
            incidenceMatr = matrValue;
        }
        public Graph(int numNodes, int numVerges)
        {
            if (numVerges > numNodes * (numNodes - 1) / 2)
                throw new Exception("Граф не может содержать более n*(n-1)/2 рёбер, где n - кол-во вершин");
            _numNodes = numNodes;
            _numVerges = numVerges;
            incidenceMatr = new int[numNodes, numVerges];
            GenerateGraph();
        }
        public Graph()
        {
            _numNodes = rnd.Next(MinNumberNodes, MaxNumberNodes + 1);
            Thread.Sleep(15);
            _numVerges = rnd.Next(NumNodes - 1, NumNodes * (NumNodes - 1) / 2 + 1);
            incidenceMatr = new int[NumNodes, NumVerges];
            GenerateGraph();
        }
        public void Show()
        {
            Console.WriteLine("Граф имеет {0} вершин и {1} рёбер", NumNodes, NumVerges);
            if (cutPoints != null)
            {
                Console.WriteLine("Среди них {0} точек сочленения:", cutPoints.Count);
                foreach (var curN in cutPoints)
                    Console.Write("{0} ", curN);
                Console.WriteLine();
            }
            Console.WriteLine("Матрица инцидентности:");
            Console.WriteLine("+" + new string('-', 2 * NumVerges - 1) + "+");
            for (int i = 0; i < NumNodes; ++i)
            {
                if (cutPoints != null && cutPoints.Contains(i + 1))
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("|");
                for (int j = 0; j < NumVerges; ++j)
                    Console.Write("{0}|", this[i, j]);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("+" + new string('-', 2 * NumVerges - 1) + "+");
            }
        }
        public void FindAllCutPoints()
        {
            bool[] used = new bool[NumNodes];
            int timer = 0;
            int[] tin = new int[NumNodes], fup = new int[NumNodes];
            cutPoints = new List<int>();
            DFS(0, ref used, ref timer, ref tin, ref fup);
        }
    }
}
