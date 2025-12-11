using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Inheritance_and_Composition
{
    internal class ComplexValidatInhirtance : PerfectList
    {
        private List<int> list;
        public ComplexValidatInhirtance(List<int> l) : base(l)
        {
          list = l;
        }
        public bool Validate()
        {
            if (!base.Validate()||list.Count>10)
            {
                return false;
            }
            return true;
        }
    }
}
