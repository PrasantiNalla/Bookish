using Microsoft.AspNetCore.Mvc;
using bookish;
using bookish.Models;

namespace bookish.Services;
// Create interfaces

public interface IBookActions
{
    List<Books> BooksList();
    void SubmitAddBook(Books book);
}

// Class - To implement the interfaces
public class BookActions : IBookActions
{
    public List<Books> BooksList()
    {
        var context = new BookishContext();
        var bookList = context.Books.ToList();
        return (bookList);
    }

    public void SubmitAddBook(Books book)
    {
        using (var context = new BookishContext())
        {
            var newBook = new Books()
            {
                BookName = book.BookName,
                AuthorName = book.AuthorName,
                TotalNoOfCopies = book.TotalNoOfCopies,
                AvailableCopies = book.TotalNoOfCopies
            };
            context.Books.Add(newBook);
            context.SaveChanges();
        }
       
    }
}
