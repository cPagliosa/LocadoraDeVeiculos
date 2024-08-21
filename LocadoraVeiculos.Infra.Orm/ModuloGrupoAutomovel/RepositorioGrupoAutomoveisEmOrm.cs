using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocadoraVeiculos.Dominio;
using LocadoraVeiculos.Dominio.ModuloGrupoAutomovis;
using LocadoraVeiculos.Infra.Orm.Compartinhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraVeiculos.Infra.Orm.ModuloGrupoAutomovel
{
    public class RepositorioGrupoAutomoveisEmOrm : RepositorioBaseEmOrm<GrupoAutomovel>,IRepositorioGrupoAtomovel
    {
        public RepositorioGrupoAutomoveisEmOrm(LocadoraDbContext dbContext) : base(dbContext)
        {
            
        }

        protected override DbSet<GrupoAutomovel> ObterRegistros()
        {
            return dbContext.GruposAutomoveis;
        }
    }
}
