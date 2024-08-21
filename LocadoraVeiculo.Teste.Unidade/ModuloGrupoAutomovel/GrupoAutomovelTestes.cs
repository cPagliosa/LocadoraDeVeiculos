using LocadoraVeiculos.Dominio;

namespace LocadoraVeiculo.Teste.Unidade.ModuloGrupoAutomovel;
[TestClass]
[TestCategory("Unidade")]
public class GrupoAutomovelTestes
{
    [TestMethod]
    public void Deve_Criar_Instacia_Valida()
    {
        var grupo = new GrupoAutomovel("SUV");

        var erros = grupo.Validar();

        Assert.AreEqual(0,erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instacia_Errada()
    {
        var grupo = new GrupoAutomovel("FF");

        var erros = grupo.Validar();

        List<string> errosEsperados = ["O nome é obrigatorio"];

        Assert.AreEqual(1,erros.Count);
        CollectionAssert.AreEqual(errosEsperados,erros);
    }
}

