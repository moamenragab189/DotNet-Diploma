using LibraryManagementSystem.oop.processes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.Managers
{
   
    internal class ProcessManager
    { private string _choice;

        public ProcessManager(string choice)
        {
            _choice = choice;
        }
        public IProcess? ControlFlow()
        {
            switch (_choice)
            {
                case "1":
                    return new ProcessBorrowInteraction();
                case "2":
                    return new ProcessReturnInteraction();
                case "3":
                    return new ProcessBookCreationInteraction();
                case "4":
                    return new ProcessReportInteraction();
                case "5":
                    return new ProcessConfigInteraction();
                case "6":
                    return new ProcessSnaoshot();
                case "7":
                default:
                    return null;
            }
        }
    }
}
