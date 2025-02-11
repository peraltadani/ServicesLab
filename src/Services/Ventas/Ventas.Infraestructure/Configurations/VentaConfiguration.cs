using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ventas.Domain.Entities;

namespace Ventas.Infraestructure.Configurations;

internal sealed class VentaConfiguration : IEntityTypeConfiguration<Venta>
{
    public void Configure(EntityTypeBuilder<Venta> builder)
    {
        builder.ToTable("Venta");

        builder.HasKey(venta => venta.VentaId);

        builder.Property(venta => venta.FechaVenta).IsRequired();

        builder.Property(venta => venta.ClienteId).IsRequired();

        builder.Property(venta => venta.EstadoVentaId).IsRequired();
    }
}