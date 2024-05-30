using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManager.DataAccess.Entities;

namespace TaskManager.DataAccess.Configurathions
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title)
                .HasMaxLength(Domain.Models.Task.MAX_TITLE_LENGHT)
                .IsRequired();

            builder.Property(b => b.Description)
                .HasMaxLength(Domain.Models.Task.MAX_DESCRIPTION_LENGHT)
                .IsRequired();

            builder
                .HasOne(u => u.User)
                .WithMany(t => t.Tasks)
                .HasForeignKey(u => u.User);
        }
    }
}
