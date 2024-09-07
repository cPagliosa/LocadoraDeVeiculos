﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloPlanoCobranca;

public interface IRepositorioPlanoCobranca : IRepositorio<PlanoCobranca>
{
    PlanoCobranca? FiltrarPlano(Func<PlanoCobranca, bool> predicate);
}
