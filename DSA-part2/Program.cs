using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace task7
{
    internal class Program
    {
        //Task1 : Group Names by First Letter
        static void Task1(List<string> list)
        {
            //Dictionary to contain the first letter as key and names as value
            Dictionary<char, string> dict = new Dictionary<char, string>();
            // search for each name in the list and check if the first letter exists in the dictionary or not
            foreach (string item in list)
            {
                // if it exists add the name to the value of that key
                if (dict.ContainsKey(item[0])) dict[item[0]] += "," + item;
                // if it doesn't exist add the first letter as key and the name as value
                else dict.Add(item[0], item);
            }
            // print the dictionary
            foreach (var item in dict) Console.WriteLine($"{item.Key} :  {item.Value}");
        }
        //========================================================================================================

        //Task2 : Group Employees by Department

        static void Task2(List<string> list)
        {
            // Dictionary to get the department as key and name as a value 
            Dictionary<string, string> dic = new Dictionary<string, string>();
            // list to split the string as name and department seperated
            List<string> Pair = new List<string>();

            foreach (string item in list)
            {

                Pair = item.Split(':').ToList();
                // check for the key
                if (dic.ContainsKey(Pair[1]))
                {
                    dic[Pair[1]] += $",{Pair[0]}";
                }
                else { dic.Add(Pair[1], Pair[0]); }
            }
            foreach (var item in dic) Console.WriteLine($"{item.Key} :  {item.Value}");
        }




        static void Main(string[] args)
        {
            //task 1
            //  List<string> list = new List<string>() {"moamen","mohamed","ahmed","ali","samy","saed","waleed"};
            //Task1(list);

            //===========================================================

            // List<string> list = new List<string>() { "moamen:dev", "mohamed:it", "ahmed:dev", "ali:ceo", "samy:ceo", "saed:it", "waleed:ops" };
            //Task2(list);

        }
    }
}
