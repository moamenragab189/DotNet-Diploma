using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Data_Abstraction
{
    internal class Circle
    {
        private double radius;
        public Circle(double r)
        {
            radius = r;
        }
        public double Area()
        {
            return Math.PI*radius*radius;
        }
        public double Circumference()
        {
            return 2*Math.PI*radius;
        }
    }
}
