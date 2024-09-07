using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

public class VeiculosValueResolver : IValueResolver<Locacao, FormularioLocacaoViewModel, IEnumerable<SelectListItem>?>
{
    private readonly ServicoAutomovel _servicoAutomovel;

    public VeiculosValueResolver(ServicoAutomovel servicoAutomovel)
    {
        _servicoAutomovel = servicoAutomovel;
    }

    public IEnumerable<SelectListItem>? Resolve(Locacao source, FormularioLocacaoViewModel destination, IEnumerable<SelectListItem>? destMember,
        ResolutionContext context)
    {
        if (destination is RealizarDevolucaoViewModel or ConfirmarAberturaLocacaoViewModel or ConfirmarDevolucaoLocacaoViewModel)
        {
            var veiculoSelecionado = _servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

            return [new SelectListItem(veiculoSelecionado!.Modelo, veiculoSelecionado.Id.ToString())];
        }

        return _servicoAutomovel
            .SelecionarTodos()
            .Value
            .Select(v => new SelectListItem(v.Modelo, v.Id.ToString()));
    }
}