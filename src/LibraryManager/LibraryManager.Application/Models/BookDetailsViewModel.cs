using LibraryManager.Core.Entities;
using LibraryManager.Core.Enums;

namespace LibraryManager.Application.Models;

public class BookDetailsViewModel
{
    public BookDetailsViewModel(Guid id, string title, string author, string isbn, int publicationYear, BookStatus status, string imageUrl)
    {
        Id = id;
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
        Status = status.ToString();
        ImageUrl = imageUrl;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    public string Status { get; private set; }
    public string ImageUrl { get; private set; }

    public static BookDetailsViewModel FromEntity(Book book)
    {
        return new(book.Id, book.Title,book.Author, book.ISBN, book.PublicationYear, book.Status,book.ImageUrl);
    }
}