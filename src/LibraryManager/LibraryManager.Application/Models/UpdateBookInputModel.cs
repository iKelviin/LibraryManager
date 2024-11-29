namespace LibraryManager.Application.Models;

public class UpdateBookInputModel
{
    public Guid Id { get;  set; }
    public string Title { get;  set; }
    public string Author { get;  set; }
    public string ISBN { get;  set; }
    public int PublicationYear { get;  set; }
}