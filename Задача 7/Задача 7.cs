using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_7
{
    class Program
    {
        //рекурсия вида для каждого если 1 то присваиваем если больше то вызываем рекурсию
        public static string[] Code(int[] alf, int glub, int max_glub)
        {
            if (glub > max_glub) return new string[alf.Length];
            else
            {
                string[] ans = new string[alf.Length];
                int count = 0, count_noone = 0;
                for (int i = 0; i < alf.Length; i++)
                    if (alf[i] == 1 && count <= Math.Pow(2, glub))
                    {
                        ans[i] += count % 2;
                        count++;
                    }
                    else if (count > Math.Pow(2, glub)) throw new Exception("Слишком много веток на данной глубине");
                    else if (alf[i] > 1) count_noone++;
                if (count == Math.Pow(2, glub) && count_noone == 0) throw new Exception("Слишком много веток на данной глубине!!!");
                int[] help_alf = new int[alf.Length];
                for (int i = 0; i < help_alf.Length; i++) help_alf[i] = alf[i] - 1;
                string[] dop = Code(help_alf, glub + 1, max_glub);
                for (int i = 0; i < ans.Length; i++) if (alf[i]>1) ans[i] += i % 2 + dop[i];
                return ans;
            }
        }
        public static int EnterInt()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch { Console.WriteLine("Неверный ввод, повторите"); }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину кодирующего алфавита");
            int count = EnterInt();
            int[] alf = new int[count];
            string[] code = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Введите длину {0} буквы кодирующего алфавиту", i + 1);
                alf[i] = EnterInt();
            }

            try
            {
                string[] ans = Code(alf, 1, alf.Max());
                foreach (string str in ans) Console.WriteLine(str);
            }
            catch (Exception c) { Console.WriteLine(c.ToString()); }
            Console.ReadKey();

        }
    }
}
