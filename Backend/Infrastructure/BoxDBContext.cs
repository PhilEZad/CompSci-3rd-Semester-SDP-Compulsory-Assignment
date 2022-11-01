using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class BoxDBContext : DbContext
{
    
    public BoxDBContext(DbContextOptions<BoxDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Box> BoxTable { get; set; }
}