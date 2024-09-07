using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloVeiculo;

public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
{
    public void Configure(EntityTypeBuilder<Automovel> builder)
    {
        builder.ToTable("TBAutomovel");

        builder.Property(v => v.Id)
            .HasColumnType("int")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(v => v.Modelo)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.Marca)
            .HasColumnType("varchar(100)")
            .IsRequired();

        builder.Property(v => v.TipoCombustivel)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(v => v.CapacidadeTanque)
            .HasColumnType("int")
            .IsRequired();

        builder.Property(v => v.Foto)
            .HasColumnType("varbinary(max)")
            .HasDefaultValue(Array.Empty<byte>());

        builder.Property(v => v.GrupoAutomovelId)
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(v => v.GrupoAutomovel)
            .WithMany(g => g.Automoveis)
            .HasForeignKey(v => v.GrupoAutomovelId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
