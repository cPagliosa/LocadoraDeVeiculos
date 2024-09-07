using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Dominio.ModuloAutomovel;

public class Automovel : EntidadeBase
{
    public string Modelo { get; set; }
    public string Marca { get; set; }
    public CombustivelEnum TipoCombustivel { get; set; }
    public int CapacidadeTanque { get; set; }
    public byte[] Foto { get; set; }

    public int GrupoAutomovelId { get; set; }
    public GrupoAutomovel? GrupoAutomovel { get; set; }

    public bool Alugado { get; set; }

    protected Automovel() { }

    public Automovel(
        string modelo,
        string marca,
        CombustivelEnum tipoCombustivel,
        int capacidadeTanque,
        int grupoAutomovelId
    )
    {
        Modelo = modelo;
        Marca = marca;
        TipoCombustivel = tipoCombustivel;
        CapacidadeTanque = capacidadeTanque;
        GrupoAutomovelId = grupoAutomovelId;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (string.IsNullOrEmpty(Modelo))
            erros.Add("O modelo é obrigatório");

        if (string.IsNullOrEmpty(Marca))
            erros.Add("A marca é obrigatória");

        if (CapacidadeTanque == 0)
            erros.Add("A capacidade do tanque precisa ser informada");

        if (GrupoAutomovelId == 0)
            erros.Add("O grupo de veículos é obrigatório");

        return erros;
    }

    public void Alugar()
    {
        Alugado = true;
    }

    public void Desocupar()
    {
        Alugado = false;
    }

    public decimal CalcularLitrosParaAbastecimento(MarcadorCombustivelEnum marcadorCombustivel)
    {
        switch (marcadorCombustivel)
        {
            case MarcadorCombustivelEnum.Vazio: return CapacidadeTanque;

            case MarcadorCombustivelEnum.UmQuarto: return (CapacidadeTanque - (CapacidadeTanque * 1 / 4));

            case MarcadorCombustivelEnum.MeioTanque: return (CapacidadeTanque - (CapacidadeTanque * 1 / 2));

            case MarcadorCombustivelEnum.TresQuartos: return (CapacidadeTanque - (CapacidadeTanque * 3 / 4));

            default:
                return 0;
        }
    }
}