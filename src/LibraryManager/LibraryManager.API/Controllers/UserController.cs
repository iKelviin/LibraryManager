using LibraryManager.Application.Models;
using LibraryManager.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUserRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await repository.GetAllAsync();
        var model = result.Select(UserViewModel.FromEntity).ToList();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await repository.GetByIdAsync(id);
        
        if (result is null) return NotFound();
        
        var model = UserDetailsViewModel.FromEntity(result);
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Post(UserInputModel request)
    {
        var user = request.ToEntity();
        var result = await repository.AddAsync(user);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put(UpdateUserInputModel request)
    {
        var user = await repository.GetByIdAsync(request.Id);
        
        if(user is null) return BadRequest();
        
        user.Update(request.Name, request.Email, request.Active);
        await repository.UpdateAsync(user);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await repository.GetByIdAsync(id);
        
        if(user == null) return BadRequest();
        
        user.SetAsDeleted();
        await repository.UpdateAsync(user);
        return Ok();
    }
}