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
        var checkoutList =_ICheckoutActions.Checkout( bookId,  memberId);
        return View(checkoutList);
    }
}