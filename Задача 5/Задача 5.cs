using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] spiral = new int[,] {    { 1, 2, 3, 4, 5, 6, 7 },
                                            { 24, 25, 26, 27, 28, 29, 8 }, 
                                            { 23, 40, 41, 42, 43, 30, 9 }, 
                                            { 22, 39, 48, 49, 44, 31, 10 }, 
                                            { 21, 38, 47, 46, 45, 32, 11 }, 
                                            { 20, 37, 36, 35, 34, 33, 12 }, 
                                            { 19, 18, 17, 16, 15, 14, 13 } };

            double[,] arr = new double[7,7];
            double[] ans = new double[49];

            for (int i=0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    bool ok = false;
                    while (!ok)
                    {
                        Console.WriteLine("Введите число в {0} строке и {1} столбце", i + 1, j + 1);
                        try
                        {
                            arr[i,j] = Convert.ToDouble(Console.ReadLine());
                            ok = true;
                        }
                        catch { Console.WriteLine("Ошибка ввода"); }
                    }
                }
            }

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    ans[spiral[i, j] - 1] = arr[i, j];
                }
            }

            for (int i = 0; i < ans.Length; i++) Console.WriteLine((i + 1) + " элемент спирали: " + ans[i]);
            Console.ReadKey();
        }
    }
}
