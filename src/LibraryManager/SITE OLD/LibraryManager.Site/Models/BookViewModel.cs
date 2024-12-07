namespace LibraryManager.Site.Models;

public class BookViewModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int PublicationYear { get; set; } = 0;
    public string ISBN { get; set; } = string.Empty;
}