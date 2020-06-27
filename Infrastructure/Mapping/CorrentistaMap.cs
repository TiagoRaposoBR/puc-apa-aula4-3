using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping
{
    public class CorrentistaMap : IEntityTypeConfiguration<Correntista>
    {
        public void Configure(EntityTypeBuilder<Correntista> builder)
        {
            builder.ToTable("Correntista");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(c => c.Cpf)
                .IsRequired()
                .HasColumnName("Cpf");

            builder.Property(c => c.Telefone)
                .IsRequired()
                .HasColumnName("Telefone");

            builder.Property(c => c.Endereco)
                .IsRequired()
                .HasColumnName("Endereco");

            builder.Property(c => c.Conta)
                .HasColumnName("Conta");
        }
    }
}