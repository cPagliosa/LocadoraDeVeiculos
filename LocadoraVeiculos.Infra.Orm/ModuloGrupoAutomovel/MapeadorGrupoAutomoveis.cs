using LocadoraVeiculos.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomovel;

public class MapeadorGrupoAutomoveis : IEntityTypeConfiguration<GrupoAutomovel>
{
    public void Configure(EntityTypeBuilder<GrupoAutomovel> builder)
    {
        builder.ToTable("TBGrupoAutomoveis");

        builder.Property(g => g.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(g => g.Nome)
            .HasColumnType("varvhar(100)")
            .IsRequired();
    }
}