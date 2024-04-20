using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManagementAPI.Entities;

namespace ProjectManagementAPI.Configurations;

public class ProjectTasksConfiguration : IEntityTypeConfiguration<ProjectTaskEntity>
{
    public void Configure(EntityTypeBuilder<ProjectTaskEntity> builder)
    {
        builder.ToTable("ProjectTasks");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .IsUnicode()
            .HasMaxLength(250);

        builder.Property(t => t.Description)
            .IsUnicode()
            .HasMaxLength(500);

        builder.HasOne(t => t.Project)
            .WithMany(p => p.Tasks)
            .HasForeignKey(t => t.ProjectId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade); 
    }
}