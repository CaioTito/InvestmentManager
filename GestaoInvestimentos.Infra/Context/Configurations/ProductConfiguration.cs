using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentos.Infra.Context.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasConstraintName("FK_Products_Category")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
