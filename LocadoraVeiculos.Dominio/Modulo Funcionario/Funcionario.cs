using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio
{
    public class Funcionario : EntidadeBase
    {
        //Variaveis
        public string Nome { get; set; }
        public DateTime DataAdmissao { get; set; }
        public decimal Salario { get; set; }

        private bool AluguelAberto;

        //Funções
        public void AberturaAluguel()
        {
            this.AluguelAberto = true;
        }

        public void FechamentoAluguel()
        {
            this.AluguelAberto = false;
        }

        //Construtor
        public Funcionario(string nome,DateTime data,decimal salario)
        {
            this.Nome = nome;
            this.DataAdmissao = data;
            this.Salario = salario;
            this.AluguelAberto = false;
        }
    }
}