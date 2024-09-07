using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel;

public class RepositorioAutomovelEmOrm : RepositorioBaseEmOrm<Automovel>, IRepositorioAutomovel
{
    public RepositorioAutomovelEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<Automovel> ObterRegistros()
    {
        return dbContext.Automoveis;
    }

    public override Automovel? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(v => v.GrupoAutomovel)
            .FirstOrDefault(v => v.Id == id);
    }

    public override List<Automovel> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(v => v.GrupoAutomovel)
            .ToList();
    }
}
