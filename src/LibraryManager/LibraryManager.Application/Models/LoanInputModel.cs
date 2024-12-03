using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class LoanInputModel
{
    public LoanInputModel(Guid idUser, Guid idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
    }

    public Guid IdUser { get; private set; }
    public Guid IdBook { get; private set; }
    
    public Loan ToEntity() => new(IdUser, IdBook);
}