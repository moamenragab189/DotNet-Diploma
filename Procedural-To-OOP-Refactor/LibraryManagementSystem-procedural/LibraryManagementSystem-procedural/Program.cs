using LibraryManagementSystem.Data;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.Title = ConfigManager.SystemName;
        Console.WriteLine($"--- Welcome to {ConfigManager.SystemName} ---\n");
        ShowDataSnapshot();

        while (true)
        {
            Console.WriteLine("\n\n--- MENU ---");
            Console.WriteLine("1. Borrow Book");
            Console.WriteLine("2. Return Book");
            Console.WriteLine("3. Create New Book");
            Console.WriteLine("4. Generate Overdue Report");
            Console.WriteLine("5. Configure System");
            Console.WriteLine("6. Show Data Snapshot");
            Console.WriteLine("7. Exit");

            Console.Write("\nEnter choice: ");
            string choice = Console.ReadLine();

            if (choice == "1") ProcessBorrowInteraction();
            else if (choice == "2") ProcessReturnInteraction();
            else if (choice == "3") ProcessBookCreationInteraction();
            else if (choice == "4") ProcessReportInteraction();
            else if (choice == "5") ProcessConfigInteraction();
            else if (choice == "6") ShowDataSnapshot();
            else if (choice == "7") break;
            else Console.WriteLine("Invalid choice. Please try again.");
        }

        Console.WriteLine("\nSystem shutting down. Goodbye!");
    }


    private static void ProcessBorrowInteraction()
    {
        Console.WriteLine("\n[1. Borrow Book]");
        Console.Write("Enter Book ID (e.g., B001, B002): ");
        string bookId = Console.ReadLine().Trim();
        Console.Write("Enter Member ID (e.g., M101 (Basic), M103 (Staff)): ");
        string memberId = Console.ReadLine().Trim();

        Console.WriteLine($"\n>> Result: {LoanService.ProcessBorrow(bookId, memberId)}");
    }

    private static void ProcessReturnInteraction()
    {
        Console.WriteLine("\n[2. Return Book]");
        Console.Write("Enter Book ID to return (e.g., B003): ");
        string bookId = Console.ReadLine().Trim();

        Console.WriteLine($"\n>> Result: {LoanService.ProcessReturn(bookId)}");
    }

    private static void ProcessBookCreationInteraction()
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
    }

    private static void ProcessReportInteraction()
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
    }

    private static void ProcessConfigInteraction()
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
    }

    private static void ShowDataSnapshot()
    {
        Console.WriteLine("\n--- Current Library Snapshot ---");
        Console.WriteLine("BOOKS:");
        foreach (var b in Database.Books)
        {
            string status = b.IsBorrowed ? "OUT" : "IN";
            Console.WriteLine($"  [{b.ID}] {b.Title} ({b.Type}) | Max Loan: {b.MaxLoanDays} days | Status: {status}");
        }
        Console.WriteLine("\nMEMBERS:");
        foreach (var m in Database.Members)
        {
            Console.WriteLine($"  [{m.ID}] {m.Name} ({m.MembershipLevel}) | Max Loans: {m.MaxLoans}");
        }
        Console.WriteLine("\nLOAN RECORDS:");
        foreach (var l in Database.LoanRecords)
        {
            string overdue = l.IsOverdue ? "OVERDUE" : "Active";
            Console.WriteLine($"  Book {l.BookID} to Member {l.MemberID} | Due: {l.DueDate:yyyy-MM-dd} | Status: {overdue}");
        }
        Console.WriteLine("----------------------------------------------");
    }
}