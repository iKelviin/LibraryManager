using System.Net.Http.Json;
using LibraryManager.Site.Models;
using LibraryManager.Site.Security;

namespace LibraryManager.Site.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7275/api";

    public AuthRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }
    
    public async Task<ResultViewModel<UserViewModel>> Login(User user)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/users/login",user);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<UserViewModel>.Error(error);
            }
            
            var userViewModel = await response.Content.ReadFromJsonAsync<UserViewModel>();

            return ResultViewModel<UserViewModel>.Success(userViewModel!);
        }
        catch (Exception e)
        {
            return ResultViewModel<UserViewModel>.Error(e.Message);
        }
    }
    
    public async Task<ResultViewModel<Guid>> Register(UserCreateModel user)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/users",user);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<Guid>.Error(error);
            }
            
            var result = await response.Content.ReadFromJsonAsync<Guid>();

            return ResultViewModel<Guid>.Success(result!);
        }
        catch (Exception e)
        {
            return ResultViewModel<Guid>.Error(e.Message);
        }
    }

}