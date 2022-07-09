using finalPerezAlvarez.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace finalPerezAlvarez.Web.DB.Mapping;

public class CuentaMapping: IEntityTypeConfiguration<Cuenta>
{
    public void Configure(EntityTypeBuilder<Cuenta> builder)
    {
        builder.ToTable("Cuenta", "dbo");
        builder.HasKey(o => o.id);

        builder.HasOne(o => o.TipoCuenta)
            .WithMany()
            .HasForeignKey(o => o.tipoCuentaId);

        //builder.Property(o => o.Nombre).HasField("Name"); // opcional
    }
}