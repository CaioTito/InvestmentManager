using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentos.Infra.Context.Configurations
{
    public class UserProductsConfiguration : IEntityTypeConfiguration<UserProducts>
    {
        public void Configure(EntityTypeBuilder<UserProducts> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
               .HasOne(x => x.Product)
               .WithMany(x => x.UserProducts)
               .HasConstraintName("FK_UserProducts_ProductId")
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.UserProducts)
                .HasConstraintName("FK_UserProducts_UserId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
