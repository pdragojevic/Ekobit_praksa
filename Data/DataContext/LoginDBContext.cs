using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DataContext
{
    public class LoginDBContext : DbContext
    {
        public LoginDBContext(DbContextOptions<LoginDBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserName);

                entity.Property(u => u.UserName)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(u => u.Password)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(u => u.FirstName)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(u => u.LastName)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.Property(u => u.ZipCode)
                    .HasMaxLength(5);

                entity.HasOne<City>(u => u.City)
                    .WithMany(c => c.Users)
                    .HasForeignKey(u => u.ZipCode)
                    .OnDelete(DeleteBehavior.NoAction);
            });
            #endregion

            #region City
            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(c => c.ZipCode);

                entity.Property(c => c.ZipCode)
                    .HasMaxLength(5)
                    .IsRequired();

                entity.Property(c => c.CityName)
                    .HasMaxLength(10)
                    .IsRequired();

                entity.HasMany<User>(c => c.Users)
                    .WithOne(u => u.City)
                    .HasForeignKey(u => u.ZipCode)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            #endregion
        }
    }
}
