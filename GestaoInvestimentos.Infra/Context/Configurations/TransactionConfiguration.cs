using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoInvestimentos.Infra.Context.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transactions>
    {
        public void Configure(EntityTypeBuilder<Transactions> builder)
        {
            builder
               .HasKey(p => p.Id);

            builder
                .HasOne(x => x.Product)
                .WithMany(x => x.Transactions)
                .HasConstraintName("FK_Transactions_ProductId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasConstraintName("FK_Transactions_UserId")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.OperationType)
                .WithMany(x => x.Transactions)
                .HasConstraintName("FK_Transactions_OperationId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
