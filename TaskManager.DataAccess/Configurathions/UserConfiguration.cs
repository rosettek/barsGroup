using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TaskManager.DataAccess.Entities;
using UserAuthentication.Domain.Models;

namespace TaskManager.DataAccess.Configurathions
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(x => x.User_id);
            builder.Property(b => b.Name)
                .HasMaxLength(User.MAX_NAME_LENGHT)
                .IsRequired();

            builder.Property(b => b.Email)
                .HasMaxLength(User.MAX_EMAIL_LENGHT)
                .IsRequired();

            builder.Property(b => b.PasswordHash)
                .IsRequired();

        }
    }
}
