using System;
using AutoMapper;
using ShoppingList.WebApp.ModuloProduto.Aplicacao;

namespace ShoppingList.WebApp.ModuloProduto.Apresentacao;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<ListarProdutoDto, ListarProdutoViewModel>();
        CreateMap<CadastrarProdutoViewModel, CadastrarProdutoDto>();
        CreateMap<EditarProdutoViewModel, EditarProdutoDto>();

        CreateMap<DetalhesProdutoDto, EditarProdutoViewModel>();
        CreateMap<DetalhesProdutoDto, ExcluirProdutoViewModel>();
    }
}
