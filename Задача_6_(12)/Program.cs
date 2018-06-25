using System;

namespace Задача_6__12_
{
    class Program
    {
        /// <summary>
        /// Массив, хранящий первые 2N элементов последовательности
        /// </summary>
        static double[] arr;
        /// <summary>
        /// Ввод действительного числа
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Ввод натурального числа
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Сравнение двух действительных чисел
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a2"></param>
        /// <returns></returns>
        static int Compare(double a1, double a2)
        {
            if (a1 < a2)
                return 1;
            if (a1 > a2)
                return -1;
            return 0;
        }
        /// <summary>
        /// Заполнение массива arr элементами
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static double Elem(int num)
        {
            if (num < 3)
                return arr[num];
            arr[num] = 0.7 * Elem(num - 1) - 0.2 * Elem(num - 2) + num * Elem(num - 3);
            return arr[num];
        }
        /// <summary>
        /// Проверка последовательности первых N элементов стоящих на нечётных местах на монотонность
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        static bool CheckSequence(int N)
        {
            int cmp = Compare(arr[0], arr[2]);
            for (int i = 3; i < 2 * N-1; i+=2)
            {
                if (cmp == 0 && Compare(arr[i - 2], arr[i]) != 0)
                    cmp = Compare(arr[i - 2], arr[i]);
                else if (Math.Abs(cmp - Compare(arr[i - 2], arr[i])) > 1)
                    return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число N:");
            int N = InputNaturalNumber();
            arr = new double[Math.Max(3,2 * N-1)];
            Console.WriteLine("Введите первые три элемента последовательности:");
            for (int i = 0; i < 3; ++i)
                arr[i] = InputNumber();
            Elem(2 * N-2);
            if (CheckSequence(N))
                Console.WriteLine("Подпоследовательность первых N элементов на " +
                "нечётных местах монотонна");
            else
                Console.WriteLine("Подпоследовательность первых N элементов на " +
                "нечётных местах не монотонна");
            Console.WriteLine("\nСама последовательность:");
            foreach (var x in arr)
                Console.Write("{0:F4} ", x);
        }
    }
}
