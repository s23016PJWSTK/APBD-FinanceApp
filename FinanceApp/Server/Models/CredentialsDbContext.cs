using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Server.Models
{
    public class CredentialsDbContext : DbContext
    {
        public DbSet<UserCredentials> UsersCredentials { get; set; }
        public CredentialsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredentials>(e =>
            {
                e.ToTable("UserCredentials");
                e.HasKey(e => e.Email);
                e.Property(e => e.Password).IsRequired();
            });
        }
      }
}
