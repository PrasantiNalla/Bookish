using Microsoft.AspNetCore.Mvc;
using bookish;
using bookish.Models;

namespace bookish.Services;

public interface IMemberActions
{
    List<Members> MembersList();
    void SubmitAddMember(Members member);
}

// Class - To implement the interfaces
public class MemberActions : IMemberActions
{
    public List<Members> MembersList(){
        var context = new BookishContext();
        var memberList = context.Members.ToList();
        return memberList;
    }
    public void SubmitAddMember(Members member){
         using (var context = new BookishContext())
        {
            var newMember = new Members()
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNo = member.PhoneNo,
                EmailId = member.EmailId,

            };
            context.Members.Add(newMember);
            context.SaveChanges();
        }
    }


}