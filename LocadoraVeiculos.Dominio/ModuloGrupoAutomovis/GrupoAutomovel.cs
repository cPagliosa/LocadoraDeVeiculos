using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio
{
    public class GrupoAutomovel : EntidadeBase
    {
        //Variaveis
        public string Nome { get; set; }
        private bool TemAutomoveis { get; set; }
        private bool TemPlanoCobranca { get; set; }

        //Funções

        //Construtor
        public GrupoAutomovel(string nome)
        {
            this.Nome = nome;
            this.TemAutomoveis = false;
            this.TemPlanoCobranca = false;
        }
    }
}