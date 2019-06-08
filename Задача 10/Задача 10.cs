using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Задача_10
{
    class Program
    {
        public static ListEntry ReadFromFile(string file_name)
        {
            ListEntry ans = new ListEntry();
            ListEntry list = ans;
            using (FileStream sf = new FileStream(file_name, FileMode.OpenOrCreate)) { }
            using (StreamReader reader = new StreamReader(file_name))
            {
                Console.WriteLine(file_name.ToUpper() + "\n");
                while (reader.Peek() > -1)
                {
                    string str = reader.ReadLine();
                    str = Regex.Replace(str.Trim(), @"\s+", " ");
                    Console.WriteLine(str);
                    string[] str_arr = str.Split(new char[] { ' ' });
                    try
                    {
                        if (Convert.ToInt32(str_arr[1]) != 0)
                        {
                            list.Next = new ListEntry(Convert.ToInt32(str_arr[0]), Convert.ToInt32(str_arr[1]));
                            list = list.Next;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("\n\nФайл заполнен неверно. Проверьте заполнение файла и запустите программу еще раз");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
            }
            return ans.Next;
        }
        public static ListEntry Multiplication(ListEntry pol_1, ListEntry pol_2)
        {
            if (pol_1 != null && pol_2 != null)
            {
                // перемножение членов
                ListEntry ans = new ListEntry();
                ListEntry list = ans;
                while (pol_1 != null)
                {
                    ListEntry help_pol_2 = pol_2;
                    while (help_pol_2 != null)
                    {
                        list.Next = new ListEntry(pol_1.Degree + help_pol_2.Degree, pol_1.A * help_pol_2.A);
                        list = list.Next;
                        help_pol_2 = help_pol_2.Next;
                    }
                    pol_1 = pol_1.Next;
                }
                ans = ans.Next;
                list = ans;

                // приведение подобных
                while (list != null)
                {
                    ListEntry help_list = list.Next;
                    ListEntry help_list_last = list;
                    while (help_list != null)
                    {
                        if (help_list.Degree == list.Degree)
                        {
                            list.A += help_list.A;
                            help_list_last.Next = help_list.Next;
                            help_list = help_list.Next;
                        }
                        else
                        {
                            help_list_last = help_list_last.Next;
                            help_list = help_list.Next;
                        }
                    }
                    list = list.Next;
                }

                // удаление нулевых членов
                while (ans.A == 0) { ans = ans.Next; }
                if (ans != null)
                {
                    list = ans.Next;
                    ListEntry last_list = ans;
                    while (list != null)
                    {
                        if (list.A == 0)
                        {
                            last_list.Next = list.Next;
                            list = list.Next;
                        }
                        else
                        {
                            last_list = list;
                            list = list.Next;
                        }
                    }
                }
                return ans;
            }
            else return null;
        }
        static void Main(string[] args)
        {
            string input_1_f = "input_1.txt", input_2_f = "input_2.txt", output_f = "output.txt";
            ListEntry list_1 = ReadFromFile(input_1_f);
            ListEntry list_2 = ReadFromFile(input_2_f);

            using (FileStream sf = new FileStream(output_f, FileMode.OpenOrCreate)) { }
            using (StreamWriter writer = new StreamWriter(output_f))
            {

                Console.WriteLine("\nOUTPUT.TXT\n\n");
                ListEntry list = Multiplication(list_1, list_2);    
                while (list != null)
                {
                    Console.WriteLine(list.ToString());
                    writer.WriteLine(list.ToString());
                    list = list.Next;
                }
            }
            Console.ReadKey();
        }
    }
}
