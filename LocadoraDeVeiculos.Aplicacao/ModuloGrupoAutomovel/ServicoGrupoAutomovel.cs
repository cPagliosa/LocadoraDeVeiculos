using FluentResults;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Aplicacao.ModuloGrupoAutomovel;

public class ServicoGrupoAutomovel
{
    private readonly IRepositorioGrupoAutomovel repositorioGrupo;

    public ServicoGrupoAutomovel(IRepositorioGrupoAutomovel repositorioGrupo)
    {
        this.repositorioGrupo = repositorioGrupo;
    }

    public Result<GrupoAutomovel> Inserir(GrupoAutomovel grupo)
    {
        repositorioGrupo.Inserir(grupo);

        return Result.Ok(grupo);
    }

    public Result<GrupoAutomovel> Editar(GrupoAutomovel grupoAtualizado)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoAtualizado.Id);

        if (grupo is null)
            return Result.Fail("O grupo não foi encontrado!");

        grupo.Nome = grupoAtualizado.Nome;

        repositorioGrupo.Editar(grupo);

        return Result.Ok(grupo);
    }

    public Result<GrupoAutomovel> Excluir(int grupoId)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoId);

        if (grupo is null)
            return Result.Fail("O grupo não foi encontrado!");

        repositorioGrupo.Excluir(grupo);

        return Result.Ok(grupo);
    }

    public Result<GrupoAutomovel> SelecionarPorId(int grupoId)
    {
        var grupo = repositorioGrupo.SelecionarPorId(grupoId);

        if (grupo is null)
            return Result.Fail("O grupo não foi encontrado!");

        return Result.Ok(grupo);
    }

    public Result<List<GrupoAutomovel>> SelecionarTodos()
    {
        var grupos = repositorioGrupo.SelecionarTodos();

        return Result.Ok(grupos);
    }
}
