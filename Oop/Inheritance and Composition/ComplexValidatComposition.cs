using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Inheritance_and_Composition
{
    internal class ComplexValidatComposition
    {
        private List<int> list;
        public PerfectList perfect;
        public ComplexValidatComposition(List<int>l)
        {
            list= l;
        }
        public bool Validate()
        {
            if (!perfect.Validate() || list.Count > 10)
            {
                return false;
            }
            return true;
        }
    }
}
