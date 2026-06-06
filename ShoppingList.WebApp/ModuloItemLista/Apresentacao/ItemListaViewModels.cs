using System.ComponentModel.DataAnnotations;

namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Apresentacao;

public record ListarItensListaViewModel(
    string Id,
    string ListaCompraId,
    string NomeListaCompra,
    string NomeProduto,
    string NomeCategoria,
    decimal Quantidade,
    decimal PrecoAproximado,
    decimal ValorTotal
);

public record CadastrarItemListaViewModel(
    string ListaCompraId,

    [Required(ErrorMessage = "O campo \"Produto\" deve ser preenchido.")]
    string ProdutoId,

    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Quantidade\" deve conter um valor maior que 0.")]
    decimal Quantidade
);

public record ExcluirItemListaViewModel(
    string Id,
    string ListaCompraId,
    string NomeListaCompra,
    string NomeProduto,
    string NomeCategoria,
    decimal Quantidade,
    decimal PrecoAproximado,
    decimal ValorTotal
);

public record OpcaoProdutoViewModel(
    string Id,
    string Nome,
    string NomeCategoria,
    decimal PrecoAproximado
);

public record DadosCadastroItemListaViewModel(
    string ListaCompraId,
    string NomeListaCompra,
    List<OpcaoProdutoViewModel> Produtos
);