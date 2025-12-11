using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Private_and_Publiv_Members
{
    internal class Person
    {
        private int Age;
        public void SetAge(int age)
        {
            if (age > 0 && age <= 120)
            {
                Age = age;
                Console.WriteLine("Done");
            }
            else Console.WriteLine("not a valid age please enter number in this range 1 : 120 ");
        }


    }
}
