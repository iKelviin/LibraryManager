using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Models;

public class UserDetailsViewModel
{
    public UserDetailsViewModel(Guid id, string name, string email, bool active, List<LoanViewModel> loans)
    {
        Id = id;
        Name = name;
        Email = email;
        Active = active;
        Loans = loans;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Active { get; private set; }
    public List<LoanViewModel> Loans { get; private set; }
    
    public static UserDetailsViewModel FromEntity(User user)
    {
        return new(user.Id, user.Name, user.Email, user.Active, user.Loans.Select(LoanViewModel.FromEntity).ToList());
    } 
}