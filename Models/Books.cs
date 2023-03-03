
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookish.Models;

public class Books
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BooksId { get; set; }
    public string BookName { get; set; }
    public string AuthorName { get; set; }
    public int AvailableCopies { get; set; }
    public int TotalNoOfCopies { get; set; }

    public Books(string bookName, string authorName, int totalNoOfCopies)
    {
        BookName = bookName;
        AuthorName = authorName;
        AvailableCopies = totalNoOfCopies;
        TotalNoOfCopies = totalNoOfCopies;
    }
    public Books(){}
}