using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_6
{
    class Program
    {
        public static int count = 0;
        public static double Recur (double a1, double a2, double a3, double M)
        {
            double a_next = a3 / 2 + a2 / 2 + a1 / 2;

            if (a_next <= M)
            {
                Console.Write(a_next + " ");
                count++;
                return Recur(a2, a3, a_next, M);
            }
            else return a3;
        }
        public static double EnterDouble()
        {
            while (true)
            {
                try
                {
                    return Convert.ToDouble(Console.ReadLine());
                }
                catch { Console.WriteLine("Неверный ввод, повторите"); }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первый член последовательности: ");
            double a1 = EnterDouble();
            Console.WriteLine("Введите второй член последовательности: ");
            double a2 = EnterDouble();
            Console.WriteLine("Введите третий член последовательности: ");
            double a3 = EnterDouble();
            Console.WriteLine("Введите число M: ");
            double M = EnterDouble();

            Console.WriteLine("Полученная последовательность: ");
            Console.Write(a1 + " " + a2 + " " + a3 + " ");
            count = 3;
            double a_n = Recur(a1, a2, a3, M);
            Console.WriteLine("\nЕе длина: " + count);
            Console.WriteLine("Выполняется ли равенство aN = M? Ответ: " + (a_n == M));
            Console.ReadKey();
        }
    }
}
