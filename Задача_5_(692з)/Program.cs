using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_5__692з_
{
    class Program
    {
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
        static double[,] InitMatrix(int n)
        {
            Random rnd = new Random();
            double[,] matr = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = rnd.Next(0, 100) * rnd.NextDouble();
            return matr;
        }
        static double MaxElem(ref double[,] matr)
        {
            double maxElem = matr[matr.GetLength(0) - 1, matr.GetLength(1)-1];
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (i <= j && j >= matr.GetLength(1) - 1 - i && matr[i, j] > maxElem)
                        maxElem = matr[i, j];
            return maxElem;
        }
        static void OutputMatr(ref double[,] matr, double maxElem)
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
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int size;
            Console.WriteLine("Введите порядок матрицы");
            size = InputNaturalNumber();
            double[,] matr = InitMatrix(size);
            double maxElem = MaxElem(ref matr);
            Console.WriteLine("Наибольшее значение в заданной зоне матрицы: {0:F3}", maxElem);
            Console.WriteLine("Матрица с выделенной зоной:");
            OutputMatr(ref matr, maxElem);
        }
    }
}
