
namespace LibraryManagementSystem.Data
{
    public struct Loan
    {
        public string BookID;
        public string MemberID;
        public DateTime DueDate;
        public bool IsOverdue;
    }
}
