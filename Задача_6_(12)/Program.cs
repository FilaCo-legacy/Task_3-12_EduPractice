using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_6__12_
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
        static int InputNaturalNumber()
        {
            int inpNum;
            bool check = false;
            do
            {
                check = Int32.TryParse(Console.ReadLine(), out inpNum);
                if (!check || inpNum <= 0)
                {
                    Console.WriteLine("Некорректный ввод. Необходимо ввести натуральное число");
                    check = false;
                }
            } while (!check);
            return inpNum;
        }
        static int Compare(double a1, double a2)
        {
            if (a1 < a2)
                return 1;
            if (a1 > a2)
                return -1;
            return 0;
        }
        static bool CheckSequence(double a1, double a2, double a3, int N, out double [] arr)
        {
            arr = new double[2 * N-1];
            arr[0] = a1;
            if (N == 1)
                return true;
            arr[1] = a2;
            arr[2] = a3;
            if (N == 2)
                return true;
            int cmp = Compare(a1, a3);
            bool flag = true;
            for (int i = 3; i < 2*N-1; i++)
            {
                arr[i] = 0.7 * arr[i - 1] - 0.2 * arr[i - 2] + (i + 1) * arr[i - 3];
                if (i % 2 == 0 && Math.Abs(Compare(arr[i - 2], arr[i]) - cmp) == 2)
                    flag = false;
            }
            return flag;
        }
        static void Main(string[] args)
        {
            double a1, a2, a3;
            int N;
            double[] arr;
            Console.WriteLine("Введите первые три элемента последовательности:");
            a1 = InputNumber();
            a2 = InputNumber();
            a3 = InputNumber();
            Console.WriteLine("Введите число N:");
            N = InputNaturalNumber();
            if (CheckSequence(a1, a2, a3, N, out arr))
                Console.WriteLine("Подпоследовательность первых N элементов на " +
                "нечётных местах монотонна");
            else
                Console.WriteLine("Подпоследовательность первых N элементов на " +
                "нечётных местах не монотонна");
            Console.WriteLine("\nСама последовательность:");
            foreach (double x in arr)
                Console.Write("{0} ", x);
        }
    }
}
