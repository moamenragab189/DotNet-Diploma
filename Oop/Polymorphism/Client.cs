using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Polymorphism
{
    internal class Client
    {
        public Client(User user) 
        {
            Console.WriteLine( user.CalcDiscount());
        }
    }
}
