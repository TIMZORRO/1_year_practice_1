using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_4
{
    class Program
    {
        public static int EnterNut()
        {
            while (true)
            {
                try
                {
                    int a = Convert.ToInt32(Console.ReadLine());
                    if (a <= 0) throw new Exception();
                    else return a;
                }
                catch { Console.WriteLine("Неверный ввод, повторите"); }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, которое надо разложить");
            int p = EnterNut();
            Console.WriteLine("\nВведите число, на степени которого введенное ранее число нужно разложить");
            int q = EnterNut();
            int N = -1;
            while (p >= Math.Pow(q, ++N)) ;
            int[] arr_of_a = new int[N--];
            for(int i = N; i > 0; i--)
            {
                while (p >= Math.Pow(q, i))
                {
                    p = (int)(p - Math.Pow(q, i));
                    arr_of_a[i]++;
                }
            }
            arr_of_a[0] = p;
            for (int i = 0; i < arr_of_a.Length; i++) Console.WriteLine("A{0}: " + arr_of_a[i], i);
            Console.ReadKey();
        }
    }
}
