﻿using LocadoraDeVeiculos.Dominio.Compartilhado;

namespace LocadoraDeVeiculos.Dominio.ModuloTaxa;

public interface IRepositorioTaxa : IRepositorio<Taxa>
{
    List<Taxa> SelecionarMuitos(List<int> idsTaxasSelecionadas);
}
