using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class LoanViewModel
{
    public LoanViewModel(Guid id, string bookTitle, Guid idBook, string userName, Guid idUser, bool bookReturned,
        DateTime loanDate,DateTime expectedReturnDate)
    {
        Id = id;
        BookTitle = bookTitle;
        IdBook = idBook;
        IdUser = idUser;
        UserName = userName;
        BookReturned = bookReturned;
        LoanDate = loanDate;
        ExpectedReturnDate = expectedReturnDate;
    }

    public Guid Id { get; private set; }
    public Guid IdBook { get; private set; }
    public Guid IdUser { get; private set; }
    public string BookTitle { get; private set; }
    public string UserName { get; private set; }
    public bool BookReturned { get; set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }

    public static LoanViewModel FromEntity(Loan loan)
    {
        return new(loan.Id, loan.Book.Title, loan.IdBook, loan.User.Name, loan.IdUser, loan.BookReturned,
            loan.LoanDate,loan.ExpectedReturnDate);
    }
}