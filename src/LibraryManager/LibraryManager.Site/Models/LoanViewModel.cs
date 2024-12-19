namespace LibraryManager.Site.Models;

public class LoanViewModel
{
    public Guid Id { get;  set; }
    public Guid IdBook { get;  set; }
    public Guid IdUser { get;  set; }
    public string UserName { get;  set; }
    public string BookTitle { get;  set; }
    public string BookAuthor { get;  set; }
    public int BookPublicationYear { get;  set; }
    public DateTime LoanDate { get;  set; }
    public DateTime ExpectedReturnDate { get;  set; }
    public bool BookReturned { get;  set; }
    public string ImageUrl { get; set; }
}