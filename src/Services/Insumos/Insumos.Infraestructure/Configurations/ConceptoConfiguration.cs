using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Insumos.Domain.Entities;

namespace Insumos.Infrastructure.Configurations;

internal sealed class ConceptoConfiguration : IEntityTypeConfiguration<Concepto>
{
    public void Configure(EntityTypeBuilder<Concepto> builder)
    {
        builder.ToTable("Concepto");

        builder.HasKey(concepto => concepto.ConceptoId);

        builder.Property(concepto => concepto.Descripcion).HasMaxLength(50);

        builder.Property(concepto => concepto.FechaAlta).IsRequired();
    }
}