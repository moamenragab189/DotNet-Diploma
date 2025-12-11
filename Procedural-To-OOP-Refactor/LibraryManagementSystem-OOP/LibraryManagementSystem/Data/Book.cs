

namespace LibraryManagementSystem.Data
{
    public struct Book
    {
        public string ID;
        public string Title;
        public string Author;
        public string Type;  
        public string ISBN;
        public bool IsBorrowed;
        public int MaxLoanDays;

        public string? Subtitle;
        public int? Edition;
        public string? InternalNotes;
    }
}
