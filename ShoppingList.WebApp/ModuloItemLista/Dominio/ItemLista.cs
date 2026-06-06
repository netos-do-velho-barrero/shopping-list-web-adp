using ListaDeComprasWeb.WebApp.Compartilhado.Dominio;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;
using ListaDeComprasWeb.WebApp.ModuloProduto.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Dominio;

public sealed class ItemLista : EntidadeBase<ItemLista>
{
    public ListaCompra ListaCompra { get; set; } = null!;

    public Produto Produto { get; set; } = null!;

    public decimal Quantidade { get; set; }

    public ItemLista() { }

    public ItemLista(ListaCompra listaCompra, Produto produto, decimal quantidade)
    {
        ListaCompra = listaCompra;
        Produto = produto;
        Quantidade = quantidade;
    }

    public decimal CalcularValorTotal()
    {
        if (Produto == null)
            return 0;

        return Produto.PrecoAproximado * Quantidade;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (ListaCompra == null)
            erros.Add("O campo \"Lista de Compras\" deve ser preenchido.");

        if (Produto == null)
            erros.Add("O campo \"Produto\" deve ser preenchido.");

        if (Quantidade <= 0)
            erros.Add("O campo \"Quantidade\" deve conter um valor maior que 0.");

        return erros;
    }

    public override void Atualizar(ItemLista entidadeAtualizada)
    {
        ListaCompra = entidadeAtualizada.ListaCompra;
        Produto = entidadeAtualizada.Produto;
        Quantidade = entidadeAtualizada.Quantidade;
    }
}