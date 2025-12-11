using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Polymorphism
{
    internal class PremiumUser : User
    {
        public double CalcDiscount()
        {
            return 0.2;
        }
    }
}
