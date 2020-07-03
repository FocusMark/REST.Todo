using FocusMark.Tasks.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FocusMark.Tasks.Infrastructure.Persistence.Configurations
{
    public class TaskListConfiguration : IEntityTypeConfiguration<TaskList>
    {
        public void Configure(EntityTypeBuilder<TaskList> builder)
        {
            builder.Property(list => list.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(list => list.CreatedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(list => list.LastModifiedBy)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(list => list.Kind)
                .IsRequired();

            builder.Property(list => list.Path)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(list => list.PercentComplete)
                .IsRequired();

            builder.Property(list => list.Status)
                .IsRequired();

            builder.Property(list => list.UserId)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
