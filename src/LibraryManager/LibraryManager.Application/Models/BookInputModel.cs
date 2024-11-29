using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class BookInputModel
{
    public BookInputModel(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    
    public Book ToEntity() => new(Title, Author, ISBN, PublicationYear);
}