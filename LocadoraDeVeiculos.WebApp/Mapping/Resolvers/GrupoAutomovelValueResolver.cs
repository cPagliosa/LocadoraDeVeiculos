using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

public class GrupoAutomovelValueResolver :
    IValueResolver<object, object, IEnumerable<SelectListItem>?>
{
    private readonly IRepositorioGrupoAutomovel repositorioGrupo;

    public GrupoAutomovelValueResolver(IRepositorioGrupoAutomovel repositorioGrupo)
    {
        this.repositorioGrupo = repositorioGrupo;
    }

    public IEnumerable<SelectListItem> Resolve(
        object source,
        object destination,
        IEnumerable<SelectListItem>? destMember,
        ResolutionContext context
    )
    {
        return repositorioGrupo
            .SelecionarTodos()
            .Select(g => new SelectListItem(g.Nome, g.Id.ToString()));
    }
}
