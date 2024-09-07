
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;

namespace LocadoraDeVeiculos.Dominio.ModuloCombustivel;

public class ConfiguracaoCombustivel
{
    public int Id { get; set; }
    public DateTime DataCriacao { get; set; }

    public decimal ValorGasolina { get; set; }
    public decimal ValorGas { get; set; }
    public decimal ValorDiesel { get; set; }
    public decimal ValorAlcool { get; set; }

    protected ConfiguracaoCombustivel() { }

    public ConfiguracaoCombustivel(
        decimal valorGasolina,
        decimal valorGas,
        decimal valorDiesel,
        decimal valorAlcool
    ) : this()
    {
        ValorGasolina = valorGasolina;
        ValorGas = valorGas;
        ValorDiesel = valorDiesel;
        ValorAlcool = valorAlcool;
    }

    public decimal ObterValorCombustivel(CombustivelEnum tipoCombustivel)
    {
        return tipoCombustivel switch
        {
            CombustivelEnum.Alcool => ValorAlcool,
            CombustivelEnum.Diesel => ValorDiesel,
            CombustivelEnum.Gas => ValorGas,
            _ => ValorGasolina
        };
    }
}
