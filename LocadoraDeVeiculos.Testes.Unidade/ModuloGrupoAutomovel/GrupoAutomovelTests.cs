using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloGrupoAutomovel;

[TestClass]
[TestCategory("Unidade")]
public class GrupoAutomovelTests
{

    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var grupo = new GrupoAutomovel("Sedan");

        var erros = grupo.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var grupo = new GrupoAutomovel("");

        var erros = grupo.Validar();

        List<string> errosEsperados = ["O nome é obrigatório"];

        Assert.AreEqual(1, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}
