using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_4__119е_
{
    class Program
    {
        /// <summary>
        /// Ввод действительного числа
        /// </summary>
        /// <returns></returns>
        static double InputPosNumber()
        {
            double inpNum;
            bool check = false;
            do
            {
                check = Double.TryParse(Console.ReadLine(), out inpNum);
                if (!check || inpNum <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Необходимо ввести действительное число, большее 0");
                    check = false;
                }
            } while (!check);
            return inpNum;
        }
        /// <summary>
        /// Подсчёт суммы с заданной точностью
        /// </summary>
        /// <param name="accuracy">Точность вычислений</param>
        /// <param name="iter">Номер члена ряда</param>
        /// <returns></returns>
        static double CountSum(double accuracy, int iter)
        {
            // Вычисляем значение члена ряда с номером iter
            double curElem = 1 / (Math.Pow(4, iter) + Math.Pow(5, iter + 2));
            // Сравниваем его абсолютное значение с точностью
            if (Math.Abs(curElem) < accuracy)
                return curElem;
            else
                return curElem + CountSum(accuracy, iter + 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте точность вычислений (eps > 0):\nP.S. N-ый член суммы будет меньше, чем eps");
            double eps = InputPosNumber();
            double sum = CountSum(eps, 0);
            Console.WriteLine("Точность: {0}\nСумма:{1}", eps,sum);
        }
    }
}
