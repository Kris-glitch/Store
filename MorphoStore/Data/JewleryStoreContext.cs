using Microsoft.EntityFrameworkCore;
using MorphoStore.Entities;

namespace MorphoStore.Data;

public class JewleryStoreContext(DbContextOptions<JewleryStoreContext> options) 
: DbContext(options)
{
    public DbSet<Jewlery> Jewlery => Set<Jewlery>();
    public DbSet<Category> Category => Set<Category>();
    public DbSet<Collection> Collection => Set<Collection>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new {Id = 1, Name = "Earings"},
            new {Id = 2, Name = "Bracelets"},
            new {Id = 3, Name = "Rings"},
            new {Id = 4, Name = "Tiaras"},
            new {Id = 5, Name = "Necklaces"},
            new {Id = 6, Name = "Brooches"},
            new {Id = 7, Name = "Other"}
        );
    }
}
