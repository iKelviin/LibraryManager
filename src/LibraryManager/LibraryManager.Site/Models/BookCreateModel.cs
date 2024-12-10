namespace LibraryManager.Site.Models;

public class BookCreateModel
{
    public BookCreateModel(string title, string author, string imageUrl, int publicationYear, string isbn)
    {
        Title = title;
        Author = author;
        ImageUrl = imageUrl;
        PublicationYear = publicationYear;
        ISBN = isbn;
    }

    public string Title { get; set; }
    public string Author { get; set; }
    public string ImageUrl { get; set; }
    public int PublicationYear { get; set; } 
    public string ISBN { get; set; } 
}