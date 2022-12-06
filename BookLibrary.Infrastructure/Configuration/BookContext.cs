namespace BookLibrary.Infrastructure.Configuration;

using BookLibrary.Core.Authors;
using BookLibrary.Core.Books;
using BookLibrary.Core.Categories;
using Microsoft.EntityFrameworkCore;

internal sealed class BookContext : DbContext
{
    private readonly string _connectionString;

    public BookContext(InfrastructureSettings settings)
    {
        _connectionString = settings.Database.ConnectionString;
    }

    public DbSet<Book> Books { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Books");

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Books");

            entity.HasKey(e => e.Id);

            entity.HasOne(e => e.Category).WithOne().HasForeignKey<Category>(e => e.Id);
            entity.HasMany(e => e.Authors).WithOne().IsRequired();

            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Type).IsRequired();
            entity.Property(e => e.Publisher).IsRequired();
            entity.Property(e => e.Isbn).IsRequired();
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Categories");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Author>(entity =>
        {
            entity.ToTable("Authors");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name).IsRequired();
        });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
