using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleItemConfiguration : IEntityTypeConfiguration<SaleItem>
{
    public void Configure(EntityTypeBuilder<SaleItem> builder)
    {
        builder.ToTable("SaleItems");

        builder.HasKey(si => new { si.SaleId, si.ProductId });

        builder.Property(si => si.Quantity).IsRequired();
        builder.Property(si => si.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(si => si.Discount).IsRequired().HasColumnType("decimal(4,2)");
        builder.Property(si => si.Total).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(si => si.Product)
               .WithMany()
               .HasForeignKey(si => si.ProductId);
    }
}




