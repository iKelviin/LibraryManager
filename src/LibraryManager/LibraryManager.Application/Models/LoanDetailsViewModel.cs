using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class LoanDetailsViewModel
{
    public LoanDetailsViewModel(Guid id, string userName,Guid idUser, string bookTitle, string bookAuthor, int bookPublicationYear,Guid idBook, DateTime loanDate, DateTime expectedReturnDate, bool bookReturned)
    {
        Id = id;
        UserName = userName;
        IdUser = idUser;
        BookTitle = bookTitle;
        BookAuthor = bookAuthor;
        BookPublicationYear = bookPublicationYear;
        IdBook = idBook;
        LoanDate = loanDate;
        ExpectedReturnDate = expectedReturnDate;
        BookReturned = bookReturned;
    }


    public Guid Id { get; private set; }
    public Guid IdBook { get; private set; }
    public Guid IdUser { get; private set; }
    public string UserName { get; private set; }
    public string BookTitle { get; private set; }
    public string BookAuthor { get; private set; }
    public int BookPublicationYear { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    public bool BookReturned { get; private set; }

    public static LoanDetailsViewModel FromEntity(Loan loan)
    {
        return new(loan.Id, loan.User.Name,loan.IdUser, loan.Book.Title,loan.Book.Author,loan.Book.PublicationYear ,loan.IdBook,loan.LoanDate, loan.ExpectedReturnDate,loan.BookReturned);
    }
}