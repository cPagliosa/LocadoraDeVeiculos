using LocadoraVeiculos.Dominio.Compartinhado;
using LocadoraVeiculos.Dominio.ModuloCliente;

namespace LocadoraVeiculos.Dominio.ModuloCondutor
{
    public class Condutor : EntidadeBase
    {
        public Cliente Cliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cnh { get; set; }
        public DateTime Validade { get; set; }

        public Condutor(Cliente cliente,string nome,string email,string telefone,string cnh,DateTime validade)
        {
            this.Cliente = cliente;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cnh = cnh;
            this.Validade = validade;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
