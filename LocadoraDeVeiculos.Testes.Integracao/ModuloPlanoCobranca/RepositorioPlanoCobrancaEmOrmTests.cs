using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloPlanoCobranca;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloPlanoCobranca;

[TestClass]
[TestCategory("Integração")]
public class RepositorioPlanoCobrancaEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioPlanoCobrancaEmOrm repositorio;
    private RepositorioGrupoAutomovelEmOrm repositorioGrupos;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.PlanosCobranca.RemoveRange(dbContext.PlanosCobranca);
        dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
        dbContext.GrupoAutomovel.RemoveRange(dbContext.GrupoAutomovel);

        repositorio = new RepositorioPlanoCobrancaEmOrm(dbContext);
        repositorioGrupos = new RepositorioGrupoAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorio.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupos.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_PlanoCobranca()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomovelId = grupo.Id)
            .Build();

        repositorio.Inserir(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_PlanoCobranca()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomovelId = grupo.Id)
            .Persist();

        planoCobranca.PrecoDiarioPlanoDiario = 200.0m;

        repositorio.Editar(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        Assert.IsNotNull(planoCobrancaSelecionado);
        Assert.AreEqual(planoCobranca, planoCobrancaSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_PlanoCobranca()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var planoCobranca = Builder<PlanoCobranca>
            .CreateNew()
            .With(p => p.Id = 0)
            .With(p => p.GrupoAutomovelId = grupo.Id)
            .Persist();

        repositorio.Excluir(planoCobranca);

        var planoCobrancaSelecionado = repositorio.SelecionarPorId(planoCobranca.Id);

        var planosCobranca = repositorio.SelecionarTodos();

        Assert.IsNull(planoCobrancaSelecionado);
        Assert.AreEqual(0, planosCobranca.Count);
    }
}
