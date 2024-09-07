using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;

public class RepositorioGrupoAutomovelEmOrm : RepositorioBaseEmOrm<GrupoAutomovel>, IRepositorioGrupoAutomovel
{
    public RepositorioGrupoAutomovelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<GrupoAutomovel> ObterRegistros()
    {
        return dbContext.GrupoAutomovel;
    }
}
