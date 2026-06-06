using ListaDeComprasWeb.WebApp.ModuloItemLista.Apresentacao;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Apresentacao;

namespace ListaDeComprasWeb.WebApp.Compartilhado.Apresentacao;

public static class InjecaoDependencia
{
    public static void AddPresentation(this IServiceCollection services)
    {
        services.AddControllersWithViews().AddRazorOptions(options =>
        {
            options.ViewLocationFormats.Clear();

            options.ViewLocationFormats.Add("/Modulo{1}/Apresentacao/Views/{0}.cshtml");

            options.ViewLocationFormats.Add("/Compartilhado/Apresentacao/Views/{0}.cshtml");
        });

        services.AddAutoMapper(config =>
        {
            config.AddProfile<ListaCompraProfile>();
            config.AddProfile<ItemListaProfile>();
        });
    }
}