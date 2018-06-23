using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задача_8__37_
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
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во тестов, которое вы хотите провести:");
            int num = ReadNaturalNum();
            Console.WriteLine("Кол-во тестов: {0}\nРезультат:", num);
            Console.WriteLine("+------------------------------+");
            for (int i = 0; i < num; ++i)
            {
                Console.WriteLine("Тест №{0}:\n+------------------------------+", i+1);
                Graph curG = new Graph();
                curG.Show();
                int len = rnd.Next(2, curG.NumNodes + 1);
                Console.WriteLine("Поиск цикла длины {0}:", len);
                curG.FindCycle(len);
                Console.WriteLine("+------------------------------+");
            }
        }
    }
}
