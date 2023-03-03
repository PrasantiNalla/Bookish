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
           
            // var query = (from b in context.Books
            //              join c in context.Checkout
            // on b.Id equals c.BookId
            //              join m in context.Members
            //              on c.MemberId equals m.Id
            //              select new { b.BookName, m.FirstName, c });

            // var checkoutDetails = from c in context.Checkout
            //                       join b in context.Books
            //                   on c.BookId equals b.Id
            //                       join m in context.Members
            //                   on c.MemberId equals m.Id
            //                       select new
            //                       {
            //                           BookName = b.BookName,
            //                           MemberName = m.FirstName
            //                       };
           // return query;
           

            var checkoutList = context.Checkout//Where(s => s.BooksId == 1)
                        .Include(b => b.Book)//Book here is a virtual entity
                        .Include(g => g.Member)
                        .ToList();

            return checkoutList;
        }
    }



}