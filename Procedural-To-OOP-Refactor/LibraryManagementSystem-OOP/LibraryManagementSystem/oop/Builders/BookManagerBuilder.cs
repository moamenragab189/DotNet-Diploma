using LibraryManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.Builders
{
    internal class BookManagerBuilder
    {
       private readonly BookManager _bookManager=new BookManager();

        public BookManagerBuilder setbookid(string id)
        {
            _bookManager.bookId = id;
            return this;
        }
        public BookManagerBuilder settitle(string title)
        {
            _bookManager.title = title;
            return this;
        }
        public BookManagerBuilder setedition(int edi)
        {
            _bookManager.edition = edi;
            return this;
        }
        public BookManagerBuilder setauthor(string author)
        {
            _bookManager.author = author;
            return this;
        }
        public BookManagerBuilder setinternalnotes(string note)
        {
            _bookManager.internalNotes = note;
            return this;
        }
        public BookManagerBuilder setisbn(string isbn)
        {
            _bookManager.isbn = isbn;
            return this;
        }
        public BookManagerBuilder setsubtitle(string subtitle)
        {
            _bookManager.subtitle = subtitle;
            return this;
        }
        public BookManagerBuilder setbooktype(string type)
        {
            _bookManager.bookType =type ;
            return this;
        }
        public BookManagerBuilder setbook(Book book)
        {
            _bookManager.book =book ;
            return this;
        }
        public BookManager Build()
        { 
            return _bookManager;
        }
    }
}
