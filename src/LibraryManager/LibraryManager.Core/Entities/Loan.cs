namespace LibraryManager.Core.Entities;

public class Loan : BaseEntity
{
    protected Loan() { }

    public Loan(Guid idUser, Guid idBook) : base()
    {
        IdUser = idUser;
        IdBook = idBook;
        LoanDate = DateTime.Now;
        BookReturned = false;
        ExpectedReturnDate = LoanDate.AddDays(14);
    }


    public Guid IdUser { get; private set; }
    public User User { get; private set; }
    public Guid IdBook { get; private set; }
    public Book Book { get; private set; }
    private bool BookReturned { get; set; }
    public DateTime LoanDate { get; private set; }
    public DateTime ExpectedReturnDate { get; private set; }
    private DateTime ReturnDate { get; set; }

    public void SetAsReturned()
    {
        BookReturned = true;
        ReturnDate = DateTime.Now;
    }

    public int OverdueDays()
    {
        // Se o livro ainda não foi devolvido, pega a data atual
        DateTime actualReturnDate = BookReturned ? ReturnDate : DateTime.Now;

        // Calcula os dias de atraso comparando com a data esperada de devolução
        int daysLate = (actualReturnDate - ExpectedReturnDate).Days;

        // Se o resultado for negativo (não há atraso), retorna 0
        return daysLate > 0 ? daysLate : 0;
    }
}