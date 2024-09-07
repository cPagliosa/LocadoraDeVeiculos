using FizzWare.NBuilder;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Infra.Orm.Compartilhado;
using LocadoraDeVeiculos.Infra.Orm.ModuloGrupoAutomovel;


namespace LocadoraDeVeiculos.Testes.Integracao.ModuloGrupoAutomovel;

[TestClass]
[TestCategory("Integração")]
public class RepositorioGrupoAutomovelEmOrmTests
{
    private LocadoraDbContext dbContext;
    private RepositorioGrupoAutomovelEmOrm repositorio;

    [TestInitialize]
    public void Inicializar()
    {
        dbContext = new LocadoraDbContext();

        dbContext.GrupoAutomovel.RemoveRange(dbContext.GrupoAutomovel);

        repositorio = new RepositorioGrupoAutomovelEmOrm(dbContext);

        BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorio.Inserir);
    }

    [TestMethod]
    public void Deve_Inserir_GrupoAutomovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .Persist();

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Editar_GrupoAutomovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .Persist();

        grupo.Nome = "Teste de Edição";
        repositorio.Editar(grupo);

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        Assert.IsNotNull(grupoSelecionado);
        Assert.AreEqual(grupo, grupoSelecionado);
    }

    [TestMethod]
    public void Deve_Excluir_GrupoAutomovel()
    {
        var grupo = Builder<GrupoAutomovel>
            .CreateNew()
            .Persist();

        repositorio.Excluir(grupo);

        var grupoSelecionado = repositorio.SelecionarPorId(grupo.Id);

        var grupos = repositorio.SelecionarTodos();

        Assert.IsNull(grupoSelecionado);
        Assert.AreEqual(0, grupos.Count);
    }
}
