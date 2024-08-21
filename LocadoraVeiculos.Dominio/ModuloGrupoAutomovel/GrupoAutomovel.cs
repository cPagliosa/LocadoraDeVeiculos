using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio
{
    public class GrupoAutomovel : EntidadeBase
    {
        //Variaveis
        public string Nome { get; set; }

        //Funções
        public override List<string> Validar()
        {
            List<string> erros = new List<string>();
            if(this.Nome.Length < 3)
                erros.Add("O nome é obrigatorio");

            return erros;
        }
        //Construtor
        protected GrupoAutomovel() { }
        
        public GrupoAutomovel(string nome)
        {
            this.Nome = nome;
        }
    }
}