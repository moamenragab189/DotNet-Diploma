using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Program_Lifecycle
{
    internal class Program
    {


        //this dictionary to store input values 
        static Dictionary<string, int> values = new Dictionary<string, int>();

        static public void assign(List<string> instruction)
        {
            //check count of the instruction
            if (instruction.Count != 3 && instruction.Count != 5)
            {
                Console.WriteLine("Invalid Statement");
                Environment.Exit(0);
            }
            //check simi colon
            string lastvalue = instruction[instruction.Count - 1];
            if (lastvalue[lastvalue.Length - 1] != ';')
            {
                Console.WriteLine("Missing ; at the end of line.");
                Environment.Exit(0);
            }
            //remove simicon
            instruction[instruction.Count - 1]=lastvalue.Remove(lastvalue.Length - 1,1);
            // this if i need to assign without adding
            if (instruction.Count == 3)
            {
                //check varible name        
                if (char.IsDigit(instruction[1][0]))
                {
                    Console.WriteLine("Invalid Variable Name.");
                    Environment.Exit(0);
                }
                //check value data type
                int x;
                bool isnumber = int.TryParse(instruction[2], out x);
                if (!isnumber)
                {
                    Console.WriteLine("Invalid data type");
                    Environment.Exit(0);
                }
                values[instruction[1]] = x;
            }
            //this if need to assgin with adding
            else if (instruction.Count == 5)
            {
                //check varible name        
                if (char.IsDigit(instruction[1][0]))
                {
                    Console.WriteLine("Invalid Variable Name.");
                    Environment.Exit(0);
                }
                //check if this varibales exist
                if (!values.ContainsKey(instruction[3]) || !values.ContainsKey(instruction[4]))
                {
                    Console.WriteLine("Invalid Variable Name.");
                    Environment.Exit(0);
                }
                //check ADD keyword
                if (instruction[2] != "ADD")
                {
                    Console.WriteLine("Error: Invalid Statement");
                    Environment.Exit(0);
                }
                values[instruction[1]] = values[instruction[3]] + values[instruction[4]];
            }

        }




        static public void print(List<string> instruction)
        {
            //check simi colon
            string lastvalue = instruction[instruction.Count - 1];
            if (lastvalue[lastvalue.Length - 1] != ';')
            {
                Console.WriteLine("Missing ; at the end of line.");
                Environment.Exit(0);
            }
            //remove simicon
            instruction[instruction.Count - 1]=lastvalue.Remove(lastvalue.Length - 1,1);
            if (instruction.Count != 2)
            {
                Console.WriteLine("Invalid Statement");
                Environment.Exit(0);
            }
            //check is it number or varible to print
            if (!char.IsDigit(instruction[1][0]))
            {
                if (!values.ContainsKey(instruction[1]))
                {
                    Console.WriteLine("Invalid Variable Name.");
                    Environment.Exit(0);
                }
                Console.WriteLine(values[instruction[1]]);
            }
            else Console.WriteLine(int.Parse(instruction[1]));

        }

        static void Main(string[] args)
        {

            //-----------------------------------------------------
            #region Task description
            /*
                Design and Implement an interpreter for the small# programming language. 
               Small# is a simple programming language that: - 
               Has only one data type: int - - 
               Has Three operations - 
               ASSIGN: assigns and value to a variable. - - 
               ADD: adds two integers and evaluates to adding result. (It’s an 
               Expression) 
               LOG: prints an int value to the Console  
               Supports variables with some constraints: - 
               Variable names must start with a letter, and must not exceed 10 
               characters. 
               Language Syntax (BNF form) 
               <program>       
               ::= { <statement> } 
               <statement>     ::= <assign> | <log> ‘;’ 
               <assign>        
               <value>         
               ::= "ASSIGN" <identifier> <value>  ‘;’ 
               ::= <integer> | <add-expression> 
               <add-expression>::= "ADD" <identifier> <identifier> 
               <log>           
               ::= "LOG"  <identifier> 
               <identifier>    ::= <letter> { <letter-or-digit> } 
               —----- 
               Notes:  
               {        
               }     
               means ‘one or more’ 
               Errors 
               - Invalid Variable Name. - Missing ; at the end of line. - Invalid Statement - Invalid Expression 


               Inputs and Outputs 
               Input: a txt file containing small# code. 
               Output: the result of running this program.
                */
            #endregion
            //-----------------------------------------------------

            List<string> code = new List<string>();
            List<string> SingelInstructions = new List<string>();
            string file = @"D:\c#\Tasks\Tasks\Program Lifecycle\example1.txt";
            code = File.ReadAllLines(file).ToList();
            for (int i = 0; i < code.Count; i++)
            {
                SingelInstructions = code[i].Trim().Split().ToList();

                switch (SingelInstructions[0])
                {
                    case "ASSIGN":assign(SingelInstructions);
                        break;
                    case "LOG":print(SingelInstructions);
                        break;
                    default:
                        Console.WriteLine("nvalid Expression");
                        break;

                }
            }
            return;
        }

    }
}
