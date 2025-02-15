using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ventas.Domain.Entities;

namespace Ventas.Infraestructure.Configurations;

internal sealed class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.ToTable("DetalleVenta");

        builder.HasKey(detalleVenta => detalleVenta.DetalleVentaId);

        builder.Property(detalleVenta => detalleVenta.InsumoId).IsRequired();

        builder.Property(detalleVenta => detalleVenta.Cantidad).IsRequired();
    }
}