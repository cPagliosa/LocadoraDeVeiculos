namespace LocadoraVeiculos.Dominio.Compartinhado
{
    public abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract List<string> Validar();
    }
}
