using ProjectManagement.DataAccess.Entities;

namespace ProjectManagement.DataAccess.Repositories.Tasks;

public interface ITasksRepository
{
    public Task<IEnumerable<ProjectTaskEntity>> GetAll();

    public Task<ProjectTaskEntity?> GetById(Guid id);

    public Task<IEnumerable<ProjectTaskEntity>> GetByProjectId(Guid projectId);
    
    public Task<ProjectTaskEntity?> Create(ProjectTaskEntity projectTaskEntity);

    public Task<ProjectTaskEntity?> Update(ProjectTaskEntity projectTaskEntity);

    public Task Delete(Guid id);
}