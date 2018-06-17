using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_3__59б_
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
        static void OutputZone(double x, double y)
        {
            x = Math.Round(x, 1)*10;
            y = Math.Round(y, 1)*10;
            int maxX = (int)Math.Max(15,Math.Max(x,y)), maxY = maxX;
            for (int i = maxY; i >= -maxY; i--)
            {
                for (int j = -maxX; j <= maxX; j++)
                {
                    if (i == y && j == x)
                        Console.Write("T");
                    else if (j * j + i * i >= 25 && j * j + i * i <= 100)
                        Console.Write("*");
                    else if (i == 0 && j == 0)
                        Console.Write("+");
                    else if (j == 0 && i == maxY)
                        Console.Write("^");
                    else if (i == 0 && j == maxX)
                        Console.Write(">");
                    else if (i == 0)
                        Console.Write("-");
                    else if (j == 0)
                        Console.Write("|");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            double x, y;
            Console.WriteLine("Введите действительное число x");
            x = InputNumber();
            Console.WriteLine("Введите действительное число y");
            y = InputNumber();
            if (x * x + y * y >= 0.25 && x * x + y * y <= 1)
                Console.WriteLine("Точка с координатами x и y принадлежит зоне");
            else
                Console.WriteLine("Точка с координатами x и y не принадлежит зоне");
            OutputZone(x,y);
        }
    }
}
