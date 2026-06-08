using System;
using ListaDeComprasWeb.WebApp.ModuloProduto.Dominio;

namespace ShoppingList.WebApp.ModuloProduto.Aplicacao;

public record ListarProdutoDto(
    string Id,
    string Nome,
    string CategoriaNome,
    decimal PrecoAproximado
);

public record CadastrarProdutoDto(
    string Nome,
    string CategoriaId,
    UnidadeMedida UnidadeMedida,
    decimal PrecoAproximado
);

public record EditarProdutoDto(
    string Id,
    string Nome,
    string CategoriaId,
    UnidadeMedida UnidadeMedida,
    decimal PrecoAproximado
);

public record DetalhesProdutoDto(
    string Id,
    string Nome,
    string CategoriaId,
    UnidadeMedida UnidadeMedida,
    decimal PrecoAproximado
);