using Microsoft.AspNetCore.Mvc;
using bookish;
using bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace bookish.Services;

public interface ICheckoutActions
{
    MyViewModel ViewCheckout();
    //void Checkout(Checkout check);
    List<Checkout> Checkout(int bookId, int memberId);
    // List<Checkout> CheckoutsList();
    string CheckInBook(int bookId);

}
// Class - To implement the interfaces
public class CheckoutActions : ICheckoutActions
{
    public MyViewModel ViewCheckout()
    {
        using (var context = new BookishContext())
        {
            var booksName = context.Books.ToList();
            var membersName = context.Members.ToList();
            var listViewModel = new MyViewModel()
            {
                Books = booksName,
                Members = membersName,

            };
            return listViewModel;
        }
    }
    public List<Checkout> Checkout(int bookId, int memberId)
    {
        using (var context = new BookishContext())
        {
            var selectedBook = context.Books.FirstOrDefault(x => x.BooksId == bookId);
            if (selectedBook != null)
            {
                selectedBook!.AvailableCopies -= 1;

            }
            var checkout = new Checkout()
            {
                MembersId = memberId,
                BooksId = bookId
            };
            context.Checkout.Add(checkout);
            context.SaveChanges();

            var checkoutList = context.Checkout
                        .Include(b => b.Book)
                        .Include(g => g.Member)
                        .ToList();

            return checkoutList;
        }
    }

    public string CheckInBook(int bookId)
    {
        string bookName;
        using (var context = new BookishContext())
        {

            var selectedBook = context.Books.FirstOrDefault(x => x.BooksId == bookId);
            if (selectedBook != null)
            {
                selectedBook!.AvailableCopies += 1;

            }
            bookName = selectedBook.BookName;
            context.SaveChanges();
        }
        return (bookName);
    }



}