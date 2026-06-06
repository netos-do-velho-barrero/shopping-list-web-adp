using FluentResults;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Dominio;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;
using ListaDeComprasWeb.WebApp.ModuloProduto.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;

public class ServicoItemLista
{
    private readonly IRepositorioItemLista repositorioItemLista;
    private readonly IRepositorioListaCompra repositorioListaCompra;
    private readonly IRepositorioProduto repositorioProduto;

    public ServicoItemLista(
        IRepositorioItemLista repositorioItemLista,
        IRepositorioListaCompra repositorioListaCompra,
        IRepositorioProduto repositorioProduto
    )
    {
        this.repositorioItemLista = repositorioItemLista;
        this.repositorioListaCompra = repositorioListaCompra;
        this.repositorioProduto = repositorioProduto;
    }

    public Result Cadastrar(CadastrarItemListaDto dto)
    {
        ListaCompra? listaCompra = repositorioListaCompra.SelecionarPorId(dto.ListaCompraId);

        if (listaCompra == null)
            return Result.Fail("Lista de compras não encontrada.");

        Produto? produto = repositorioProduto.SelecionarPorId(dto.ProdutoId);

        if (produto == null)
            return Result.Fail("Produto não encontrado.");

        bool produtoJaAdicionado = repositorioItemLista
            .Filtrar(i => i.ListaCompra.Id == dto.ListaCompraId && i.Produto.Id == dto.ProdutoId)
            .Any();

        if (produtoJaAdicionado)
            return Result.Fail("Este produto já foi adicionado nesta lista.");

        ItemLista novoItem = new ItemLista(listaCompra, produto, dto.Quantidade);

        List<string> erros = novoItem.Validar();

        if (erros.Count > 0)
            return Result.Fail(erros);

        repositorioItemLista.Cadastrar(novoItem);

        return Result.Ok();
    }

    public Result Excluir(string id)
    {
        ItemLista? item = repositorioItemLista.SelecionarPorId(id);

        if (item == null)
            return Result.Fail("Item da lista não encontrado.");

        repositorioItemLista.Excluir(id);

        return Result.Ok();
    }

    public Result<DadosCadastroItemListaDto> SelecionarDadosCadastro(string listaCompraId)
    {
        ListaCompra? listaCompra = repositorioListaCompra.SelecionarPorId(listaCompraId);

        if (listaCompra == null)
            return Result.Fail("Lista de compras não encontrada.");

        List<OpcaoProdutoDto> produtos = repositorioProduto
            .SelecionarTodos()
            .Select(p => new OpcaoProdutoDto(
                p.Id,
                p.Nome,
                p.Categoria.Nome,
                p.PrecoAproximado
            ))
            .ToList();

        DadosCadastroItemListaDto dto = new DadosCadastroItemListaDto(
            listaCompra.Id,
            listaCompra.Nome,
            produtos
        );

        return Result.Ok(dto);
    }

    public Result<List<ListarItensListaDto>> SelecionarPorLista(string listaCompraId)
    {
        ListaCompra? listaCompra = repositorioListaCompra.SelecionarPorId(listaCompraId);

        if (listaCompra == null)
            return Result.Fail("Lista de compras não encontrada.");

        List<ListarItensListaDto> itens = repositorioItemLista
            .Filtrar(i => i.ListaCompra.Id == listaCompraId)
            .Select(i => new ListarItensListaDto(
                i.Id,
                i.ListaCompra.Id,
                i.ListaCompra.Nome,
                i.Produto.Nome,
                i.Produto.Categoria.Nome,
                i.Quantidade,
                i.Produto.PrecoAproximado,
                i.CalcularValorTotal()
            ))
            .ToList();

        return Result.Ok(itens);
    }

    public Result<DetalhesItemListaDto> SelecionarPorId(string id)
    {
        ItemLista? item = repositorioItemLista.SelecionarPorId(id);

        if (item == null)
            return Result.Fail("Item da lista não encontrado.");

        DetalhesItemListaDto dto = new DetalhesItemListaDto(
            item.Id,
            item.ListaCompra.Id,
            item.ListaCompra.Nome,
            item.Produto.Id,
            item.Produto.Nome,
            item.Produto.Categoria.Nome,
            item.Quantidade,
            item.Produto.PrecoAproximado,
            item.CalcularValorTotal()
        );

        return Result.Ok(dto);
    }
}