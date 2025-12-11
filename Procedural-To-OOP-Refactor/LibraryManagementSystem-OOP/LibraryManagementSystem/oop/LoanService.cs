using LibraryManagementSystem.Data;
using LibraryManagementSystem.oop.Builders;

public class LoanService
{
    public string bookId;
    public string memberId;

    Database database= Database.Getinstance();
    MemberManagerBuilder builder= new MemberManagerBuilder();
    public string ProcessBorrow()
    {
        BookManagerBuilder bookManagerBuilder = new BookManagerBuilder();
        bookManagerBuilder.setbookid(bookId);
        BookManager bookManager = bookManagerBuilder.Build();
        // 1. Fetch data copies
        Book bookToBorrow = bookManager.GetBookCopy();
        Member memberBorrower = database.Members().FirstOrDefault(m => m.ID == memberId);

        if (string.IsNullOrEmpty(bookToBorrow.ID) || string.IsNullOrEmpty(memberBorrower.ID))
        {
            return "Failure: Book or Member not found.";
        }
        bookManagerBuilder.setbook(bookToBorrow);
        bookManager= bookManagerBuilder.Build();
        // 2. Pre-Check: Book and Member Eligibility
        if (!bookManager.CanBookBeBorrowed())
        {
            return "Failure: Book cannot be borrowed (Reference or already out).";
        }
        builder.setmember(memberBorrower);
        MemberManager memberManager = builder.Build();
        if (!memberManager.IsEligibleToBorrow())
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
        int bookIndex = database.Books().FindIndex(b => b.ID == bookId);
        Book updatedBook = database.Books()[bookIndex];
        updatedBook.IsBorrowed = true;
        database.Books()[bookIndex] = updatedBook;

        // Create and add new loan record
        var newLoan = new Loan
        {
            BookID = bookId,
            MemberID = memberId,
            DueDate = dueDate,
            IsOverdue = false
        };
        database.AddLoanRecords(newLoan);

        return $"Success: Book '{bookToBorrow.Title}' borrowed by member '{memberBorrower.Name}'. Due on {dueDate:yyyy-MM-dd}.";
    }

    public string ProcessReturn()
    {
        var loanIndex = database.LoanRecords().FindIndex(l => l.BookID == bookId && l.IsOverdue == false);
        var bookIndex = database.Books().FindIndex(b => b.ID == bookId);

        if (loanIndex == -1 || bookIndex == -1)
        {
            return "Failure: No active loan found for this book or book does not exist.";
        }

        var loan = database.LoanRecords()[loanIndex];
        var member = database.Members().FirstOrDefault(m => m.ID == loan.MemberID);

        int daysLate = (int)(DateTime.Now - loan.DueDate).TotalDays;


  
        builder.setmember(member).setdaysLate(daysLate);
        MemberManager memberManager = builder.Build();



        decimal fee = memberManager.CalculateLateFee();

        if (fee > 0)
        {
            Console.WriteLine($"\n**FEE NOTICE:** {member.Name} owes ${fee:F2} for being {daysLate} days late.");
        }

        // Update data state
        database.RemoveRecordAt(loanIndex);
        Book updatedBook = database.Books()[bookIndex];
        updatedBook.IsBorrowed = false;
        database.Books()[bookIndex] = updatedBook;

        return $"Success: Book '{updatedBook.Title}' has been returned.";
    }
}