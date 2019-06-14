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
                Console.WriteLine("INPUT.TXT\n");
                string str = reader.ReadLine();
                Console.WriteLine(str);
                int count = Convert.ToInt32(str);
                for (int k = 0; k < count; k++)
                {
                    str = reader.ReadLine().Trim().ToLower().Split(new char[] { ' ' })[0];
                    Console.WriteLine(str);
                    bool no_found = true;

                    for (int i = 0; i < arr.Count; i++)
                    {
                        bool found = false;

                        if (arr[i] == str) found = true;
                        else if (arr[i].Length > str.Length && arr[i].Remove(str.Length) == str) found = true;
                        else if (arr[i].Length < str.Length && str.Remove(arr[i].Length) == arr[i]) found = true;


                        if (found)
                        {
                            no_found = false;
                            if (str.Length > arr[i].Length)
                            {
                                arr[i] = str;
                            }
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
