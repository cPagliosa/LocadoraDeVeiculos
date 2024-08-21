
using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class Endereco : EntidadeBase
    {
        public String Cep { get; set; }
        public String Estado { get; set; }
        public String Cidade { get; set; }
        public String Bairro { get; set; }
        public String Rua { get; set; }
        public int Numero { get; set; }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
