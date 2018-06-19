using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_9__33_
{
    class Program
    {
        static Random rnd = new Random();
        static int ReadNum()
        {
            int inpNum;
            while (true)
            {
                try
                {
                    inpNum = Convert.ToInt32(Console.ReadLine());
                    return inpNum;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Внимание: {0} Попробуйте ещё раз", e.Message);
                }
            }
        }
        static int ReadNaturalNum()
        {
            int inpNum = 0;
            while (inpNum < 1)
            {
                inpNum = ReadNum();
                if (inpNum < 1)
                    Console.WriteLine("Необходимо ввести натуральное число");
            }
            return inpNum;
        }
        static BinPoint<int> GenerateIntBinPoint(int size)
        {
            BinPoint<int> cur = new BinPoint<int>(rnd.Next(-15, 16));
            for (var i = 0; i < size-1; ++i)
            {
                switch(rnd.Next(0, 2))
                {
                    case 0:
                        cur.AddNext(rnd.Next(-15, 16));
                        break;
                    case 1:
                        cur.AddPref(rnd.Next(-15, 16));
                        break;
                }
            }
            return cur;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер создаваемого списка");
            int size = ReadNaturalNum();
            BinPoint<int> taskList = GenerateIntBinPoint(size);
            taskList.Show();
            Console.WriteLine(@"
Количество элементов в двунаправленном списке:
Вычислено рекурсивно: {0}
Вычислено нерекурсивно: {1}",taskList.CountElems_Recur(), taskList.CountElems_NonRecur());
        }
    }
}
