using System.ComponentModel.DataAnnotations;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Apresentacao;

public record ListarListasCompraViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao,
    StatusListaCompra Status,
    int TotalItens,
    decimal ValorTotalEstimado
);

public record CadastrarListaCompraViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome
);

public record EditarListaCompraViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo \"Nome\" deve conter entre 3 e 100 caracteres.")]
    string Nome,

    StatusListaCompra Status
);

public record ExcluirListaCompraViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao,
    StatusListaCompra Status,
    int TotalItens,
    decimal ValorTotalEstimado
);

public record DetalhesListaCompraViewModel(
    string Id,
    string Nome,
    DateTime DataCriacao,
    StatusListaCompra Status,
    int TotalItens,
    decimal ValorTotalEstimado
);