namespace LibraryManager.Site.Models;

public class LoanCreateModel
{
    public LoanCreateModel(Guid idUser, Guid idBook)
    {
        IdUser = idUser;
        IdBook = idBook;
    }

    public Guid IdUser { get; set; }
    public Guid IdBook { get; set; }
}