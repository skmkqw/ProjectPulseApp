using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPI.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<ProjectUser> ProjectUsers { get; set; } = new();
}