using System;
using ListaDeComprasWeb.WebApp.ModuloCategoria.Dominio;

namespace ShoppingList.WebApp.ModuloCategoria.Aplicacao;

public record ListarCategoriaDto(
    string Id,
    string Nome,
    CorCategoria Cor
);

public record CadastrarCategoriaDto(
    string Id,
    string Nome,
    CorCategoria Cor
);

public record EditarCategoriaDto(
    string Id,
    string Nome,
    CorCategoria Cor
);

public record DetalhesCategoriaDto(
    string Id,
    string Nome,
    CorCategoria Cor
);