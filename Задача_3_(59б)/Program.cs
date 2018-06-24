using System;

namespace Задача_3__59б_
{
    class Program
    {
        /// <summary>
        /// Ввод действительного числа с клавиатуры
        /// </summary>
        /// <returns>Значение числа, введённого с клавиатуры</returns>
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
        /// Вывод примерного относительного расположения зоны и точки
        /// </summary>
        /// <param name="x">Абсцисса точки</param>
        /// <param name="y">Ордината точки</param>
        static void OutputZone(double x, double y)
        {
            // Преображение координат точки к целым числам
            x = Math.Round(x, 1)*10;
            y = Math.Round(y, 1)*10;
            // Максимальные значения x и y в зависимости от входной точки (минимум 1.5)
            int maxX = (int)Math.Max(15,Math.Max(Math.Abs(x),Math.Abs(y))), maxY = maxX;
            // Построчный вывод зоны
            for (int i = maxY; i >= -maxY; i--)
            {
                for (int j = -maxX; j <= maxX; j++)
                {
                    // Координата принадлежащая точке
                    if (i == y && j == x)
                        Console.Write("T");
                    // Координата принадлежащая зоне
                    else if (j * j + i * i >= 25 && j * j + i * i <= 100)
                        Console.Write("*");
                    // Начало координат
                    else if (i == 0 && j == 0)
                        Console.Write("+");
                    // Конец оси OY
                    else if (j == 0 && i == maxY)
                        Console.Write("^");
                    // Конец оси OX
                    else if (i == 0 && j == maxX)
                        Console.Write(">");
                    // Ось OX
                    else if (i == 0)
                        Console.Write("-");
                    // Ось OY
                    else if (j == 0)
                        Console.Write("|");
                    // Пустое пространство
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
                Console.WriteLine("Точка с координатами x = {0} и y = {1} принадлежит зоне", x, y);
            else
                Console.WriteLine("Точка с координатами x = {0} и y = {1} не принадлежит зоне", x, y);
            OutputZone(x,y);
        }
    }
}
