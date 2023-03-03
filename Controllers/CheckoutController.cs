using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;

namespace bookish.Controllers;

public class CheckoutController : Controller
{
    private readonly ICheckoutActions _ICheckoutActions;
    public CheckoutController(ICheckoutActions chcekoutAction)
    {
        _ICheckoutActions = chcekoutAction;
    }

    [HttpGet]
    public IActionResult CheckoutBook()
    {
        var listViewModel = _ICheckoutActions.ViewCheckout();
        return View(listViewModel);
    }

    [Route("ListCheckouts")]
    [HttpPost]
    public IActionResult ListCheckouts(int bookId, int memberId)
    {
        var checkoutList = _ICheckoutActions.Checkout(bookId, memberId);
        return View(checkoutList);
    }

    // [Route("DispalyCheckoutList")]
    // [HttpPost]
    public IActionResult DispalyCheckoutList()
    {
        var checkoutList = _ICheckoutActions.Checkout(0, 0);
        return View(checkoutList);
    }

    [HttpPost]
    public IActionResult CheckIn(int bookId)
    {
        var bookName = _ICheckoutActions.CheckInBook(bookId);
        return View("CheckIn", bookName);
    }
}