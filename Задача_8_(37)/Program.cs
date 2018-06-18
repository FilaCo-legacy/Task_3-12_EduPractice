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
            Graph taskGraph = new Graph(4, 3);
            taskGraph.FindAllCutPoints();
            taskGraph.Show();
        }
    }
}
