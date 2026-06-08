using ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;
using ShoppingList.WebApp.ModuloCategoria.Aplicacao;
using ShoppingList.WebApp.ModuloProduto.Aplicacao;

namespace ListaDeComprasWeb.WebApp.Compartilhado.Aplicacao;

public static class InjecaoDependencia
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ServicoListaCompra>();
        services.AddScoped<ServicoItemLista>();
        services.AddScoped<ServicoCategoria>();
        services.AddScoped<ServicoProduto>();
    }
}