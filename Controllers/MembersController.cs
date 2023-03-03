using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using bookish.Models;
using bookish.Services;
namespace bookish.Controllers;

public class MembersController : Controller
{

    private readonly IMemberActions _IMemberActions;
    public MembersController(IMemberActions memberAction)
    {
        _IMemberActions = memberAction;
    }

    [Route("Members")]
    public IActionResult Members()
    {
        var memberList = _IMemberActions.MembersList();
        return View(memberList);
    }

    [HttpGet]
    public IActionResult AddMember()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitAddMember(Members member)
    {
        _IMemberActions.SubmitAddMember(member);
        return RedirectToAction("Members");
    }

}