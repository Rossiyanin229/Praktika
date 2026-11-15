using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Main.Tasks.Level3;
using Xunit;

namespace Practicum.Tests;

public class LibraryTests
{
    [Fact]
    public void BorrowBook_AvailableBook_Succeeds()
    {
        
        var library = new Library();
        var reader = new Reader("Иван");
        var book = new Book("Война и мир", "Толстой");
        library.AddBook(book);

        
        library.BorrowBook(reader, book);

       
        Assert.False(book.IsAvailable);
        Assert.Contains(book, reader.BorrowedBooks);
    }

    [Fact]
    public void BorrowBook_LimitExceeded_ThrowsException()
    {
        var library = new Library();
        var reader = new Reader("Иван");

        
        for (int i = 0; i < 3; i++)
        {
            var b = new Book($"Книга {i}", "Автор");
            library.AddBook(b);
            library.BorrowBook(reader, b);
        }

        var extraBook = new Book("Лишняя", "Автор");
        library.AddBook(extraBook);

       
        Assert.Throws<LibraryException>(() => library.BorrowBook(reader, extraBook));
    }
}
