using LibraryManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop
{

    internal class Processes
    {
        
       /* public void ProcessBorrowInteraction()
        {
            Console.WriteLine("\n[1. Borrow Book]");
            Console.Write("Enter Book ID (e.g., B001, B002): ");
            string bookId = Console.ReadLine().Trim();
            Console.Write("Enter Member ID (e.g., M101 (Basic), M103 (Staff)): ");
            string memberId = Console.ReadLine().Trim();

            Console.WriteLine($"\n>> Result: {LoanService.ProcessBorrow(bookId, memberId)}");
        }*/

     /*   public void ProcessReturnInteraction()
        {
            Console.WriteLine("\n[2. Return Book]");
            Console.Write("Enter Book ID to return (e.g., B003): ");
            string bookId = Console.ReadLine().Trim();

            Console.WriteLine($"\n>> Result: {LoanService.ProcessReturn(bookId)}");
        }*/

       /* public void ProcessBookCreationInteraction()
        {
            Console.WriteLine("\n[3. Create New Book]");
            Console.Write("Title: ");
            string title = Console.ReadLine().Trim();
            Console.Write("Author: ");
            string author = Console.ReadLine().Trim();
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine().Trim();
            Console.Write("Type (Loanable/Reference/Special): ");
            string type = Console.ReadLine().Trim();

            Book newBook = BookManager.CreateNewBook(title, author, isbn, type);

            if (!string.IsNullOrEmpty(newBook.ID))
            {
                // Manual addition to static list is highly coupled
                Database.Books.Add(newBook);
                Console.WriteLine($"\n>> Successfully added: {newBook.Title} (ID: {newBook.ID}, Days: {newBook.MaxLoanDays})");
            }
        }*/

       /* public void ProcessReportInteraction()
        {
            Console.WriteLine("\n[4. Generate Overdue Report]");
            Console.Write("Output Format (CSV or HTML): ");
            string format = Console.ReadLine().Trim().ToUpper();

            // Get overdue records (DI Target: Direct access to static data)
            var overdueRecords = Database.LoanRecords.Where(l => l.IsOverdue).ToList();

            string report = ReportGenerator.GenerateReportOutput("Overdue", overdueRecords, format);

            Console.WriteLine($"\n--- Generated {format} Report Output ---");
            Console.WriteLine(report);
            Console.WriteLine("-----------------------------------------");
        }*/

       /* public void ProcessConfigInteraction()
        {
            Console.WriteLine("\n[5. System Configurations]");
            ConfigManager.DisplayCurrentConfig();
            Console.Write("Enter setting key (SystemName, IsMaintenanceMode, DefaultLoanDays): ");
            string key = Console.ReadLine().Trim();
            Console.Write($"Enter new value for {key}: ");
            string value = Console.ReadLine().Trim();

            if (ConfigManager.UpdateConfiguration(key, value))
            {
                Console.WriteLine($"\n>> Successfully updated {key}.");
            }
            else
            {
                Console.WriteLine($"\n>> Failed to update {key}. Check key and value format.");
            }
            ConfigManager.DisplayCurrentConfig();
        }*/
    }
}
