using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Users;
using ProjectManagement.DataAccess.DTOs.Users;
using ProjectManagement.DataAccess.Repositories.Users;

namespace ProjectManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _usersService.GetAllUsers();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var user = await _usersService.GetUserById(id);
        
        if (user == null)
        {
            return NotFound();
        }

        return Ok(user); 
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserFromRequestDto userFromRequest)
    {
        var user = await _usersService.CreateUser(userFromRequest);
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserFromRequestDto userFromRequest)
    {
        try
        {
            await _usersService.UpdateUser(id, userFromRequest);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            await _usersService.DeleteUser(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}