﻿using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;

public class RepositorioPlanoCobrancaEmOrm : RepositorioBaseEmOrm<PlanoCobranca>, IRepositorioPlanoCobranca
{
    public RepositorioPlanoCobrancaEmOrm(LocadoraDbContext dbContext) : base(dbContext)
    {
    }

    protected override DbSet<PlanoCobranca> ObterRegistros()
    {
        return dbContext.PlanosCobranca;
    }

    public override PlanoCobranca? SelecionarPorId(int id)
    {
        return ObterRegistros()
            .Include(p => p.GrupoAutomoveis)
            .FirstOrDefault(p => p.Id == id);
    }

    public override List<PlanoCobranca> SelecionarTodos()
    {
        return ObterRegistros()
            .Include(p => p.GrupoAutomoveis)
            .AsNoTracking()
            .ToList();
    }

    public PlanoCobranca? FiltrarPlano(Func<PlanoCobranca, bool> predicate)
    {
        return ObterRegistros()
            .Include(p => p.GrupoAutomoveis)
            .Where(predicate)
            .FirstOrDefault();
    }
}
