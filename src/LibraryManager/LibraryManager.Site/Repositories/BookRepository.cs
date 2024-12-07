using System.Net.Http.Json;
using LibraryManager.Site.Models;
using LibraryManager.Site.Repositories.Interfaces;

namespace LibraryManager.Site.Repositories;

public class BookRepository : IBookRepository
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://localhost:7275/api";

    public BookRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<BookViewModel>?> GetAllBooks()
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/books");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<BookViewModel>?>();
        }

        return null;
    }

    public async Task<BookViewModel?> GetBookById(Guid id)
    {
        var response = await _httpClient.GetAsync($"{BaseUrl}/books/{id}");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<BookViewModel?>();
        }
        return null;
    }

    public async Task<Guid> Add(BookViewModel book)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/books", book);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Guid>();
        }
        return Guid.Empty;
    }
}