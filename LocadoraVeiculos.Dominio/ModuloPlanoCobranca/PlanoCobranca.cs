using LocadoraVeiculos.Dominio.Compartinhado;

namespace LocadoraVeiculos.Dominio.ModuloPlanoCobranca
{
    public abstract class PlanoCobranca : EntidadeBase
    {
        public GrupoAutomovel Grupo { get; set; }

    }
}
