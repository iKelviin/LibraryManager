using System.Net.Http.Json;
using LibraryManager.Site.Models;

namespace LibraryManager.Site.Repositories.Interfaces;

public class LoanRepository : ILoanRepository
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7275/api";

    public LoanRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("API");
    }
    public async Task<ResultViewModel<List<LoanViewModel>>> GetAllLoansByUser(Guid idUser)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/loans/by-user/{idUser}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<List<LoanViewModel>>.Error(error);
            }

            var loans = await response.Content.ReadFromJsonAsync<List<LoanViewModel>>();
            return ResultViewModel<List<LoanViewModel>>.Success(loans!);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<LoanViewModel>>.Error(e.Message);
        }
    }

    public async Task<ResultViewModel<string>> ReturnBook(Guid idLoan)
    {
        try
        {
            var response = await _httpClient.PutAsync($"{BaseUrl}/loans/{idLoan}/return-book",null);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<string>.Error(error);
            }
            var result = await response.Content.ReadAsStringAsync();
            return ResultViewModel<string>.Success(result!);
        }
        catch (Exception e)
        {
            return ResultViewModel<string>.Error(e.Message);
        }
    }
}