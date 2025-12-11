using LibraryManagementSystem.Data;

public static class LoanService
{
    public static string ProcessBorrow(string bookId, string memberId)
    {
        // 1. Fetch data copies
        Book bookToBorrow = BookManager.GetBookCopy(bookId);
        Member memberBorrower = Database.Members.FirstOrDefault(m => m.ID == memberId);

        if (string.IsNullOrEmpty(bookToBorrow.ID) || string.IsNullOrEmpty(memberBorrower.ID))
        {
            return "Failure: Book or Member not found.";
        }

        // 2. Pre-Check: Book and Member Eligibility
        if (!BookManager.CanBookBeBorrowed(bookToBorrow))
        {
            return "Failure: Book cannot be borrowed (Reference or already out).";
        }
        if (!MemberManager.IsEligibleToBorrow(memberBorrower))
        {
            return "Failure: Member is not eligible.";
        }

        // 3. Determine Loan Details
        DateTime dueDate;
        int loanDays = bookToBorrow.MaxLoanDays; // Use book's specific loan days

        // override book days based on member type 
        if (memberBorrower.MembershipLevel == "Premium" && loanDays > 0)
        {
            loanDays = loanDays + 7; // Premium members get 7 extra days
        }
        else if (memberBorrower.MembershipLevel == "Staff")
        {
            loanDays = 90; // Staff members get 90 days regardless of book type
        }

        if (loanDays <= 0)
        {
            return "Failure: Cannot set a valid loan period (0 days or less).";
        }

        dueDate = DateTime.Now.AddDays(loanDays);

        // 4. Update Data

        // Update Book status
        int bookIndex = Database.Books.FindIndex(b => b.ID == bookId);
        Book updatedBook = Database.Books[bookIndex];
        updatedBook.IsBorrowed = true;
        Database.Books[bookIndex] = updatedBook;

        // Create and add new loan record
        var newLoan = new Loan
        {
            BookID = bookId,
            MemberID = memberId,
            DueDate = dueDate,
            IsOverdue = false
        };
        Database.LoanRecords.Add(newLoan);

        return $"Success: Book '{bookToBorrow.Title}' borrowed by member '{memberBorrower.Name}'. Due on {dueDate:yyyy-MM-dd}.";
    }

    public static string ProcessReturn(string bookId)
    {
        var loanIndex = Database.LoanRecords.FindIndex(l => l.BookID == bookId && l.IsOverdue == false);
        var bookIndex = Database.Books.FindIndex(b => b.ID == bookId);

        if (loanIndex == -1 || bookIndex == -1)
        {
            return "Failure: No active loan found for this book or book does not exist.";
        }

        var loan = Database.LoanRecords[loanIndex];
        var member = Database.Members.FirstOrDefault(m => m.ID == loan.MemberID);

        int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;

        
        decimal fee = MemberManager.CalculateLateFee(member, daysLate);

        if (fee > 0)
        {
            Console.WriteLine($"\n**FEE NOTICE:** {member.Name} owes ${fee:F2} for being {daysLate} days late.");
        }

        // Update data state
        Database.LoanRecords.RemoveAt(loanIndex);
        Book updatedBook = Database.Books[bookIndex];
        updatedBook.IsBorrowed = false;
        Database.Books[bookIndex] = updatedBook;

        return $"Success: Book '{updatedBook.Title}' has been returned.";
    }
}