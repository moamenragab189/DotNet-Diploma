
using LibraryManagementSystem.Data;

public class Database
{
    
    private List<Book> _Books = new List<Book>();
    private List<Member> _Members = new List<Member>();
    private List<Loan> _LoanRecords = new List<Loan>();

    // Global Settings
    public int MaxBasicMemberLoans = 3;
    public int MaxPremiumMemberLoans = 10;
    public int DefaultLoanDays = 14;
    private static Database instance;
    private  Database()
    {
        
        // B001: Loanable (default 14 days)
        _Books.Add(new Book { ID = "B001", Title = "The Strategy Pattern", Author = "A. Designer", Type = "Loanable", ISBN = "978-0134757599", IsBorrowed = false, MaxLoanDays = 14 });
        // B002: Reference (cannot be borrowed, MaxLoanDays = 0)
        _Books.Add(new Book { ID = "B002", Title = "Design Patterns", Author = "E. P. Trainer", Type = "Reference", ISBN = "978-0201633610", IsBorrowed = false, MaxLoanDays = 0 });
        // B003: Loanable/Special (MaxLoanDays = 7)
        _Books.Add(new Book { ID = "B003", Title = "Fast C# Refactoring", Author = "C. H. Arp", Type = "Loanable", ISBN = "978-0134757600", IsBorrowed = true, MaxLoanDays = 7 });

        
        _Members.Add(new Member { ID = "M101", Name = "Alice Johnson", MembershipLevel = "Basic", MaxLoans = MaxBasicMemberLoans, TotalFeesDue = 0.0m });
        _Members.Add(new Member { ID = "M102", Name = "Bob Smith", MembershipLevel = "Premium", MaxLoans = MaxPremiumMemberLoans, TotalFeesDue = 0.0m });
        _Members.Add(new Member { ID = "M103", Name = "Charlie Staff", MembershipLevel = "Staff", MaxLoans = 99, TotalFeesDue = 0.0m });

        // Overdue record for B003
        _LoanRecords.Add(new Loan { BookID = "B003", MemberID = "M102", DueDate = DateTime.Now.AddDays(-10), IsOverdue = true });
    }

    //singleton design pattern
    public static Database Getinstance()
    {
        if (instance==null)
        { 
            instance = new Database();
            return instance;
        }
        else return instance;
    }

    
    public void AddBook(Book book)
    {
        _Books.Add(book);
    }
    public void AddMember(Member mem)
    {
        _Members.Add(mem);
    }
    public void AddLoanRecords(Loan loan)
    {
        _LoanRecords.Add(loan);
    }

    public void RemoveRecordAt(int index)
    {
        _LoanRecords.RemoveAt(index);
    }
    public List<Book> Books()
    {
        return _Books;
    }
    public List<Member> Members()
    {
        return _Members;
    }
    public List<Loan> LoanRecords()
    {
        return _LoanRecords;
    }

}