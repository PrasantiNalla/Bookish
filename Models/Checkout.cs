using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookish.Models;

public class Checkout
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("Members")]
    public int MembersId { get; set; }
    public virtual Members Member { get; set; }

    [ForeignKey("Books")]
    public int BooksId { get; set; }
    public virtual Books Book { get; set; }
    // [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CheckoutDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public bool Returned { get; set; }

    public Checkout()
    {
        CheckoutDate = DateTime.UtcNow.Date;
        ReturnDate = CheckoutDate.AddDays(30);
        Returned = false;
    }
}