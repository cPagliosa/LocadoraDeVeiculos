using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;
using LocadoraDeVeiculos.Dominio.ModuloLocacao;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

public class PlanoCobranca : EntidadeBase
{
    public int GrupoAutomovelId { get; set; }
    public GrupoAutomovel? GrupoAutomoveis { get; set; }

    public decimal PrecoDiarioPlanoDiario { get; set; }
    public decimal PrecoQuilometroPlanoDiario { get; set; }

    public decimal QuilometrosDisponiveisPlanoControlado { get; set; }
    public decimal PrecoDiarioPlanoControlado { get; set; }
    public decimal PrecoQuilometroExtrapoladoPlanoControlado { get; set; }

    public decimal PrecoDiarioPlanoLivre { get; set; }

    protected PlanoCobranca() { }

    public PlanoCobranca(
        int grupoAutomovelId,
        decimal precoDiarioPlanoDiario,
        decimal precoQuilometroPlanoDiario,
        decimal quilometrosDisponiveisPlanoControlado,
        decimal precoDiarioPlanoControlado,
        decimal precoQuilometroExtrapoladoPlanoControlado,
        decimal precoDiarioPlanoLivre
    )
    {
        GrupoAutomovelId = grupoAutomovelId;

        PrecoDiarioPlanoDiario = precoDiarioPlanoDiario;
        PrecoQuilometroPlanoDiario = precoQuilometroPlanoDiario;

        QuilometrosDisponiveisPlanoControlado = quilometrosDisponiveisPlanoControlado;
        PrecoDiarioPlanoControlado = precoDiarioPlanoControlado;
        PrecoQuilometroExtrapoladoPlanoControlado = precoQuilometroExtrapoladoPlanoControlado;

        PrecoDiarioPlanoLivre = precoDiarioPlanoLivre;
    }


    public override List<string> Validar()
    {
        List<string> erros = [];

        if (GrupoAutomovelId == 0)
            erros.Add("O grupo de Automovel é obrigatório");

        return erros;
    }

    public decimal CalcularValor(int quantidadeDeDias, int quilometragemPercorrida, TipoPlanoCobrancaEnum tipoPlano)
    {
        decimal valor = 0.0m;

        switch (tipoPlano)
        {
            case TipoPlanoCobrancaEnum.Diario:
                decimal valorDiasPlanoDiario = quantidadeDeDias * PrecoDiarioPlanoDiario;

                decimal valorQuilometragemPercorridaPlanoDiario =
                    quilometragemPercorrida * PrecoQuilometroPlanoDiario;

                valor = valorDiasPlanoDiario + valorQuilometragemPercorridaPlanoDiario;
                break;

            case TipoPlanoCobrancaEnum.Controlado:
                decimal valorDiasPlanoControlado = quantidadeDeDias * PrecoDiarioPlanoControlado;

                decimal quilometrosExtrapolados =
                    quilometragemPercorrida - QuilometrosDisponiveisPlanoControlado;

                decimal valorQuilometragemPlanoControlado =
                    quilometrosExtrapolados * PrecoQuilometroExtrapoladoPlanoControlado;

                valor = valorDiasPlanoControlado;

                if (quilometrosExtrapolados > 0) valor += valorQuilometragemPlanoControlado;
                break;

            case TipoPlanoCobrancaEnum.Livre:
                valor = quantidadeDeDias * PrecoDiarioPlanoDiario;
                break;
        }

        return valor;
    }
}
