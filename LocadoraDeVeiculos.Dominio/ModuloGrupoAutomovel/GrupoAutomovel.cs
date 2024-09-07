using LocadoraDeVeiculos.Dominio.Compartilhado;
using LocadoraDeVeiculos.Dominio.ModuloAutomovel;


namespace LocadoraDeVeiculos.Dominio.ModuloGrupoAutomovel;

public class GrupoAutomovel : EntidadeBase
{
    public GrupoAutomovel() { }

    public GrupoAutomovel(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; set; }
    public List<Automovel> Automoveis { get; set; } = [];

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 3)
            erros.Add("O nome é obrigatório");

        return erros;
    }
}
