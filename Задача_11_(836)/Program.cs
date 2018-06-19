using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_11__836_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, которую Вы хотите зашифровать:");
            SnakeCipher taskCipher = new SnakeCipher(Console.ReadLine());
            Console.WriteLine(@"Зашифрованное сообщение: {0}
Дешифрованное сообщение: {1}", taskCipher, taskCipher.Decrypt());
            Console.WriteLine();
            taskCipher.ShowInfo();
        }
    }
}
