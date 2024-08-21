namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ClienteJuridico : Cliente
    {
        public string Cpnj { get; set; }

        public ClienteJuridico(string nome, string email, string telefone, string cpnj, Endereco endereco)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cpnj = cpnj;
            this.Endereco = endereco;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
