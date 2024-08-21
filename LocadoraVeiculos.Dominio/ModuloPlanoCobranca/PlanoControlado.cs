namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoControlado : PlanoCobranca
    {
        public decimal KmDisponivel { get; set; }
        public decimal PrecoDiaria { get; set; }
        public decimal PrecoKmExtrapolado { get; set; }

        public PlanoControlado(GrupoAutomovel grupo,decimal kmDisponivel,decimal precoDiaria,decimal precoKmExtrapolado)
        {
            this.Grupo = grupo;
            this.KmDisponivel = kmDisponivel;
            this.PrecoDiaria = precoDiaria;
            this.PrecoKmExtrapolado = precoKmExtrapolado;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
