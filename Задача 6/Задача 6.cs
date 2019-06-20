using System;

namespace Задача_6
{
    class Program
    {
        public static int Recur (double a1, double a2, double a3, double M, int N)
        {
            double a_next = a3 / 2 + a2 / 2 + a1 / 2;

            if (a_next <= M)
            {
                Console.Write(a_next + " ");
                N++;
                if (a_next == M)
                {
                    Console.WriteLine("\nВыполняется ли равенство aN = M? Ответ: True");
                    return N;
                }
                return Recur(a2, a3, a_next, M, N);
            }
            Console.WriteLine("\nВыполняется ли равенство aN = M? Ответ: False");
            return N;
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

            if (a1 == 0 && a2 == 0 && a3 == 0)
                Console.WriteLine("Полученная последовательность является бесконечной последовательностью из нулей");

            else if (a1 > M)
                Console.WriteLine("Полученная последовательность пуста, так как первый член введенной последовательности больше M");

            else if (a2 > M)
                Console.WriteLine($"Полученная последовательность: {a1}\nВыполняется ли равенство aN = M? Ответ: {a1 == M}\nДлина полученной последовательности: 1");

            else if (a3 > M)
                Console.WriteLine($"Полученная последовательность: {a1} {a2}\nВыполняется ли равенство aN = M? Ответ: {a2 == M}\nДлина полученной последовательности: 2");

            else
            {
                Console.WriteLine("Полученная последовательность: ");
                Console.Write(a1 + " " + a2 + " " + a3 + " ");
                int count = 3;
                count = Recur(a1, a2, a3, M, count);
                Console.WriteLine("\nДлина полученной последовательности: " + count);
            }

            Console.ReadKey();
        }
    }
}
