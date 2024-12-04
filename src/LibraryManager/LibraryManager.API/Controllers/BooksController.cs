using LibraryManager.Application.Commands.BookCommands.ArchiveBook;
using LibraryManager.Application.Commands.BookCommands.AvailableBook;
using LibraryManager.Application.Commands.BookCommands.DeleteBook;
using LibraryManager.Application.Commands.BookCommands.InsertBook;
using LibraryManager.Application.Commands.BookCommands.UpdateBook;
using LibraryManager.Application.Queries.BookQueries.GetAllBooks;
using LibraryManager.Application.Queries.BookQueries.GetByIdBook;
using LibraryManager.Core.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController(IBookRepository repository,IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetAllBooksQuery());
        
        if (!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetByIdBookQuery(id));
        
        if (!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertBookCommand command)
    {
        var result = await mediator.Send(command);
        
        if(!result.IsSuccess) return BadRequest(result.Message);

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateBookCommand command)
    {
       var result = await mediator.Send(command);
       
       if(!result.IsSuccess) return BadRequest(result.Message);
       
       return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteBookCommand(id));
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result);
    }

    [HttpPost("{id:guid}/archive")]
    public async Task<IActionResult> Archive(Guid id)
    {
        var result = await mediator.Send(new ArchiveBookCommand(id));
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(); 
    }
    
    [HttpPost("{id:guid}/available")]
    public async Task<IActionResult> Available(Guid id)
    {
        var result = await mediator.Send(new AvailableBookCommand(id));
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(); 
    }
}