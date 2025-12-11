using LibraryManagementSystem.Data;
using LibraryManagementSystem.oop.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.processes
{
    internal class ProcessBookCreationInteraction : IProcess
    {
        Database database = Database.Getinstance();
        public void processInterAction()
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

            BookManagerBuilder bookManagerBuilder = new BookManagerBuilder();
            bookManagerBuilder.settitle(title)
                .setauthor(author)
                .setisbn(isbn)
                .setbooktype(type)
                ;
            BookManager bookManager= bookManagerBuilder.Build();
            Book newBook = bookManager.CreateNewBook();

            if (!string.IsNullOrEmpty(newBook.ID))
            {
                // Manual addition to static list is highly coupled
                database.AddBook(newBook);
                Console.WriteLine($"\n>> Successfully added: {newBook.Title} (ID: {newBook.ID}, Days: {newBook.MaxLoanDays})");
            }
        }
    }
}
