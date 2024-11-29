using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infrastructure.Persistence;

public class LibraryManagerDbContext : DbContext
{
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<User>(u =>
            {
                u.HasKey(k => k.Id);
                
                u.HasMany(x => x.Loans)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Book>(b =>
            {
                b.HasKey(k => k.Id);
                
                b.HasMany(l => l.Loans)
                    .WithOne(o => o.Book)
                    .HasForeignKey(k => k.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Loan>(l =>
            {
                l.HasKey(k => k.Id);
                
                l.HasOne(u => u.User)
                    .WithMany(u => u.Loans)
                    .HasForeignKey(u => u.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
                
                l.HasOne(b => b.Book)
                    .WithMany(b => b.Loans)
                    .HasForeignKey(b => b.IdBook)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        
        base.OnModelCreating(builder);
    }
    
}