using System;
using System.IO;
using System.Text.RegularExpressions;
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
            string input_f = "input.txt";
            int[,] spiral = new int[,] {    { 1, 2, 3, 4, 5, 6, 7 },
                                            { 24, 25, 26, 27, 28, 29, 8 },
                                            { 23, 40, 41, 42, 43, 30, 9 },
                                            { 22, 39, 48, 49, 44, 31, 10 },
                                            { 21, 38, 47, 46, 45, 32, 11 },
                                            { 20, 37, 36, 35, 34, 33, 12 },
                                            { 19, 18, 17, 16, 15, 14, 13 } };

            double[,] arr = new double[7, 7];
            double[] ans = new double[49];

            bool running = true;
            while (running)
            {
                Console.WriteLine("Выберите способ ввода: ");
                Console.WriteLine("1 - ввод матрицы из файла");
                Console.WriteLine("2 - ручной ввод");

                switch (Console.ReadLine())
                {
                    case "1": // ввод из файла
                        using (FileStream sf = new FileStream(input_f, FileMode.OpenOrCreate)) { }
                        using (StreamReader reader = new StreamReader(input_f))
                        {
                            try
                            {
                                for (int i = 0; i < spiral.GetLength(0); i++)
                                {
                                    string str = reader.ReadLine();
                                    str = Regex.Replace(str.Trim(), @"\s+", " ");
                                    string[] chisla = str.Split(new char[] { ' ' });
                                    for (int j = 0; j < spiral.GetLength(1); j++) arr[i, j] = Convert.ToDouble(chisla[j]);
                                }
                                running = false;
                            }
                            catch { Console.WriteLine("Ошибка чтения из файла. Проверьте файл для ввода: в нем должна быть матрица 7х7 из действительных чисел"); }
                        }
                        break;

                    case "2": // ручной ввод
                        for (int i = 0; i < arr.GetLength(0); i++)
                        {
                            for (int j = 0; j < arr.GetLength(1); j++)
                            {
                                bool ok = false;
                                while (!ok)
                                {
                                    Console.WriteLine("Введите число в {0} строке и {1} столбце", i + 1, j + 1);
                                    try
                                    {
                                        arr[i, j] = Convert.ToDouble(Console.ReadLine());
                                        ok = true;
                                    }
                                    catch { Console.WriteLine("Ошибка ввода"); }
                                }
                            }
                        }
                        running = false;
                        break;
                }
            }
            Console.WriteLine("Полученная матрица: ");
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < arr.GetLength(0); i++) // создание массива раскрученной спирали
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
