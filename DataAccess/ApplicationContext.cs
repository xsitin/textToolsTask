using DataAccess.models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class ApplicationContext : DbContext
{

    public DbSet<Word> Words { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Word>(entity =>
        {
            entity.HasKey(e => e.word);
            entity.Property(e => e.word).HasMaxLength(20);
            entity.Property(e => e.count).HasDefaultValue(0);
        });
    }
}