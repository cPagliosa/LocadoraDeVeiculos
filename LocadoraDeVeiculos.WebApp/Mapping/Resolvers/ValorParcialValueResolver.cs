using AutoMapper;
using LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;
using LocadoraDeVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;
using LocadoraDeVeiculos.WebApp.Models;

namespace LocadoraDeVeiculos.WebApp.Mapping.Resolvers;

public class ValorParcialValueResolver : IValueResolver<Locacao, ConfirmarAberturaLocacaoViewModel, decimal>
{
    private readonly ServicoAutomovel servicoAutomovel;
    private readonly ServicoPlanoCobranca servicoPlano;

    public ValorParcialValueResolver(ServicoAutomovel servicoAutomovel, ServicoPlanoCobranca servicoPlano)
    {
        this.servicoAutomovel = servicoAutomovel;
        this.servicoPlano = servicoPlano;
    }

    public decimal Resolve(
        Locacao source,
        ConfirmarAberturaLocacaoViewModel destination,
        decimal destMember,
        ResolutionContext context
    )
    {
        var veiculo = servicoAutomovel.SelecionarPorId(source.AutomovelId).Value;

        var planoSelecionado = servicoPlano.SelecionarPorIdGrupoVeiculos(veiculo.GrupoAutomovelId).Value;

        return source.CalcularValorParcial(planoSelecionado);
    }
}