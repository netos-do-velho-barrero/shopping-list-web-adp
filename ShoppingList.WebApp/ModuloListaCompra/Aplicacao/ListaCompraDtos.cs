using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;

public record CadastrarListaCompraDto(string Nome);

public record EditarListaCompraDto(
    string Id,
    string Nome,
    StatusListaCompra Status
);

public record ListarListasCompraDto(
    string Id,
    string Nome,
    DateTime DataCriacao,
    StatusListaCompra Status,
    int TotalItens,
    decimal ValorTotalEstimado
);

public record DetalhesListaCompraDto(
    string Id,
    string Nome,
    DateTime DataCriacao,
    StatusListaCompra Status,
    int TotalItens,
    decimal ValorTotalEstimado
);