namespace LibraryManager.Core.Services;

public interface IAuthService
{
    string GenerateJwtToken(Guid guid,string name ,string email, string role);
    string ComputeSha256Hash(string password);
}