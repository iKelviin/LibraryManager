using LibraryManager.Core.Entities;
using LibraryManager.Core.Enums;

namespace LibraryManager.Application.Models;

public class BookViewModel
{
    public BookViewModel(Guid id, string title, string author,string bookStatus)
    {
        Id = id;
        Title = title;
        Author = author;
        BookStatus = bookStatus;
    }

    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string BookStatus { get; private set; }

    public static BookViewModel FromEntity(Book book)
    {
        return new(book.Id, book.Title,book.Author, book.Status.ToString());
    }
}