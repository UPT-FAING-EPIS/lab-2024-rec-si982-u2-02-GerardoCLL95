using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Financiera.WebApp.Modelos;
namespace Financiera.WebApp.Mapeos;
public class MovimientoCuentaConfiguracion : IEntityTypeConfiguration<MovimientoCuenta>
{
    public void Configure(EntityTypeBuilder<MovimientoCuenta> builder)
    {
        builder.ToTable("MOVIMIENTOS_CUENTA");
        builder.HasKey(c => c.NumeroMovimiento);
        builder.Property(c => c.NumeroMovimiento).HasColumnName("NUM_MOVIMIENTO").IsRequired();
        builder.Property(c => c.IdCuenta).HasColumnName("ID_CUENTA").IsRequired();
        builder.Property(c => c.IdTipoMovimiento).HasColumnName("ID_TIPO");
        builder.Property(c => c.MontoMovimiento).HasColumnName("MON_MOVIMIENTO").IsRequired();
        builder.HasOne(c => c.Cuenta).WithMany().HasForeignKey(f => f.IdCuenta);
        builder.HasOne(c => c.Tipo).WithMany().HasForeignKey(f => f.IdTipoMovimiento);
    }
}