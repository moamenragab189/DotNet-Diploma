using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Constructor
{
    internal class Rectangle
    {
        private int width;
        private int height;
        public Rectangle()
        {
            width = 1;
            height = 1;
        }
        public Rectangle(int w,int h)
        {
            width = w;
            height = h;
        }
        public void area()
        {
            Console.WriteLine(width*height);
        }
    }
}
