using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Aplicacao.ModuloAutomovel;

public class ServicoAutomovel
{
    private readonly IRepositorioAutomovel repositorioAutomovel;

    public ServicoAutomovel(IRepositorioAutomovel repositorioAutomovel)
    {
        this.repositorioAutomovel = repositorioAutomovel;
    }

    public Result<Automovel> Inserir(Automovel automovel)
    {
        repositorioAutomovel.Inserir(automovel);

        return Result.Ok(automovel);
    }

    public Result<Automovel> Editar(Automovel automovelAtualizado)
    {
        var automovel = repositorioAutomovel.SelecionarPorId(automovelAtualizado.Id);

        if (automovel is null)
            return Result.Fail("O automovel não foi encontrado!");

        automovel.Modelo = automovelAtualizado.Modelo;
        automovel.Marca = automovelAtualizado.Marca;
        automovel.TipoCombustivel = automovelAtualizado.TipoCombustivel;
        automovel.CapacidadeTanque = automovelAtualizado.CapacidadeTanque;
        automovel.GrupoAutomovelId = automovelAtualizado.GrupoAutomovelId;

        repositorioAutomovel.Editar(automovel);
        repositorioAutomovel.Editar(automovel);

        return Result.Ok(automovel);
    }

    public Result<Automovel> Excluir(int veiculoId)
    {
        var automovel = repositorioAutomovel.SelecionarPorId(veiculoId);

        if (automovel is null)
            return Result.Fail("O Automovel não foi encontrado!");

        repositorioAutomovel.Excluir(automovel);

        return Result.Ok(automovel);
    }

    public Result<Automovel> SelecionarPorId(int veiculoId)
    {
        var automovel = repositorioAutomovel.SelecionarPorId(veiculoId);

        if (automovel is null)
            return Result.Fail("O Automovel não foi encontrado!");

        return Result.Ok(automovel);
    }

    public Result<List<Automovel>> SelecionarTodos()
    {
        var automoveis = repositorioAutomovel.SelecionarTodos();

        return Result.Ok(automoveis);
    }
}
