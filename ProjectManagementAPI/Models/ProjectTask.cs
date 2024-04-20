using System.ComponentModel.DataAnnotations;

namespace ProjectManagementAPI.Models;

public class ProjectTask
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Guid ProjectId { get; set; }
    
    public Project Project { get; set; }
}