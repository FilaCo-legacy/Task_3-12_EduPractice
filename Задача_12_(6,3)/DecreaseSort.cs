using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_12__6_3_
{
    class DecreaseSort : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x > y)
                return -1;
            else if (x < y)
                return 1;
            return 0;
        }
    }
}
