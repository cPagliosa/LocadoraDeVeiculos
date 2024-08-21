using LocadoraVeiculos.Dominio.Compartinhado;
using LocadoraVeiculos.Dominio.ModuloConfiguracoes;

namespace LocadoraVeiculos.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase
    {
        //Variaveis
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public Combustivel TipoCombustivel { get; set; }
        public decimal CapacidadeCombustivel { get; set; }
        public int Ano { get; set; }
        public string Img { get; set; }
        public GrupoAutomovel Grupo { get; set; }
        private bool estaAlugado { get; set; }

        //Funções
        public void Alugado()
        {
            this.estaAlugado = true;
        }

        public void DesAlugado()
        {
            this.estaAlugado = false;
        }


        //Construtor
        protected Automovel()
        {
            
        }
        public Automovel(string placa,string marca,string cor,string modelo,Combustivel tipoCombustivel,
            decimal capacidadeCombustivel,int ano,string img,GrupoAutomovel grupo)
        {
            this.Placa = placa;
            this.Marca = marca;
            this.Cor = cor;
            this.Modelo = modelo;
            this.TipoCombustivel = tipoCombustivel;
            this.CapacidadeCombustivel = capacidadeCombustivel;
            this.Ano = ano;
            this.Img = img;
            this.Grupo = grupo;
            this.estaAlugado = false;
        }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
