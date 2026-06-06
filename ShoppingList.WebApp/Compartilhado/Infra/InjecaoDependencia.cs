using ListaDeComprasWeb.WebApp.Compartilhado.Infra.Arquivos;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Dominio;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Infra;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Infra;

namespace ListaDeComprasWeb.WebApp.Compartilhado.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(this IServiceCollection services)
    {
        services.AddScoped(provider =>
        {
            ContextoJson contextoJson = new ContextoJson();

            contextoJson.Carregar();

            return contextoJson;
        });

        services.AddScoped<IRepositorioListaCompra, RepositorioListaCompraEmArquivo>();
        services.AddScoped<IRepositorioItemLista, RepositorioItemListaEmArquivo>();
    }
}