using ListaDeComprasWeb.WebApp.Compartilhado.Infra.Arquivos;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Infra;

public class RepositorioListaCompraEmArquivo
    : RepositorioBaseEmArquivo<ListaCompra>, IRepositorioListaCompra
{
    public RepositorioListaCompraEmArquivo(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<ListaCompra> CarregarRegistros()
    {
        return contexto.ListasCompra;
    }
}