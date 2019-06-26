using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_8
{
    class Program
    {
        public static byte[][] ReadFromFile(string file_name)
        {
            int count1 = 0, count2 = 0;
            using (FileStream sf = new FileStream(file_name, FileMode.OpenOrCreate)) { }
            using (StreamReader reader = new StreamReader(file_name))
            {
                while (reader.Peek() != -1)
                {
                    count1++;
                    string str = Regex.Replace(reader.ReadLine().Trim(), @"\s+", " ");
                    if (str != "")
                    {
                        if (count2 == 0)
                        {
                            string[] chisla = str.Split(new char[] { ' ' });
                            count2 = chisla.Length;
                        }
                    }
                    else count1--;
                }
            }

            byte[][] arr = new byte[count1][];
            using (StreamReader reader = new StreamReader(file_name))
            {
                try
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        arr[i] = new byte[count2];
                        string str = Regex.Replace(reader.ReadLine().Trim(), @"\s+", " ");
                        if (str != "")
                        {
                            string[] chisla = str.Split(new char[] { ' ' });
                            if (chisla.Length != count2) throw new Exception();
                            for (int j = 0; j < arr[i].Length; j++)
                            {
                                arr[i][ j] = Convert.ToByte(chisla[j]);
                                if (arr[i][j] > 1) throw new Exception();
                            }
                        }
                        else i--;
                    }

                    for (int i = 0; i < arr[0].Length; i++)
                    {
                        int count = 0;
                        for (int j = 0; j < arr.Length; j++) count += arr[j][i];
                        if (count != 2) throw new Exception();
                    }
                }
                catch { Console.WriteLine($"Ошибка чтения из файла. Проверьте файл для ввода: в нем должна быть матрица из единиц и нулей\nГде строки - это вершины графа, а столбцы - ребра графа"); }
            }
            return arr;
        }

        public static PointEntry ToPoint(byte[][] arr)
        {
            Dictionary<int, PointEntry> dict = new Dictionary<int, PointEntry>();
            for (int i = 0; i < arr.Length; i++)
            {
                dict.Add(i, new PointEntry());
                dict[i].Near = new List<PointEntry>();
                dict[i].Number = i;
            }
            for (int i = 0; i < arr[0].Length; i++)
            {
                int[] ver = new int[2];
                byte count = 0;
                for (int j = 0; j < arr.Length; j++)
                    if (arr[j][i] == 1)
                        ver[count++] = j;

                dict[ver[0]].Near.Add(dict[ver[1]]);
                dict[ver[1]].Near.Add(dict[ver[0]]);
            }
            
            return dict[0];
        }

        public static bool EulerParse(byte[][] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int count = (from chisl in arr[i] where chisl == 1 select chisl).Count();
                if (count % 2 == 1) return false;
            }
            return true;
        }

        public static bool EulerWay(List<int> ways, PointEntry point, byte[][] matr)
        {
            foreach (PointEntry next in point.Near)
            {
                for (int i = 0; i < matr[0].Length; i++)
                    if (matr[point.Number][i] == 1 && matr[next.Number][i] == 1 && !ways.Contains(i))
                    {
                        List<int> help = new List<int>(ways);
                        help.Add(i);

                        if (EulerWay(help, next, matr))
                        {
                            Console.Write($"{point.Number + 1} => ");
                            return true;
                        }
                    }
            }

            if (ways.Count == matr[0].Length)
            {
                Console.Write($"\n{point.Number + 1} => ");
                return true;
            }
            else return false;
        }

        static void Main(string[] args)
        {
            string input_f = "input.txt";
            byte[][] matr = ReadFromFile(input_f);
            if (matr.Length != 0)
            {
                if (EulerParse(matr))
                {
                    PointEntry first = ToPoint(matr);
                    List<int> ways = new List<int>();
                    EulerWay(ways, first, matr);
                    Console.WriteLine("END");
                }
                else Console.WriteLine("Введенный граф не является Эйлеровым");
            }
            else Console.WriteLine("Граф не введен. Перезапустите программу, введя граф в файле или использовав ручной ввод");

            Console.ReadKey();
        }
    }
}
