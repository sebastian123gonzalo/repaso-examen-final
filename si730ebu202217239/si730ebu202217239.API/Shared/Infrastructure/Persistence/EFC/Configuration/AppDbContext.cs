
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730ebu202217239.inventory.Domain.Model.Aggregates;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Product>().HasKey(p => p.Id);
        builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(p => p.Brand).IsRequired();
        builder.Entity<Product>().Property(p => p.Model).IsRequired();
        builder.Entity<Product>().Property(p => p.SerialNumber).IsRequired();
        builder.Entity<Product>().HasIndex(p => p.SerialNumber).IsUnique();
        builder.Entity<Product>().Ignore(p => p.Status); // Ignore Status property
        builder.Entity<Product>().OwnsOne(p => p.StatusDescription,
            s =>
            {
                s.WithOwner().HasForeignKey("id");
                s.Property(d => d.StatusDescription).HasColumnName("StatusDescription");
            });
        /*
         * HERE BOUNDED CONTEXTS WILL BE REGISTERED
         */
        
        
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}