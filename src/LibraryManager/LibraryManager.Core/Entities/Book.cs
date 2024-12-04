using LibraryManager.Core.Enums;

namespace LibraryManager.Core.Entities;

public class Book : BaseEntity
{
    protected Book() {}
    public Book(string title, string author, string isbn, int publicationYear,string imageUrl) : base()
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
        Status = BookStatus.Available;
        ImageUrl = imageUrl;
        Loans = [];
    }


    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublicationYear { get; private set; }
    public BookStatus Status { get; private set; }
    public string ImageUrl { get; private set; }
    
    public List<Loan> Loans { get; private set; }

    public void ToLoan()
    {
        if (Status == BookStatus.Available)
        {
            Status = BookStatus.Borrowed;
        }
    }

    public void ToArchive()
    {
        if (Status == BookStatus.Available)
        {
            Status = BookStatus.Archived;
        }
    }

    public void ToAvaliable() => Status = BookStatus.Available;

    public void Update(string title, string author, string isbn, int publicationYear, string imageUrl)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        PublicationYear = publicationYear;
        ImageUrl = imageUrl;
    }
}