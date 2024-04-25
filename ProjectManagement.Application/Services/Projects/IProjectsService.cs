using ProjectManagement.Core.Models;
using ProjectManagement.DataAccess.DTOs.Projects;
using ProjectManagement.DataAccess.DTOs.Tasks;

namespace ProjectManagement.Application.Services.Projects;

public interface IProjectsService
{
    public Task<IEnumerable<Project>> GetAllProjects();
    
    public Task<Project> GetProjectById(Guid id);

    public Task<Project> CreateProject(ProjectFromRequestDto projectFromRequestDto);
    
    public Task<IEnumerable<ProjectTask>> GetTasks(Guid projectId);

    public Task<ProjectTask> AddTask(Guid projectId, CreateTaskDto createTaskDto);
    
    public Task<Project> UpdateProject(Guid id, ProjectFromRequestDto projectFromRequestDto);
    
    public Task DeleteProject(Guid id);
}