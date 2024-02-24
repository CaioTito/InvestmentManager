using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentos.Infra.Context.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasMany(p => p.Products)
                .WithMany(u=> u.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserProducts",
                    user => user.HasOne<Products>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserProducts_UserId")
                        .OnDelete(DeleteBehavior.Restrict),
                    product => product.HasOne<Users>()
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_UserProducts_ProductId")
                        .OnDelete(DeleteBehavior.Restrict));

        }
    }
}
