namespace LibraryManager.Site.Models;

public class BookUpdateModel
{
    public BookUpdateModel(Guid id, string title, string author, string imageUrl, int publicationYear, string isbn)
    {
        Id = id;
        Title = title;
        Author = author;
        ImageUrl = imageUrl;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ImageUrl { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; } 
}