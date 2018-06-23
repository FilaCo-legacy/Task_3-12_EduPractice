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
        /// Матрица смежности графа
        /// </summary>
        private int[,] adjMatr;
        private int _numNodes;
        private static Random rnd = new Random();
        private void GenerateGraph()
        {
            for (int i = 0; i < NumNodes; ++i)
                for (int j = 0; j < NumNodes; ++j)
                    if (rnd.Next(0, 3) == 0)
                        adjMatr[i, j] = 1;

        }
        private List <int> Dfs(int node, List <int> cycle, int k)
        {
            cycle.Add(node + 1);
            if (cycle.Count == k)
            {
                cycle.Add(cycle[0]);
                if (adjMatr[node, cycle[0] - 1] == 1)
                    return cycle;
                return null;
            }
            for (int i = 0; i < NumNodes; ++i)
                if (i != node && adjMatr[node, i] == 1 && !cycle.Contains(i + 1))
                {
                    List<int> cur = Dfs(i, new List<int>(cycle), k);
                    if (cur != null)
                        return cur;
                }
            return null;                
        }
        public int NumNodes { get { return _numNodes; } }
        public int this[int node1, int node2]
        {
            get
            {
                if (node1 < 0 || node2 < 0 || node1 >= NumNodes || node2 >= NumNodes)
                    throw new Exception("Номера вершин заданы некорректно");
                return adjMatr[node1, node2];

            }
        }
        public Graph(int[,] matrValue)
        {
            if (matrValue.GetLength(0) != matrValue.GetLength(1))
                throw new Exception("Матрица смежности должна быть квадратной");
            _numNodes = matrValue.GetLength(0);
            adjMatr = matrValue;
        }
        public Graph(int numNodes)
        {
            _numNodes = numNodes;
            adjMatr = new int[numNodes, numNodes];
            GenerateGraph();
        }
        public Graph()
        {
            _numNodes = rnd.Next(MinNumberNodes, MaxNumberNodes + 1);
            adjMatr = new int[NumNodes, NumNodes];
            GenerateGraph();
        }
        public void Show()
        {
            Console.WriteLine("Граф имеет {0} вершин(ы)", NumNodes);
            Console.WriteLine("Матрица смежности:");
            Console.WriteLine("+" + new string('-', 2 * NumNodes - 1) + "+");
            for (int i = 0; i < NumNodes; ++i)
            {
                Console.Write("|");
                for (int j = 0; j < NumNodes; ++j)
                    Console.Write("{0}|", this[i, j]);
                Console.WriteLine();
                Console.WriteLine("+" + new string('-', 2 * NumNodes - 1) + "+");
            }
        }
        public void FindCycle(int length)
        {
            if (NumNodes < 2)
            {
                Console.WriteLine("В графе нет простых циклов");
                return;
            }
            else if (length > NumNodes)
            {
                Console.WriteLine("В графе из {0} вершин не может быть простого цикла длины {1}", NumNodes, length);
                return;
            }
            else if (length < 2)
            {
                Console.WriteLine("Минимальная длина цикла - 2");
                return;
            }
            for (int i = 0; i < NumNodes; ++i)
            {
                List<int> curCycle = Dfs(i, new List<int>(), length);
                if (curCycle != null)
                {
                    Console.WriteLine("Цикл длины {0} в графе:", length);
                    foreach (var cur in curCycle)
                        Console.Write("{0} ", cur);
                    Console.WriteLine();
                    return;
                }
            }
            Console.WriteLine("Цикл длины {0} в графе не найден:", length);
        }
    }
}
