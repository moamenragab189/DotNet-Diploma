using LibraryManagementSystem.Data;
using System;
using System.Linq;

public class BookManager
{
     public string bookId;
     public string title;
     public string author;
     public string isbn;
     public string bookType;
     public string? subtitle = null;
     public int? edition = null;
     public string? internalNotes = null;
     public Book book;
    Database database = Database.Getinstance();
    public Book GetBookCopy()
    {
        // Returns an empty struct if not found
        return database.Books().FirstOrDefault(b => b.ID == bookId);
    }

    
    public  Book CreateNewBook()
    {
        string newId = "B" + (database.Books().Count + 100).ToString();
        int loanDays = database.DefaultLoanDays; // Start with default

       
        if (bookType == "Reference")
        {
            loanDays = 0; // Reference books cannot be loaned
            Console.WriteLine("Note: Creating Reference Book. Loan days set to 0.");
        }
        else if (bookType == "Loanable")
        {
            // Simple check, standard 14 days
            Console.WriteLine("Note: Creating standard Loanable Book.");
        }
        else if (bookType == "Special")
        {
            loanDays = 7; // Special short loan period
            Console.WriteLine("Note: Creating Special Loanable Book. Short loan period enforced.");
        }
        else
        {
            Console.WriteLine($"Error: Unknown book type '{bookType}'. Defaulting to standard Loanable.");
        }

        // Returns a raw struct product.
        return new Book
        {
            ID = newId,
            Title = title,
            Author = author,
            ISBN = isbn,
            Type = bookType,
            IsBorrowed = false,
            MaxLoanDays = loanDays,

            Subtitle = subtitle,
            Edition = edition,
            InternalNotes = internalNotes
        };
    }

  
    public bool CanBookBeBorrowed()
    {
        if (book.ID == null) return false;

        if (book.Type == "Reference")
        {
            Console.WriteLine($"Validation failed: {book.Title} is a **Reference** book and cannot be borrowed.");
            return false;
        }

        if (book.IsBorrowed)
        {
            Console.WriteLine($"Validation failed: {book.Title} is already borrowed.");
            return false;
        }

        return true;
    }
}