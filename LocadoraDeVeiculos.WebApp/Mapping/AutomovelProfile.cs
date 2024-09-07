using AutoMapper;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.WebApp.Mapping.Resolvers;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping;

public class AutomovelProfile : Profile
{
    public AutomovelProfile()
    {
        CreateMap<InserirAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

        CreateMap<EditarAutomovelViewModel, Automovel>()
            .ForMember(dest => dest.Foto, opt => opt.MapFrom<FotoValueResolver>());

        CreateMap<Automovel, ListarAutomovelViewModel>()
            .ForMember(
                dest => dest.GrupoVeiculos,
                opt => opt.MapFrom(src => src.GrupoAutomovel!.Nome)
            );

        CreateMap<Automovel, DetalhesAutomovelViewModel>()
            .ForMember(dest => dest.GrupoAutomovel, opt => opt.MapFrom(src => src.GrupoAutomovel!.Nome));

        CreateMap<Automovel, EditarAutomovelViewModel>()
            .ForMember(v => v.Foto, opt => opt.Ignore())
            .ForMember(v => v.GruposAutomovel, opt => opt.MapFrom<GrupoAutomovelValueResolver>());
    }
}