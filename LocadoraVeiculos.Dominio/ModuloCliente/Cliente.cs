using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public abstract class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
