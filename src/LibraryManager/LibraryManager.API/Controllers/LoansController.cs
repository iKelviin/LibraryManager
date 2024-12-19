using LibraryManager.Application.Commands.LoanCommands.InsertLoan;
using LibraryManager.Application.Commands.LoanCommands.UpdateLoan;
using LibraryManager.Application.Queries.LoanQueries.GetAllLoans;
using LibraryManager.Application.Queries.LoanQueries.GetByIdLoan;
using LibraryManager.Application.Queries.LoanQueries.GetByIdUserLoans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/loans")]
[Authorize]
public class LoansController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetAllLoansQuery());

        if (!result.IsSuccess) return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetByIdLoanQuery(id));

        if (!result.IsSuccess) return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpGet("by-user/{id}")]
    public async Task<IActionResult> GetByUser(Guid id)
    {
        var result = await mediator.Send(new GetByIdUserLoansQuery(id));

        if (!result.IsSuccess) return BadRequest(result.Message);

        return Ok(result.Data);
    }

    [HttpPost]
    public async Task<IActionResult> Post(InsertLoanCommand command)
    {
        var result = await mediator.Send(command);
        
        if (!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

    [HttpPut("{id}/return-book")]
    public async Task<IActionResult> ReturnBook(Guid id)
    {
        var result = await mediator.Send(new UpdateLoanCommand(id));
        
        if (!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

}