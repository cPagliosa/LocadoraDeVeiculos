using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class GrupoAutomovelProfile : Profile
{
    public GrupoAutomovelProfile()
    {
        CreateMap<InserirGrupoAutomovelViewModel, GrupoAutomovel>();
        CreateMap<EditarGrupoAutomovelViewModel, GrupoAutomovel>();

        CreateMap<GrupoAutomovel, ListarGrupoAutomovelViewModel>();
        CreateMap<GrupoAutomovel, DetalhesGrupoAutomovelViewModel>();
        CreateMap<GrupoAutomovel, EditarGrupoAutomovelViewModel>();
    }
}