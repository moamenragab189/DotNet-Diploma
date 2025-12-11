using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    internal class Car
    {
        public static int Count=0;
        public string model;
        public Car() {
            Count++;
        }
    }
}
