using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio.ModuloConfiguracoes
{
    public class Combustivel : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public Combustivel(string nome,decimal valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
