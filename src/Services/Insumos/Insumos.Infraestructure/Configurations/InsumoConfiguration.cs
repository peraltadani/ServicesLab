using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Insumos.Domain.Entities;

namespace Insumos.Infrastructure.Configurations;

internal sealed class InsumoConfiguration : IEntityTypeConfiguration<Insumo>
{
    public void Configure(EntityTypeBuilder<Insumo> builder)
    {
        builder.ToTable("Insumo");

        builder.HasKey(insumo => insumo.InsumoId);

        builder.Property(insumo => insumo.Descripcion).HasMaxLength(100);

        builder.Property(insumo => insumo.UnidadMedidaId).IsRequired();

        builder.Property(insumo => insumo.FechaAlta).IsRequired();
    }
}