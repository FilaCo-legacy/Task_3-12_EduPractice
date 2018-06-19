using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_10__11_
{
    class Point
    {
        private static Random rnd = new Random();
        private double Data { get; set; }
        private Point Next { get; set; }
        private int CountElems()
        {
            int num = 0;
            if (Next != null)
                num += Next.CountElems();
            return num;
        }
        public int Count { get { return CountElems(); } }
        public Point(double value)
        {
            Data = value;
            Next = null;
        }
        public Point(int size)
        {
            Data = rnd.Next(-15, 16) * rnd.NextDouble();
            for (int i = 0; i < size - 1; ++i)
                Add(rnd.Next(-15, 16) * rnd.NextDouble());
        }
        public void Add(double value)
        {
            Point cur = this;
            Point nElem = new Point(value);
            while (cur.Next != null)
                cur = cur.Next;
            cur.Next = nElem;
        }
        public void Show()
        {
            Console.Write("{0:F3} ", Data);
            if (Next != null)
                Next.Show();
        }
    }
}
