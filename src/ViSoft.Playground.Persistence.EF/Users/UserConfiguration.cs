using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ViSoft.Playground.Domain.Users;

namespace ViSoft.Playground.Persistence.EF.Users
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(user => user.Id);

            builder
                .Property(user => user.EmailAddress)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(user => user.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(user => user.LastName)
                .HasMaxLength(100);

            builder
                .HasIndex(user => user.EmailAddress)
                .IsUnique();
        }
    }
}
