using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.Tasks.Level3;

public class LibraryException : Exception
{
    public LibraryException(string message) : base(message) { }
}

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }

    public void BorrowBook(Reader reader, Book book)
    {
        if (!book.IsAvailable)
            throw new LibraryException("Книга уже выдана.");
        if (reader.BorrowedBooks.Count >= 3)
            throw new LibraryException("Лимит: не более 3 книг на читателя.");

        book.IsAvailable = false;
        reader.BorrowedBooks.Add(book);
    }

    public void ReturnBook(Reader reader, Book book)
    {
        if (!reader.BorrowedBooks.Contains(book))
            throw new LibraryException("Этот читатель не брал эту книгу.");

        book.IsAvailable = true;
        reader.BorrowedBooks.Remove(book);
    }
}
