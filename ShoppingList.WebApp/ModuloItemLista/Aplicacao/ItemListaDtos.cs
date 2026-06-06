namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;

public record CadastrarItemListaDto(
    string ListaCompraId,
    string ProdutoId,
    decimal Quantidade
);

public record ListarItensListaDto(
    string Id,
    string ListaCompraId,
    string NomeListaCompra,
    string NomeProduto,
    string NomeCategoria,
    decimal Quantidade,
    decimal PrecoAproximado,
    decimal ValorTotal
);

public record DetalhesItemListaDto(
    string Id,
    string ListaCompraId,
    string NomeListaCompra,
    string ProdutoId,
    string NomeProduto,
    string NomeCategoria,
    decimal Quantidade,
    decimal PrecoAproximado,
    decimal ValorTotal
);

public record OpcaoProdutoDto(
    string Id,
    string Nome,
    string NomeCategoria,
    decimal PrecoAproximado
);

public record DadosCadastroItemListaDto(
    string ListaCompraId,
    string NomeListaCompra,
    List<OpcaoProdutoDto> Produtos
);