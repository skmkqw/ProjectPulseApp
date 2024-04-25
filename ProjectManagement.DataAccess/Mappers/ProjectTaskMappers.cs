using ProjectManagement.Core.Models;
using ProjectManagement.DataAccess.DTOs.Tasks;
using ProjectManagement.DataAccess.Entities;

namespace ProjectManagement.DataAccess.Mappers;

public static class ProjectTaskMappers
{
    public static ProjectTaskEntity FromDtoToTaskEntity(this CreateTaskDto createTaskDto)
    {
        return new ProjectTaskEntity()
        {
            Title = createTaskDto.Title,
            Description = createTaskDto.Description,
        };
    }
    
    public static TaskDto FromTaskModelToDto(this ProjectTask task)
    {
        return new TaskDto()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            ProjectId = task.ProjectId,
            AssignedUserId = task.AssignedUserId,
            Status = task.Status
        };
    }
    
    public static ProjectTask ToTaskModel(this ProjectTaskEntity taskEntity)
    {
        return new ProjectTask()
        {
            Id = taskEntity.Id,
            Title = taskEntity.Title,
            Description = taskEntity.Description,
            ProjectId = taskEntity.ProjectId,
            AssignedUserId = taskEntity.AssignedUserId,
            Status = taskEntity.Status
        };
    }
    
    public static ProjectTaskEntity ToTaskEntity(this ProjectTask task)
    {
        return new ProjectTaskEntity()
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            ProjectId = task.ProjectId,
            AssignedUserId = task.AssignedUserId
        };
    }
}