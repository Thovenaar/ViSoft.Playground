using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ViSoft.Playground.Persistence.EF.Models
{
    [Table("Users")]
    internal class User
    {
        [Key] public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public static void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(key => key.Id).HasDefaultValueSql("NEWID()");
        }
    }
}
