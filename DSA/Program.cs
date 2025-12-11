using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DSA

{
    internal class Program
    {
        static List<int> task1(List<int> list1, List<int> list2)
        {
            List<int> merged = new List<int>();
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    merged.Add(list1[i]);
                }
                for (int j = 0; j < list2.Count; j++)
                {
                    merged.Add(list2[j]);
                }
                return merged;
            }
            
        }

        static List<int> task2(List<int> list1, List<int> list2)
        {
            list1.ToArray ();
            //frequency array to preprocess the count of each number
            int[] freq=new int[1000];
            for (int i=0;i<list1.Count;i++)
            {
                freq[list1[i]]++;
            } 
            for (int j=0;j<list2.Count;j++)
            {
                freq[list2[j]]++;
            }
            List<int> magnetic = new List<int>();
            //fill the new list with duplicates according to their frequency
            for (int i=0;i<freq.Length;i++)
            {
                for (int j = 0; j < freq[i];j++)
                {
                    magnetic.Add(i);
                }
            }
            return magnetic;
        }
        static List<int> task3(List<List<int>> list)
        { 
            List<int> flattened = new List<int>();
            foreach (var nested in list)
            {
                int sum = 0;
                foreach (int item in nested)
                {
                  sum+= item;
                }
                flattened.Add(sum);
            }
            return flattened;
        }
        //task 6
        class PhoneBook
        {
           Dictionary<string,string> dic = new Dictionary<string,string>();
           public void ConstructPhoneBook(List<string> numbers, List<string> names)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    dic.Add(names[i], numbers[i]);
                }
            }
          public string RetrievePhoneNumber(string name)
            {
                if (!dic.ContainsKey(name))
                {
                    return "Not found";
                }
                return dic[name];
            }
        }
       
        static void Task7(string s)
        {
            List<string> strings = s.Split(' ').ToList();
            Dictionary<string, int> dic = new Dictionary<string, int>();
            foreach (string x in strings)
            {
              string lower=  x.ToLower();
                if (dic.ContainsKey(lower))
                {
                    dic[lower]++;
                }
                else
                {
                    dic[lower] = 1;
                }
            }
            foreach (var x in dic)
            {
                Console.WriteLine($"{x.Key} --> {x.Value}");
            }
        }
        // task9 build to run in leetcode
        public class Solution
        {
            public int[] Intersection(int[] nums1, int[] nums2)
            {
                Dictionary<int, int> dic = new Dictionary<int, int>();
                foreach (int x in nums1)
                {
                    if (!dic.ContainsKey(x))
                    {
                        dic.Add(x, 1);
                    }
                }
                foreach (int x in nums2)
                {
                    if (dic.ContainsKey(x))
                    {
                        dic[x]++;
                    }
                }
                List<int> arr = new List<int>();
                foreach (var x in dic)
                {
                    if (x.Value > 1)
                    {
                        arr.Add(x.Key);
                    }
                }
                return arr.ToArray(); ;
            }
        }
        static void task10(List<int> list1)
        {
            Dictionary<int ,int> dic=new Dictionary<int, int> ();
            List<int>Dublicated = new List<int>();
            foreach (int x in list1) 
            {
                if (dic.ContainsKey(x))
                {
                    dic[x]++;
                }
                else dic.Add(x,1);
            }
            foreach (var x in dic)
            {
                if (x.Value>1)
                { 
                   Console.WriteLine(x.Key);
                }
            }

        }
        static void task11(string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (dic.ContainsKey(c))
                {
                    dic[c]++;
                }
                else dic.Add(c, 1);
            }
            foreach (var x in dic)
            {
                if(x.Value==1)
                    {
                    Console.WriteLine(x.Key);
                    break;
                }
            }
        }
        static void task12(List<int>list, int target)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int x in list)
            {
                if (!dic.ContainsKey(x))
                {
                    dic.Add(x,1);
                    if (dic.ContainsKey(target - x))
                    {
                      Console.WriteLine($"({x},{target - x})");
                    }
                }
               
            }
        }
        static void Main(string[] args)
        {
            //                 -- Merging and Flattening --
            //                  task1 Merge Two lists



            /*
              List<int> list1 = new List<int> { 1, 3, 5 };
              List<int> list2 = new List<int> { 2, 4, 6, 8, 10 };
              List<int> mergedList = task1(list1, list2);
                  foreach (var item in mergedList)
                  {
                      Console.Write(item + " ");
                  }
            Output: 1 3 5 2 4 6 8 10
            */


            //==========================================================

            //                  Task2 : Magnetic Numbers


            /*
            List<int> mergedList = task2(new List<int> { 1, 5, 10},new List<int>{ 10, 1, 5, 2});
            foreach (var item in mergedList)
            {
                Console.Write(item + " ");
            }
            */


            //===================================================================
            //                    Task3: Flat and Aggregate Internal Lists


            /* List<int> flattened = task3(new List<List<int>> { new List<int> {1,2 }, new List<int> { 4, 3 }, new List<int> { 5, 6 } });
             foreach (var item in flattened)
             {
                 Console.Write(item + " ");
             }*/


            //=============================================================
            //                         --Dictionaries (Key-Value)--
            //                    Task6: Phone Book

            //================================================================

            /*
            PhoneBook phonebook = new PhoneBook();
            List<string> numbers = new List<string> { "123-456-7890", "987-654-3210", "555-555-5555" };
            List<string> names = new List<string> { "moamen", "ali", "mo" };
            phonebook.ConstructPhoneBook(numbers, names);
            Console.WriteLine(phonebook.RetrievePhoneNumber("moamen"));
            Console.WriteLine(phonebook.RetrievePhoneNumber("sayed"));
            */
            //==============================================================


            //                           Task7: Word Counter


            //   Task7("Every day and every month and every year");

            //====================================================================
            //                      --Dictionaries (Fast Search)--

            //========================================================================


            //                 Task10 : Check for Duplicates (Interview problem)
            /*List<int> ints = new List<int>() {1,2,3,4,56,1,3,56 };
            task10(ints);
            */
            //=================================================================================



            //                 Task11 : Find the First Non-repeating Character
            // task11("swwiss");


            //=================================================================================


            //                          Task12 : Two Sum 
            task12(new List<int> { 0, 4, 2, 5, 1, 3 }, 5);

            //=================================================================================
        }
    }
}
