namespace LibraryManager.Core.Entities;

public class User : BaseEntity
{
    protected User() { }
    public User(string name, string email, string password, string role) : base()
    {
        Name = name;
        Email = email;
        Active = true;
        Loans = [];
        Password = password;
        Role = role;
    }
    
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public List<Loan> Loans { get; private set; }
    public string Password { get; private set; }
    public string Role { get; private set; }
    
    public void SetAsInactive() => Active = false;

    public void Update(string name, string email, bool active)
    {
        Name = name;
        Email = email;
        Active = active;
    }
}