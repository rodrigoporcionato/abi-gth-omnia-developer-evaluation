using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories");

        builder.HasKey(pc => pc.Id);
        builder.Property(pc => pc.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(pc => pc.Name).IsRequired().HasMaxLength(100);
    }
}




