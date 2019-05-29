using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Задача_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> arr = new List<string>();
            string input_f = "input.txt", output_f = "output.txt";
            //using (FileStream sf = new FileStream(input_f, FileMode.OpenOrCreate)) { }

            using (StreamReader reader = new StreamReader(input_f))
            {
                //Console.WriteLine("INPUT.TXT\n");
                string str = reader.ReadLine();
                //Console.WriteLine(str);
                int count = Convert.ToInt32(str);
                for (int i = 0; i < count; i++)
                {
                    str = reader.ReadLine();
                    //Console.WriteLine(str);
                    bool not_find = true;

                    foreach (string arr_str in arr)
                    {
                        bool find = true;

                        if (arr_str.Length > str.Length) { if (!arr_str.Contains(str)) find = false; }
                        else { if (!str.Contains(arr_str)) find = false; }

                        if (find)
                        {
                            not_find = false;
                            if (str.Length > arr_str.Length)
                            {
                                arr.Remove(arr_str);
                                arr.Add(str);
                            }
                            break;
                        }
                    }

                    if (not_find) arr.Add(str);
                }
            }

            //using (FileStream sf = new FileStream(output_f, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(output_f))
            {
                writer.Write(arr.Count);
            }
            //Console.WriteLine("\nOUTPUT.TXT\n\n" + arr.Count);
            //Console.ReadKey();
        }
    }
}
