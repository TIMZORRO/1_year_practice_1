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
            using (StreamReader reader = new StreamReader(input_f, Encoding.Default))
            {
                Console.WriteLine("INPUT.TXT\n");
                while (reader.Peek() > -1)
                {
                    char chr = (char)reader.Read();
                    Console.Write(chr);
                    if (new char[] { '+', '-', '=', '\'', '"' }.Contains(chr)) count += 3;
                    else if (new char[] { '<', '>', '{', '}', '[', ']' }.Contains(chr)) count += 8;
                    else if (new char[] { '(', ')' }.Contains(chr)) count += 1;
                    else if (chr == '.') count += 5;
                    else if (chr == ',') count += 2;
                    else if (chr == ';') count += 7;
                    else if (chr == ' ') count += 4;
                    else if (chr >= 'a' && chr <= 'z') count += ((int)chr - (int)'a' + 1) / 10 + ((int)chr - (int)'a' + 1) % 10;
                    else if (chr >= 'A' && chr <= 'Z') count += ((int)chr - (int)'A' + 1) / 10 + ((int)chr - (int)'A' + 1) % 10 + 10;
                    else if (chr >= '0' && chr <= '9') count += 13 - ((int)chr - (int)'0');
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
