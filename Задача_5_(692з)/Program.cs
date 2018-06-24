using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_5__692з_
{
    class Program
    {
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
        /// Инициализаци матрицы и заполнение её действительными числами
        /// </summary>
        /// <param name="n">Размер матрицы</param>
        /// <returns></returns>
        static double[,] InitMatrix(int n)
        {
            Random rnd = new Random();
            double[,] matr = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = rnd.Next(-100, 101) * rnd.NextDouble();
            return matr;
        }
        /// <summary>
        /// Поиск максимального элемента в матрице
        /// </summary>
        /// <param name="matr"></param>
        /// <returns></returns>
        static double MaxElem(double[,] matr)
        {
            double maxElem = matr[matr.GetLength(0) - 1, matr.GetLength(1)-1];
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (i <= j && j >= matr.GetLength(1) - 1 - i && matr[i, j] > maxElem)
                        maxElem = matr[i, j];
            return maxElem;
        }
        /// <summary>
        /// Вывод матрицы с подсвеченным максимальным элементом и зоной поиска
        /// </summary>
        /// <param name="matr"></param>
        /// <param name="maxElem"></param>
        static void OutputMatr(double[,] matr, double maxElem)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (i <= j && j >= matr.GetLength(1) - 1 - i && matr[i, j] == maxElem)
                        Console.ForegroundColor = ConsoleColor.Red;
                    else if (i <= j && j >= matr.GetLength(1) - 1 - i)
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0:F3}\t", matr[i, j]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Введите размер квадратной матрицы");
            size = InputNaturalNumber();
            double[,] matr = InitMatrix(size);
            double maxElem = MaxElem(matr);
            Console.WriteLine("Наибольшее значение в заданной зоне матрицы: {0:F3}", maxElem);
            Console.WriteLine("Матрица с выделенной зоной:");
            OutputMatr(matr, maxElem);
        }
    }
}
