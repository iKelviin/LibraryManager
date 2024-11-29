using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(IBookRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await repository.GetAllAsync();
        var model = result.Select(BookViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await repository.GetByIdAsync(id);
        
        if (result is null) return NotFound();
        
        var model = BookDetailsViewModel.FromEntity(result);
        
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post(BookInputModel request)
    {
        var book = request.ToEntity();
        var result = await repository.AddAsync(book);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateBookInputModel request)
    {
        var book = await repository.GetByIdAsync(request.Id);
        
        if(book is null) return BadRequest();
        
        book.Update(request.Title, request.Author, request.ISBN, request.PublicationYear);
        await repository.UpdateAsync(book);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await repository.GetByIdAsync(id);
        
        if(book == null) return BadRequest();
        
        book.SetAsDeleted();
        await repository.UpdateAsync(book);
        return Ok();
    }

    [HttpPost("{id:guid}/archive")]
    public async Task<IActionResult> Archive(Guid id)
    {
        var book = await repository.GetByIdAsync(id);
        
        if(book == null) return BadRequest();
        
        book.ToArchive();
        await repository.UpdateAsync(book);
        return Ok(); 
    }
    
    [HttpPost("{id:guid}/available")]
    public async Task<IActionResult> Available(Guid id)
    {
        var book = await repository.GetByIdAsync(id);
        
        if(book == null) return BadRequest();
        
        book.ToAvaliable();
        await repository.UpdateAsync(book);
        return Ok(); 
    }
}