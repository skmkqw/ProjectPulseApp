namespace ProjectManagement.DataAccess.DTOs.Users;

public class CreateUserDto
{ 
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    
    public string Login { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}