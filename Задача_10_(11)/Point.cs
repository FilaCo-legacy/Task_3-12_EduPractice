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
            int num = 1;
            if (Next != null)
                num += Next.CountElems();
            return num;
        }
        private bool isNonDecreasing()
        {
            Point cur = this;
            while (cur.Next != null)
            {
                if (cur.Data > cur.Next.Data)
                    return false;
                cur = cur.Next;
            }
            return true;
        }
        private static void SwapData(ref Point a, ref Point b)
        {
            double tmp = a.Data;
            a.Data = b.Data;
            b.Data = tmp;
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
            if (Next == null)
                Console.WriteLine();
        }
        public void NeedToReshuffle()
        {
            if (isNonDecreasing())
            {
                Console.WriteLine("Последовательность отсортирована по неубыванию - её не нужно переставлять");
                return;
            }
            int size = Count;
            for (var i = 0; i < size-1; ++i)
            {
                Point cur = this;
                for (int j = 0; j < size - i-1; ++j)
                { 
                    Point nextElem = cur.Next;
                    SwapData(ref cur, ref nextElem);
                    cur = cur.Next;
                }
            }
            Console.WriteLine("Последовательность не была отсортирована по неубыванию, поэтому порядок изменён:");
            Show();
        }
    }
}
