using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class LoanViewModel
{
    public LoanViewModel(Guid id, string bookTitle, string userName, bool bookReturned, DateTime loanDate)
    {
        Id = id;
        BookTitle = bookTitle;
        UserName = userName;
        BookReturned = bookReturned;
        LoanDate = loanDate;
    }

    public Guid Id { get; private set; }
    public string BookTitle { get; private set; }
    public string UserName { get; private set; }
    private bool BookReturned { get; set; }
    public DateTime LoanDate { get; private set; }

    public static LoanViewModel FromEntity(Loan loan)
    {
        return new(loan.Id, loan.Book.Title, loan.User.Name, loan.BookReturned ,loan.LoanDate);
    }
}