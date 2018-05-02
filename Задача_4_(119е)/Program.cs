using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_4__119е_
{
    class Program
    {
        static double InputNumber()
        {
            double inpNum;
            bool check = false;
            do
            {
                check = Double.TryParse(Console.ReadLine(), out inpNum);
                if (!check)
                    Console.WriteLine("Некорректный ввод. Необходимо ввести действительное число");
            } while (!check);
            return inpNum;
        }
        static double CountSum(ref double accuracy, int iter)
        {
            double curElem = 1 / (Math.Pow(4, iter) + Math.Pow(5, iter + 2));
            if (Math.Abs(curElem) < accuracy)
                return curElem;
            else
                return curElem + CountSum(ref accuracy, iter + 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте точность вычислений:");
            double eps = InputNumber();
            double sum = CountSum(ref eps, 1);
            Console.WriteLine("Точность: {0}\nСумма:{1}", eps,sum);
        }
    }
}
