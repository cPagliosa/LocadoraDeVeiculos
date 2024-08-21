
using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio.ModuloTaxaServico
{
    public class TaxaServico : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool Tipo { get; set; }

        public TaxaServico(string nome,decimal preco,bool tipo)
        {
            this.Nome = nome;
            this.Preco = preco;
            this.Tipo = tipo;
        }
    }
}
