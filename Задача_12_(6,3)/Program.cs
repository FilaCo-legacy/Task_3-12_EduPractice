using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Задача_12__6_3_
{
    class Program
    {
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
        static void Swap(ref int a, ref int b)
        {
            var tmp = a;
            a = b;
            b = tmp;
        }
        static void InsertionSort(int[] array, out int timesCompare, out int timesSwap)
        {
            timesCompare = timesSwap = 0;
            for (var i = 1; i < array.Length; ++i)
            {
                var curPos = i;
                while (curPos > 0)
                {
                    ++timesCompare;
                    if (array[curPos] < array[curPos - 1])
                    {
                        Swap(ref array[curPos], ref array[curPos - 1]);
                        timesSwap += 2;
                        curPos--;
                    }
                    else
                        break;
                }
            }
        }
        static void CountingSort(int[] array, out int timesCompare, out int timesSwap)
        {
            timesCompare = timesSwap = 0;
            int[] subArr = new int[array.Max() + 1];
            for (var i = 0; i < array.Length; ++i)
                subArr[array[i]]++;
            for (int i = 0, j = 0; i < array.Length; ++i)
            {
                while (subArr[j] == 0)
                {
                    timesCompare++;
                    j++;
                }
                timesSwap++;
                array[i] = j;
                subArr[j]--;
            }
        }
        static void GenerateArrays(int[] nonSort, int []sortedInc, int [] sortedDec, int size)
        {
            Random rnd = new Random();
            for (var i = 0; i < size; ++i)
            {
                nonSort[i] = rnd.Next(0, 1000);
                Thread.Sleep(15);
                sortedInc[i] = rnd.Next(0, 1000);
                Thread.Sleep(15);
                sortedDec[i] = rnd.Next(0, 1000);
                Thread.Sleep(15);
            }
            Array.Sort(sortedInc);
            Array.Sort(sortedDec, new DecreaseSort());
        }
        static void OutputArr(int[] arr)
        {
            foreach (var cur in arr)
                Console.Write("{0} ", cur);
            Console.WriteLine();
        }
        static void OutputArrays(int[] nonSort, int[] sortedInc, int[] sortedDec)
        {
            Console.WriteLine("Массив №1 (неупорядоченный):");
            OutputArr(nonSort);
            Console.WriteLine("Массив №2 (упорядоченный по возрастанию):");
            OutputArr(sortedInc);
            Console.WriteLine("Массив №3 (упорядоченный по убыванию):");
            OutputArr(sortedDec);
        }        
        static void CompareInsertionSort(int[] nonSort, int[] sortedInc, int[] sortedDec)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nСОРТИРОВКА ВСТАВКАМИ:\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            int timeCmp, timeSwp = 0;
            Console.WriteLine("Массив №1 (неупорядоченный):");
            OutputArr(nonSort);
            InsertionSort(nonSort, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(nonSort);
            Console.WriteLine(new string('-', nonSort.Length*6));
            timeCmp = timeSwp = 0;
            Console.WriteLine("Массив №2 (упорядоченный по возрастанию):");
            OutputArr(sortedInc);
            InsertionSort(sortedInc, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(sortedInc);
            Console.WriteLine(new string('-', nonSort.Length*6));
            timeCmp = timeSwp = 0;
            Console.WriteLine("Массив №3 (упорядоченный по убыванию):");
            OutputArr(sortedDec);
            InsertionSort(sortedDec, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(sortedDec);
            Console.WriteLine(new string('-', nonSort.Length*6));
            Console.WriteLine(new string('-', nonSort.Length*6));
        }
        static void CompareCountingSort(int[] nonSort, int[] sortedInc, int[] sortedDec)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nСОРТИРОВКА ПОДСЧЁТОМ:\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            int timeCmp, timeSwp = 0;
            Console.WriteLine("Массив №1 (неупорядоченный):");
            OutputArr(nonSort);
            CountingSort(nonSort, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(nonSort);
            Console.WriteLine(new string('-', nonSort.Length * 6));
            timeCmp = timeSwp = 0;
            Console.WriteLine("Массив №2 (упорядоченный по возрастанию):");
            OutputArr(sortedInc);
            CountingSort(sortedInc, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(sortedInc);
            Console.WriteLine(new string('-', nonSort.Length * 6));
            timeCmp = timeSwp = 0;
            Console.WriteLine("Массив №3 (упорядоченный по убыванию):");
            OutputArr(sortedDec);
            CountingSort(sortedDec, out timeCmp, out timeSwp);
            Console.WriteLine("Результаты сортировки:\nКоличество сравнений: {0}; " +
                "количество перемещений: {1}", timeCmp, timeSwp);
            Console.Write("Элементы массива: ");
            OutputArr(sortedDec);
            Console.WriteLine(new string('-', nonSort.Length * 6));
            Console.WriteLine(new string('-', nonSort.Length * 6));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массивов для тестирования:");
            int size = ReadNaturalNum();
            int[] nonSort = new int[size], sortedInc = new int[size], sortedDec = new int[size];
            GenerateArrays(nonSort, sortedInc, sortedDec, size);
            Console.WriteLine("Исходные массивы:");
            OutputArrays(nonSort, sortedInc, sortedDec);
            Console.WriteLine("Для продолжения работы нажмите Enter...");
            Console.ReadLine();
            Console.Clear();
            CompareInsertionSort((int[])nonSort.Clone(), (int[])sortedInc.Clone(), (int[])sortedDec.Clone());
            CompareCountingSort((int[])nonSort.Clone(), (int[])sortedInc.Clone(), (int[])sortedDec.Clone());
        }
    }
}
