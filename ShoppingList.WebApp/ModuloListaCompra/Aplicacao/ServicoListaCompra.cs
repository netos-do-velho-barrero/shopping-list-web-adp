using FluentResults;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Dominio;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;

public class ServicoListaCompra
{
    private readonly IRepositorioListaCompra repositorioListaCompra;
    private readonly IRepositorioItemLista repositorioItemLista;

    public ServicoListaCompra(
        IRepositorioListaCompra repositorioListaCompra,
        IRepositorioItemLista repositorioItemLista
    )
    {
        this.repositorioListaCompra = repositorioListaCompra;
        this.repositorioItemLista = repositorioItemLista;
    }

    public Result Cadastrar(CadastrarListaCompraDto dto)
    {
        ListaCompra novaLista = new ListaCompra(dto.Nome);

        List<string> erros = novaLista.Validar();

        if (erros.Count > 0)
            return Result.Fail(erros);

        repositorioListaCompra.Cadastrar(novaLista);

        return Result.Ok();
    }

    public Result Editar(EditarListaCompraDto dto)
    {
        ListaCompra listaAtualizada = new ListaCompra(dto.Nome)
        {
            Status = dto.Status
        };

        List<string> erros = listaAtualizada.Validar();

        if (erros.Count > 0)
            return Result.Fail(erros);

        bool conseguiuEditar = repositorioListaCompra.Editar(dto.Id, listaAtualizada);

        if (!conseguiuEditar)
            return Result.Fail("Lista de compras não encontrada.");

        return Result.Ok();
    }

    public Result Excluir(string id)
    {
        ListaCompra? lista = repositorioListaCompra.SelecionarPorId(id);

        if (lista == null)
            return Result.Fail("Lista de compras não encontrada.");

        List<ItemLista> itensDaLista = repositorioItemLista.Filtrar(i => i.ListaCompra.Id == id);

        if (itensDaLista.Count > 0)
            return Result.Fail("Esta lista não pode ser excluída pois possui itens vinculados.");

        repositorioListaCompra.Excluir(id);

        return Result.Ok();
    }

    public List<ListarListasCompraDto> SelecionarTodos()
    {
        List<ListaCompra> listas = repositorioListaCompra.SelecionarTodos();

        return listas
            .Select(l => new ListarListasCompraDto(
                l.Id,
                l.Nome,
                l.DataCriacao,
                l.Status,
                CalcularTotalItens(l.Id),
                CalcularValorTotalEstimado(l.Id)
            ))
            .ToList();
    }

    public Result<DetalhesListaCompraDto> SelecionarPorId(string id)
    {
        ListaCompra? lista = repositorioListaCompra.SelecionarPorId(id);

        if (lista == null)
            return Result.Fail("Lista de compras não encontrada.");

        DetalhesListaCompraDto dto = new DetalhesListaCompraDto(
            lista.Id,
            lista.Nome,
            lista.DataCriacao,
            lista.Status,
            CalcularTotalItens(lista.Id),
            CalcularValorTotalEstimado(lista.Id)
        );

        return Result.Ok(dto);
    }

    private int CalcularTotalItens(string idLista)
    {
        return repositorioItemLista
            .Filtrar(i => i.ListaCompra.Id == idLista)
            .Count;
    }

    private decimal CalcularValorTotalEstimado(string idLista)
    {
        return repositorioItemLista
            .Filtrar(i => i.ListaCompra.Id == idLista)
            .Sum(i => i.CalcularValorTotal());
    }
}