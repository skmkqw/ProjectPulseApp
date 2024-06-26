using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.Services.Users;
using ProjectPulse.DataAccess.DTOs.Users;
using ProjectPulse.DataAccess.Mappers;

namespace ProjectPulse.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    #region GET ENDPOINTS

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
        if (user != null)
        {
            return Ok(user);
        }
    
        return NotFound("User not found");
    }
    
    [HttpGet("{userId}/tasks")]
    public async Task<IActionResult> GetTasks([FromRoute] Guid userId)
    {
        var tasks = await _usersService.GetUserTasks(userId);
        if (tasks != null)
        {
            return Ok(tasks.Select(t => t.ToTaskDto()));
        }
    
        return BadRequest("User not found");
    }
    
    [HttpGet("{userId}/projects")]
    public async Task<IActionResult> GetProjects([FromRoute] Guid userId)
    {
        var projects = await _usersService.GetUserProjects(userId);
        if (projects != null)
        {
            return Ok(projects.Select(p => p.ToProjectDto()));
        }
    
        return BadRequest("User not found");
    }
    
    #endregion GET ENDPOINTS
    
    
    #region PUT ENDPOINTS
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserDto updateUserDto)
    {
        var updatedUser = await _usersService.UpdateUser(id, updateUserDto);
        if (updatedUser != null)
        {
            return Ok(updatedUser);
        }
    
        return NotFound("User not found");
    }
    
    #endregion PUT ENDPOINTS
    
    
    #region DELETE ENDPOINTS
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        bool isDeleted = await _usersService.DeleteUser(id);
        if (isDeleted)
        {
            return NoContent();
        }
    
        return NotFound("User not found");
    }
    
    #endregion DELETE ENDPOINTS
}