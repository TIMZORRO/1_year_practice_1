using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_3
{
    class Program
    {
        public static double Function(double x)
        {
            if (x < 0) return Math.Abs(x + 1);
            else return Math.Abs(x - 1);
        }
        static void Main(string[] args)
        {
            double a = 0;
            bool ok = false;
            while (!ok)
            {
                Console.WriteLine("Введите число, для которого необходимо вычислить функцию");
                try
                {
                    a = Convert.ToDouble(Console.ReadLine());
                    ok = true;
                }
                catch { Console.WriteLine("Ошибка ввода"); }
            }

            Console.WriteLine("\nПолученное значение функции: " + Function(a));
            Console.ReadKey();
        }
    }
}
