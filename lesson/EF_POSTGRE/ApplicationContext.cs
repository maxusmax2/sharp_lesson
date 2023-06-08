using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        Database.EnsureCreated();
       
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Login> Logins { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Page> Pages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=EF_POSTGRE_DB;Username=postgres;Password=82468246");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Role>().HasData(
            new Role(1, "ADMIN"),
            new Role(2, "SEO"),
            new Role(3, "Manager")
        );
        modelBuilder.Entity<User>()
            .HasMany(u => u.Roles)
            .WithMany(r => r.Users);
        modelBuilder.Entity<Page>()
           .HasMany(p => p.AllowedUsers)
           .WithMany( u => u.AllowedPages);
        modelBuilder.Entity<Page>()
           .HasMany(p => p.AllowedRoles)
        .WithMany(r => r.AllowedPages);
    }
}

