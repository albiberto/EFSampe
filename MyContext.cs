using EFSample.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFSample;

public class MyContext: DbContext
{
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=192.168.1.8;User ID=keycloak;Password=keycloak;Timeout=30;Database=EFSample");
}