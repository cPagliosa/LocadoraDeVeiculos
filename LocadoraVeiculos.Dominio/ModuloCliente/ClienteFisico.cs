namespace LocadoraVeiculos.Dominio.ModuloCliente
{
    public class ClienteFisico : Cliente
    {
        public string Cpf { get; set; }

        public ClienteFisico(string nome,string email,string telefone,string cpf,Endereco endereco)
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
            this.Cpf = cpf;
            this.Endereco = endereco;
        }
    }
}
