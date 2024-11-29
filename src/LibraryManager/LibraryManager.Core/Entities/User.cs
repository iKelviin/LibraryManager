namespace LibraryManager.Core.Entities;

public class User : BaseEntity
{
    protected User() { }
    public User(string name, string email) : base()
    {
        Name = name;
        Email = email;
        Active = true;
        Loans = [];
    }

    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public List<Loan> Loans { get; private set; }
    
    public void SetAsInactive() => Active = false;
}