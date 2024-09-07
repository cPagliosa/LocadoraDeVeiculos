using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Testes.Unidade.ModuloAutomovel;

[TestClass]
[TestCategory("Unidade")]
public class AutomovelTests
{
    [TestMethod]
    public void Deve_Criar_Instancia_Valida()
    {
        var automovel = new Automovel
        (
            "Modelo A",
            "Marca X",
            CombustivelEnum.Gasolina,
            50,
            1
        );

        var erros = automovel.Validar();

        Assert.AreEqual(0, erros.Count);
    }

    [TestMethod]
    public void Deve_Criar_Instancia_Com_Erro()
    {
        var veiculo = new Automovel
        (
            "",
            "",
            CombustivelEnum.Gasolina,
            0,
            0
        );

        var erros = veiculo.Validar();

        List<string> errosEsperados =
        [
            "O modelo é obrigatório",
            "A marca é obrigatória",
            "A capacidade do tanque precisa ser informada",
            "O grupo de veículos é obrigatório"
        ];

        Assert.AreEqual(errosEsperados.Count, erros.Count);
        CollectionAssert.AreEqual(errosEsperados, erros);
    }
}
