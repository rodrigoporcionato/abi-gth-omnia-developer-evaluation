using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");

        builder.HasKey(s => s.SaleId);

        builder.Property(s => s.SaleNumber).IsRequired();
        builder.Property(s => s.Date).IsRequired();
        builder.Property(s => s.Branch).HasMaxLength(50);
        builder.Property(s => s.TotalAmount).HasColumnType("decimal(18,2)");
        builder.Property(s => s.IsCancelled).IsRequired();

        builder.HasOne(s => s.Customer)
               .WithMany()
               .HasForeignKey(s => s.CustomerId);

        builder.HasMany(s => s.Items)
               .WithOne()
               .HasForeignKey(si => si.SaleId);
    }
}




