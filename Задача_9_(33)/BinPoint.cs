using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_9__33_
{
    class BinPoint<T>
    {
        public T Data { get; set; }
        public BinPoint<T> Pref { get; set; }
        public BinPoint<T> Next { get; set; }
        public BinPoint(T dataValue)
        {
            Data = dataValue;
            Pref = null;
            Next = null;
        }
        public void AddPref(T value)
        {
            BinPoint<T> nElem = new BinPoint<T>(value);
            BinPoint<T> cur = this;
            while (cur.Pref != null)
                cur = cur.Pref;
            cur.Pref = nElem;
            nElem.Next = cur;
        }
        public void AddNext(T value)
        {
            BinPoint<T> nElem = new BinPoint<T>(value);
            BinPoint<T> cur = this;
            while (cur.Next != null)
                cur = cur.Next;
            cur.Next = nElem;
            nElem.Pref = cur;
        }
        public void Show()
        {
            BinPoint<T> prefBranch = Pref;
            Stack<T> prefs = new Stack<T>();
            while (prefBranch != null)
            {
                prefs.Push(prefBranch.Data);
                prefBranch = prefBranch.Pref;
            }
            while (prefs.Count > 0)
                Console.Write("{0} ", prefs.Pop());
            Console.Write("{0} ", Data);
            BinPoint<T> nextBranch = Next;
            Stack<T> nexts = new Stack<T>();
            while (nextBranch != null)
            {
                nexts.Push(nextBranch.Data);
                nextBranch = nextBranch.Next;
            }
            while (nexts.Count > 0)
                Console.Write("{0} ", nexts.Pop());
        }
        public int CountElems_NonRecur()
        {
            BinPoint<T> prefBranch = Pref;
            int num = 1;
            while (prefBranch != null)
            {
                ++num;
                prefBranch = prefBranch.Pref;
            }
            BinPoint<T> nextBranch = Next;
            while (nextBranch != null)
            {
                ++num;
                nextBranch = nextBranch.Next;
            }
            return num;
        }
        public int CountElems_Recur(int dir = 0)
        {
            int num = 1;
            if (Pref != null && dir <= 0)
                num += Pref.CountElems_Recur(-1);
            if (dir >= 0)
            {
                if (Next != null)
                    num += Next.CountElems_Recur(1);
            }
            return num;
        }
    }
}
