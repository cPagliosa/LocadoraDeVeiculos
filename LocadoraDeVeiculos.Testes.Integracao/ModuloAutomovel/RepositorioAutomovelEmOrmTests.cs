using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloAutomovel;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Testes.Integracao.ModuloAutomovel;

[TestClass]
[TestCategory("Integração")]
public class RepositorioAutomovelEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioAutomovelEmOrm repositorio;
    private RepositorioGrupoAutomovelEmOrm repositorioGrupos;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.Automoveis.RemoveRange(dbContext.Automoveis);
        dbContext.GrupoAutomovel.RemoveRange(dbContext.GrupoAutomovel);

        repositorio = new RepositorioAutomovelEmOrm(dbContext);
        repositorioGrupos = new RepositorioGrupoAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorio.Inserir);
        BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupos.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_Automovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomovelId = grupo.Id)
            .Persist();

        var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

        Assert.IsNotNull(automovelSelecionado);
        Assert.AreEqual(automovel, automovelSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_Automovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomovelId = grupo.Id)
            .Persist();

        automovel.Modelo = "Novo Modelo";

        repositorio.Editar(automovel);

        var veiculoSelecionado = repositorio.SelecionarPorId(automovel.Id);

        Assert.IsNotNull(veiculoSelecionado);
        Assert.AreEqual(automovel, veiculoSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_Automovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .With(g => g.Id = 0)
            .Persist();

        var automovel = Builder<Automovel>
            .CreateNew()
            .With(v => v.Id = 0)
            .With(v => v.GrupoAutomovelId = grupo.Id)
            .Persist();

        repositorio.Excluir(automovel);

        var automovelSelecionado = repositorio.SelecionarPorId(automovel.Id);

        var automovels = repositorio.SelecionarTodos();

        Assert.IsNull(automovelSelecionado);
        Assert.AreEqual(0, automovels.Count);
    }
}
