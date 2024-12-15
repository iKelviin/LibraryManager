using LibraryManager.Application.Commands.UserCommands.DeleteUser;
using LibraryManager.Application.Commands.UserCommands.InsertUser;
using LibraryManager.Application.Commands.UserCommands.Login;
using LibraryManager.Application.Commands.UserCommands.UpdateUser;
using LibraryManager.Application.Queries.UserQueries.GetAllUsers;
using LibraryManager.Application.Queries.UserQueries.GetByIdUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/users")]
[Authorize]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetAllUsersQuery());
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetByIdUserQuery(id));
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post(InsertUserCommand command)
    {
        var result = await mediator.Send(command);
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserCommand command)
    {
        var result = await mediator.Send(command);
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteUserCommand(id));
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok();
    }

    [HttpPut("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await mediator.Send(command);
        
        if(!result.IsSuccess) return BadRequest(result.Message);
        
        return Ok(result.Data);
    }
}