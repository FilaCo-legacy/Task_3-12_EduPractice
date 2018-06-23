using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задача_8__37_
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph taskGraph = new Graph(new int[,] { { 0, 1, 0 }, { 0, 0, 1 }, { 1, 0, 0 } });
            taskGraph.Show();
            taskGraph.FindCycle(3);
        }
    }
}
