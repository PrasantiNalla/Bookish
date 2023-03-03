
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookish.Models;

public class Members
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MembersId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int PhoneNo { get; set; }
    public string EmailId { get; set; }

    public Members(int id, string firstName, string lastName, int phoneNo, string emailId)
    {

        FirstName = firstName;
        LastName = lastName;
        PhoneNo = phoneNo;
        EmailId = emailId;

    }

    public Members() { }
}