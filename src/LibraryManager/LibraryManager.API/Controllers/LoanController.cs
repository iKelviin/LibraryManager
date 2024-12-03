using LibraryManager.Application.Models;
using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;


[ApiController]
[Route("api/loans")]
public class LoanController(ILoanRepository repository, IBookRepository bookRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var loans = await repository.GetAllAsync();
        var model = loans.Select(LoanViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var loan = await repository.GetByIdAsync(id);
        var model = LoanDetailsViewModel.FromEntity(loan);
        return Ok(model);
    }

    [HttpGet("by-user/{id}")]
    public async Task<IActionResult> GetByUser(Guid id)
    {
        var loans = await repository.GetAllByUserIdAsync(id);
        var model = loans.Select(LoanDetailsViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post(LoanInputModel request)
    {
        var book = await bookRepository.GetByIdAsync(request.IdBook);
        book.ToLoan();
        await bookRepository.UpdateAsync(book);

        var loan = request.ToEntity();
        var result = await repository.AddAsync(loan);

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ReturnBook(UpdateLoanInputModel request)
    {
        var loan = await repository.GetByIdAsync(request.Id);
        loan.SetAsReturned();
        await repository.UpdateAsync(loan);
        
        var book = await bookRepository.GetByIdAsync(request.IdBook);
        book.ToAvaliable();
        await bookRepository.UpdateAsync(book);
        
        return Ok($"Book returned! Days overdue: {loan.OverdueDays().ToString()}");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var loan = await repository.GetByIdAsync(id);
        loan.SetAsDeleted();
        await repository.UpdateAsync(loan);
        
        var book = await bookRepository.GetByIdAsync(loan.IdBook);
        book.ToAvaliable();
        await bookRepository.UpdateAsync(book);
        
        return NoContent();
    }
}