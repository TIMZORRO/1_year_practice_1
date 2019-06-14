using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_12
{
    class Program
    {
        public static int count_compare = 0;
        public static int count_changed = 0;
        public static int[] IntCopy(int[] sourse, int sourse_index, int length)
        {
            int[] ans = new int[length];
            Array.Copy(sourse, sourse_index, ans, 0, length);
            return ans;
        }

        public static int[] BubbleSort(int[] arr)
        {
            count_changed = 0;
            count_compare = 0;
            if (arr.Length > 1)
            {
                for (int i=0; i < arr.Length; i++)
                {
                    count_compare++;
                    //bool found = false;
                    for (int j = arr.Length - 2; j >= i; j--) 
                    {
                        count_compare++;
                        if (arr[j] > arr[j + 1]) 
                        {
                            int num = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = num;
                            //found = true;
                            count_changed++;
                        }
                        count_compare++;
                    }
                    //if (!found) break;
                }
            }
            return arr;
        }

        public static int[] MergeSort(int[] arr)
        {
            if (arr.Length > 1)
            {
                int index = arr.Length / 2;
                int[] arr1 = MergeSort(IntCopy(arr, 0, index));
                int[] arr2 = MergeSort(IntCopy(arr, index, arr.Length - index));

                int count1 = 0, count2 = 0, i = 0;
                for (i = 0; count1 != arr1.Length && count2 != arr2.Length; i++) 
                {
                    if (arr1[count1] > arr2[count2]) arr[i] = arr2[count2++];
                    else arr[i] = arr1[count1++];
                    count_compare += 2;
                    count_changed++;
                }
                while (count1 != arr1.Length) { arr[i++] = arr1[count1++]; count_compare++; count_changed++; }
                while (count2 != arr2.Length) { arr[i++] = arr2[count2++]; count_compare++; count_changed++; }
            }
            return arr;
        }

        public static int[] StartMergeSort(int[] arr)
        {
            count_changed = 0;
            count_compare = 0;
            return MergeSort(arr);
        }

        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] arr2 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] arr3 = new int[] { 5, 8, 1, 3, 6, 2, 9, 4, 10, 7 };
            
            BubbleSort(arr1);
            Console.WriteLine("Упорядоченный по возрастанию массив. Сортировка пузырьком. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);
            
            BubbleSort(arr2);
            Console.WriteLine("Упорядоченный по убыванию массив. Сортировка пузырьком. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);
            
            BubbleSort(arr3);
            Console.WriteLine("Неупорядоченный массив. Сортировка пузырьком. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);
            
            StartMergeSort(arr1);
            Console.WriteLine("Упорядоченный по возрастанию массив. Сортировка слияниями. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);
            
            StartMergeSort(arr2);
            Console.WriteLine("Упорядоченный по убыванию массив. Сортировка слияниями. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);
            
            StartMergeSort(arr3);
            Console.WriteLine("Неупорядоченный массив. Сортировка слияниями. Количество пересылок: {0}. Количество сравнений: {1}", count_changed, count_compare);

            Console.ReadKey();
        }
    }
}
