using LibraryManagementSystem.oop.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessBorrowInteraction : IProcess
    {
        public void processInterAction()
        {
            Console.WriteLine("\n[1. Borrow Book]");
            Console.Write("Enter Book ID (e.g., B001, B002): ");
            string bookId = Console.ReadLine().Trim();
            Console.Write("Enter Member ID (e.g., M101 (Basic), M103 (Staff)): ");
            string memberId = Console.ReadLine().Trim();
            LoanServiceBuilder builder = new LoanServiceBuilder();
            builder.setbookid(bookId)
                    .setmemberid(memberId);
            LoanService loanService=builder.Build();
            Console.WriteLine($"\n>> Result: {loanService.ProcessBorrow()}");
        }
    }
}
