using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessSnaoshot : IProcess
    {
        public void processInterAction()
        {
            UserWelcom userWelcom = new UserWelcom();
            userWelcom.ShowDataSnapshot();
        }
    }
}
