using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;

public class MapeadorGrupoAutomovel : IEntityTypeConfiguration<GrupoAutomovel>
{
    public void Configure(EntityTypeBuilder<GrupoAutomovel> builder)
    {
        builder.ToTable("TBGrupoAutomovel");

        builder.Property(g => g.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(g => g.Nome)
            .HasColumnType("varchar(120)")
            .IsRequired();
    }
}