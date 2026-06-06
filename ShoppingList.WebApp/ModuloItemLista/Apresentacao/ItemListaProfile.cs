using AutoMapper;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;

namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Apresentacao;

public class ItemListaProfile : Profile
{
    public ItemListaProfile()
    {
        CreateMap<CadastrarItemListaViewModel, CadastrarItemListaDto>();

        CreateMap<ListarItensListaDto, ListarItensListaViewModel>();

        CreateMap<DetalhesItemListaDto, ExcluirItemListaViewModel>();

        CreateMap<OpcaoProdutoDto, OpcaoProdutoViewModel>();

        CreateMap<DadosCadastroItemListaDto, DadosCadastroItemListaViewModel>();
    }
}