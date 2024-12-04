using LibraryManager.Core.Entities;
using LibraryManager.Core.Enums;

namespace LibraryManager.Application.Models;

public class BookViewModel
{
    public BookViewModel(Guid id, string title, string author,string bookStatus, string imageUrl)
    {
        Id = id;
        Title = title;
        Author = author;
        Status = bookStatus;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string Status { get; private set; }
    public string ImageUrl { get; private set; }

    public static BookViewModel FromEntity(Book book)
    {
        return new(book.Id, book.Title,book.Author, book.Status.ToString(), book.ImageUrl);
    }
}