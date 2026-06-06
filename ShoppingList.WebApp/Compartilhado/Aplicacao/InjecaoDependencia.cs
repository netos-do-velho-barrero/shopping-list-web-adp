using ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;

namespace ListaDeComprasWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoListaCompra>();
        services.AddScoped<ServicoItemLista>();
    }
}