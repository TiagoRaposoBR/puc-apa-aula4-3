using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("ContaCorrente");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.correntistaId)
                .IsRequired()
                .HasColumnName("CorrentistaId");

            builder.Property(c => c.Saldo)
                .IsRequired()
                .HasColumnName("Saldo");

            builder.Property(c => c.LimiteCredito)
                .IsRequired()
                .HasColumnName("LimiteCredito");
        }
    }
}