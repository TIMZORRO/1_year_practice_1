using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string input_f = "input.txt";
            bool running = true;
            string posl = null;
            int[,] matr = new int[10, 10];
            while (running)
            {
                Console.WriteLine("Введите строку из 100 букв");
                posl = Console.ReadLine();
                if (posl.Length != 100) Console.WriteLine("Длина строки не равна 100, введите еще раз");
                else running = false;
            }
            
            running = true;
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
                                for (int i = 0; i < matr.GetLength(0); i++)
                                {
                                    string str = reader.ReadLine();
                                    str = Regex.Replace(str.Trim(), @"\s+", " ");
                                    string[] chisla = str.Split(new char[] { ' ' });
                                    for (int j = 0; j < matr.GetLength(1); j++)
                                        if (Convert.ToInt32(chisla[j]) != 0 && Convert.ToInt32(chisla[j]) != 1) throw new Exception();
                                        else matr[i, j] = Convert.ToInt32(chisla[j]);
                                }
                                for (int i = 0; i < matr.GetLength(0); i++)
                                    for (int j = 0; j < matr.GetLength(1); j++)
                                        if ((matr[i, j] + matr[j, 9 - i] + matr[9 - i, 9 - j] + matr[9 - j, i]) != 3) throw new Exception();
                                    running = false;
                            }
                            catch { Console.WriteLine("Ошибка чтения из файла. Проверьте файл для ввода: в нем должна быть матрица 10х10 из единиц и нулей"); }
                        }
                        break;

                    case "2": // ручной ввод
                        for (int i = 0; i < matr.GetLength(0); i++)
                        {
                            bool prov2 = false;
                            while (!prov2)
                            {
                                Console.WriteLine("\nВведите {0} строку", i + 1);
                                string str = Console.ReadLine();
                                str = Regex.Replace(str.Trim(), @"\s+", " ");
                                string[] chisla = str.Split(new char[] { ' ' });
                                try
                                {
                                    for (int j = 0; j < matr.GetLength(1); j++)
                                        if (Convert.ToInt32(chisla[j]) != 0 && Convert.ToInt32(chisla[j]) != 1) throw new Exception();
                                        else matr[i, j] = Convert.ToInt32(chisla[j]);
                                    prov2 = true;
                                }
                                catch { Console.WriteLine("Ошибка ввода. Матрица должна содержать только единицы и нули"); prov2 = false; }
                            }
                        }
                        try
                        {
                            for (int i = 0; i < matr.GetLength(0); i++)
                            {
                                for (int j = 0; j < matr.GetLength(1); j++)
                                    if ((matr[i, j] + matr[i, 9 - j] + matr[9 - i, j] + matr[9 - i, 9 - j]) != 3) throw new Exception();
                            }
                            running = false;
                        }
                        catch { Console.WriteLine("Ошибка ввода. Данная матрица не отвечает требованиям шифрования, введите заново"); }
                        break;
                }
            }

            // индексы нулей
            int[,] indexes = new int[25, 2];
            int count = -1;
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    if (matr[i, j] == 0)
                    {
                        indexes[++count, 0] = i;
                        indexes[count, 1] = j;
                    }
            // шифровка
            char[,] help = new char[10, 10];
            for (int i=0; i < posl.Length; i++)
            {
                if (i / 25 == 0)
                    help[indexes[i % 25, 0], indexes[i % 25, 1]] = posl[i];
                else if (i / 25 == 1)
                    help[indexes[i % 25, 1], 9 - indexes[i % 25, 0]] = posl[i];
                else if (i / 25 == 2)
                    help[9 - indexes[i % 25, 0], 9 - indexes[i % 25, 1]] = posl[i];
                else if (i / 25 == 3)
                    help[9 - indexes[i % 25, 1], indexes[i % 25, 0]] = posl[i];
            }

            string shifr = "";
            for (int i = 0; i < help.GetLength(0); i++)
                for (int j = 0; j < help.GetLength(1); j++)
                    shifr += help[i, j];

            Console.WriteLine("Зашифрованная строка:\n" + shifr);
            Console.ReadKey();

            // расшифровка
            help = new char[10, 10];
            for (int i = 0; i < posl.Length; i++) help[i / 10, i % 10] = posl[i];
            string unshifr = "";
            for (int i = 0; i < posl.Length; i++)
            {
                if (i / 25 == 0)
                    unshifr += help[indexes[i % 25, 0], indexes[i % 25, 1]];
                else if (i / 25 == 1)
                    unshifr += help[indexes[i % 25, 1], 9 - indexes[i % 25, 0]];
                else if (i / 25 == 2)
                    unshifr += help[9 - indexes[i % 25, 0], 9 - indexes[i % 25, 1]];
                else if (i / 25 == 3)
                    unshifr += help[9 - indexes[i % 25, 1], indexes[i % 25, 0]];
            }
            Console.WriteLine("\nРасшифрованная строка:\n" + unshifr);
            Console.ReadKey();
        }
    }
}
