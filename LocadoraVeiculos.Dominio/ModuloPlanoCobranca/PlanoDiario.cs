namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public class PlanoDiario : PlanoCobranca
    {
        public decimal PrecoDiario { get; set; }
        public decimal PrecoKm { get; set; }

        public PlanoDiario(GrupoAutomovel grupo,decimal precoDiario,decimal precoKm)
        {
            this.Grupo = grupo;
            this.PrecoDiario = precoDiario;
            this.PrecoKm = precoKm;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
