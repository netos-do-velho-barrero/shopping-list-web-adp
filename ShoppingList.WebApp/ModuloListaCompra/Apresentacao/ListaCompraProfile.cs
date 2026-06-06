using AutoMapper;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Apresentacao;

public class ListaCompraProfile : Profile
{
    public ListaCompraProfile()
    {
        CreateMap<CadastrarListaCompraViewModel, CadastrarListaCompraDto>();

        CreateMap<EditarListaCompraViewModel, EditarListaCompraDto>();

        CreateMap<ListarListasCompraDto, ListarListasCompraViewModel>();

        CreateMap<DetalhesListaCompraDto, EditarListaCompraViewModel>();

        CreateMap<DetalhesListaCompraDto, ExcluirListaCompraViewModel>();

        CreateMap<DetalhesListaCompraDto, DetalhesListaCompraViewModel>();
    }
}