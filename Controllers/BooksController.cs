using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;

namespace bookish.Controllers;

public class BooksController : Controller
{
    private readonly IBookActions _IBookActions;
    public BooksController(IBookActions bookAction)
    {
        _IBookActions = bookAction;
    }

    [Route("Books")]
    public IActionResult Books()
    {
        var bookList = _IBookActions.BooksList();
        return View(bookList);
    }

    [HttpGet]
    public IActionResult AddBook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitAddBook(Books book)
    {
        _IBookActions.SubmitAddBook(book);
        return RedirectToAction("Books");
    }
}