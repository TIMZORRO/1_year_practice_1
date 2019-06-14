using System;
using System.Collections.Generic;
using System.IO;

namespace Задача_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = new List<string>();
            string input_f = "input.txt", output_f = "output.txt";
            using (FileStream sf = new FileStream(input_f, FileMode.OpenOrCreate)) { }

            using (StreamReader reader = new StreamReader(input_f))
            {
                if (reader.Peek() == -1)
                {
                    Console.WriteLine("Файл пуст");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine("INPUT.TXT\n");
                string str = "";
                int count = 0;
                try
                {
                    count = Convert.ToInt32(reader.ReadLine());
                }
                catch
                {
                    Console.WriteLine("\n\nФайл заполнен неверно. В первой строке должно быть количество записей о предметах");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                Console.WriteLine(str);
                for (int k = 0; k < count; k++)
                {
                    str = reader.ReadLine().Trim().ToLower().Split(new char[] { ' ' })[0];
                    Console.WriteLine(str);
                    bool no_found = true;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        if (arr[i] == str || arr[i].Length > str.Length && arr[i].Remove(str.Length) == str)
                        {
                            no_found = false;
                            break;
                        }
                        else if (arr[i].Length < str.Length && str.Remove(arr[i].Length) == arr[i])
                        {
                            no_found = false;
                            arr[i] = str;
                            break;
                        }
                    }

                    if (no_found) arr.Add(str);
                }
            }

            using (FileStream sf = new FileStream(output_f, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(output_f))
            {
                writer.Write(arr.Count);
            }
            Console.WriteLine("\nOUTPUT.TXT\n\n" + arr.Count);
            Console.ReadKey();
        }
    }
}
