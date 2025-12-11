using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Constructor
{
    internal class Book
    {
        private string title;
        private string auther;
        public Book() :this("programming","moamen")
        {
            Console.WriteLine(title+" "+auther);
        }
        public Book(string t,string a) 
        {
            title = t;
            auther = a;
        }


    }
}
