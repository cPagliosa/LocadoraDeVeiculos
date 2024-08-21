using LocadoraVeiculos.Dominio.Compartinhado;
using LocadoraVeiculos.Dominio.ModuloAutomovel;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCondutor;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;

namespace LocadoraVeiculos.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public Cliente Cliente { get; set; }
        public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public PlanoCobranca Plano { get; set; }
        public DateTime DataSaida { get; set; }
        public DateTime DataRetorno { get; set; }
        public decimal ValorTotal { get; set; }
        
        private bool concluido;

        public Aluguel(Cliente cliente,Condutor condutor,Automovel automovel,
            PlanoCobranca plano,DateTime saida,DateTime retorno,decimal valor)
        {
            this.Cliente = cliente;
            this.Condutor = condutor;
            this.Automovel = automovel;
            this.Plano = plano;
            this.DataSaida = saida;
            this.DataRetorno = retorno;
            this.ValorTotal = valor;
            this.concluido = false;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
