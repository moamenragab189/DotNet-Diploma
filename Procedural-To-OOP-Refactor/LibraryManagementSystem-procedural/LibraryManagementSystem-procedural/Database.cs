
using LibraryManagementSystem.Data;

public static class Database
{
    
    public static List<Book> Books = new List<Book>();
    public static List<Member> Members = new List<Member>();
    public static List<Loan> LoanRecords = new List<Loan>();

    // Global Settings
    public static int MaxBasicMemberLoans = 3;
    public static int MaxPremiumMemberLoans = 10;
    public static int DefaultLoanDays = 14;

    static Database()
    {
        
        // B001: Loanable (default 14 days)
        Books.Add(new Book { ID = "B001", Title = "The Strategy Pattern", Author = "A. Designer", Type = "Loanable", ISBN = "978-0134757599", IsBorrowed = false, MaxLoanDays = 14 });
        // B002: Reference (cannot be borrowed, MaxLoanDays = 0)
        Books.Add(new Book { ID = "B002", Title = "Design Patterns", Author = "E. P. Trainer", Type = "Reference", ISBN = "978-0201633610", IsBorrowed = false, MaxLoanDays = 0 });
        // B003: Loanable/Special (MaxLoanDays = 7)
        Books.Add(new Book { ID = "B003", Title = "Fast C# Refactoring", Author = "C. H. Arp", Type = "Loanable", ISBN = "978-0134757600", IsBorrowed = true, MaxLoanDays = 7 });

        
        Members.Add(new Member { ID = "M101", Name = "Alice Johnson", MembershipLevel = "Basic", MaxLoans = MaxBasicMemberLoans, TotalFeesDue = 0.0m });
        Members.Add(new Member { ID = "M102", Name = "Bob Smith", MembershipLevel = "Premium", MaxLoans = MaxPremiumMemberLoans, TotalFeesDue = 0.0m });
        Members.Add(new Member { ID = "M103", Name = "Charlie Staff", MembershipLevel = "Staff", MaxLoans = 99, TotalFeesDue = 0.0m });

        // Overdue record for B003
        LoanRecords.Add(new Loan { BookID = "B003", MemberID = "M102", DueDate = DateTime.Now.AddDays(-10), IsOverdue = true });
    }
}