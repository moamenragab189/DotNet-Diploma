using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop.Inheritance_and_Composition
{
    internal class PerfectList
    {
        private List<int> list;
        //public PerfectList() { }
        public PerfectList(List<int> l) 
        {
            list =l;
        }
        public bool Validate()
        {
            int greaterhan100 = 0;
            foreach (int x in list)
                greaterhan100 += x;
            if (greaterhan100 < 100)
                return false;
            for (int i=0;i<list.Count;i++)
            {
                int count = 0;
                for (int j=0;j<list.Count;j++)
                {
                    if (list[i] == list[j])
                        count++;
                    if (count>1)
                        return false;
                }
            }
            return true;
        }
    }
}
