using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input_f = "input.txt", output_f = "output.txt";
            using (FileStream sf = new FileStream(input_f, FileMode.OpenOrCreate)) { }
            int count = 0;
            using (StreamReader reader = new StreamReader(input_f))
            {
                Console.WriteLine("INPUT.TXT\n");
                while (reader.Peek() > -1)
                {
                    string str = reader.ReadLine();
                    Console.WriteLine(str);
                    for (int i=0; i < str.Length; i++)
                    {
                        if (new char[] { '+', '-', '=', '\'', '"' }.Contains(str[i])) count += 3;
                        else if (new char[] { '<', '>', '{', '}', '[', ']' }.Contains(str[i])) count += 8;
                        else if (new char[] { '(', ')' }.Contains(str[i])) count += 1;
                        else if (str[i] == '.') count += 5;
                        else if (str[i] == ',') count += 2;
                        else if (str[i] == ';') count += 7;
                        else if (str[i] == ' ') count += 4;
                        else if (str[i] >= 'a' && str[i] <= 'z') count += ((int)str[i] - (int)'a' + 1) / 10 + ((int)str[i] - (int)'a' + 1) % 10;
                        else if (str[i] >= 'A' && str[i] <= 'Z') count += ((int)str[i] - (int)'A' + 1) / 10 + ((int)str[i] - (int)'A' + 1) % 10 + 10;
                        else if (str[i] >= '0' && str[i] <= '9') count += 13 - ((int)str[i]-(int)'0');
                    }
                }
            }

            using (FileStream sf = new FileStream(output_f, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(output_f))
            {
                writer.Write(count);
            }
            Console.WriteLine("\nOUTPUT.TXT\n\n" + count);
            Console.ReadKey();
        }
    }
}
