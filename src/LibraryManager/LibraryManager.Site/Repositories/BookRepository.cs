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

    public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<List<BookViewModel>>.Error(error);
            }

            var books = await response.Content.ReadFromJsonAsync<List<BookViewModel>>();
            return ResultViewModel<List<BookViewModel>>.Success(books!);
        }
        catch (Exception e)
        {
            return ResultViewModel<List<BookViewModel>>.Error(e.Message);
        }
    }

    public async Task<ResultViewModel<BookViewModel>> GetBookById(Guid id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{BaseUrl}/books/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<BookViewModel>.Error(error);
            }

            var book = await response.Content.ReadFromJsonAsync<BookViewModel>();
            return ResultViewModel<BookViewModel>.Success(book!);
        }
        catch (Exception e)
        {
            return ResultViewModel<BookViewModel>.Error(e.Message);
        }
    }

    public async Task<ResultViewModel<Guid>> Add(BookCreateModel book)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/books", book);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel<Guid>.Error(error);
            }

            var guid = await response.Content.ReadFromJsonAsync<Guid>();
            return ResultViewModel<Guid>.Success(guid);
        }
        catch (Exception e)
        {
            return ResultViewModel<Guid>.Error(e.Message);
        }
    }

    public async Task<ResultViewModel> Update(BookUpdateModel book)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/books/{book.Id}", book);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel.Error(error);
            }

            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error(e.Message);
        }
    }

    public async Task<ResultViewModel> Delete(Guid id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/books/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return ResultViewModel.Error(error);
            }

            return ResultViewModel.Success();
        }
        catch (Exception e)
        {
            return ResultViewModel.Error(e.Message);
        }
    }
}