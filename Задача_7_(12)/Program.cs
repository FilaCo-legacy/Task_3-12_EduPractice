using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Задача_7__12_
{
    class Program
    {
        static string InputVector(int size, Regex reg)
        {
            string inpVec;
            do
            {
                inpVec = Console.ReadLine();
                if (!reg.IsMatch(inpVec))
                    Console.WriteLine("Вектор введён некорректно, попробуйте ещё раз\nРазмер должен быть {0}\n" +
    "Используемые символы: \"0\", \"1\", \"*\"", Math.Pow(2, size));
                else
                    break;

            } while (true);
            return inpVec;
        }
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
            Console.WriteLine("Введите кол-во переменных в функции:");
            int size = ReadNaturalNum();
            Regex reg = new Regex(@"^\s*[01*]{" + Math.Pow(2,size).ToString() + @"}\s*$");
            string func = InputVector(size, reg);
        }
    }
}
