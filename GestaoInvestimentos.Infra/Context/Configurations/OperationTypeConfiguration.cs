using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentos.Infra.Context.Configurations
{
    public class OperationTypeConfiguration : IEntityTypeConfiguration<OperationType>
    {
        public void Configure(EntityTypeBuilder<OperationType> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .HasMany(u => u.Users)
                .WithMany(p => p.OperationTypes)
                .UsingEntity<Dictionary<string, object>>(
                    "UserTransactions",
                    operationType => operationType.HasOne<Users>()
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .HasConstraintName("FK_UserTransactions_OperationId")
                        .OnDelete(DeleteBehavior.Restrict),
                    product => product.HasOne<OperationType>()
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_UserTransactions_ProductId")
                        .OnDelete(DeleteBehavior.Restrict),
                    user => user.HasOne<Products>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserTransactions_UserId")
                        .OnDelete(DeleteBehavior.Restrict));
        }
    }
}
