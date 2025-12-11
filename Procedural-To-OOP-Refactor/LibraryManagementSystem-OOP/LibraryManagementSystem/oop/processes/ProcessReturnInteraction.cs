using LibraryManagementSystem.oop.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessReturnInteraction : IProcess
    {
        public void processInterAction()
        {
            Console.WriteLine("\n[2. Return Book]");
            Console.Write("Enter Book ID to return (e.g., B003): ");
            string bookId = Console.ReadLine().Trim();
            LoanServiceBuilder builder = new LoanServiceBuilder();
            builder.setbookid(bookId);
            LoanService loanService=builder.Build();
            Console.WriteLine($"\n>> Result: {loanService.ProcessReturn()}");
        }
    }
}
