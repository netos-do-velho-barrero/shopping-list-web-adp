using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using FluentResults;
using AutoMapper;
using ShoppingList.WebApp.ModuloProduto.Aplicacao;
using ListaDeComprasWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using ShoppingList.WebApp.ModuloCategoria.Aplicacao; 

namespace ShoppingList.WebApp.ModuloProduto.Apresentacao;


public class ProdutoController(
    ServicoProduto servicoProduto, 
    ServicoCategoria servicoCategoria, 
    IMapper mapeador) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarProdutoDto> dtos = servicoProduto.SelecionarTodos();
        List<ListarProdutoViewModel> listarVms = mapeador.Map<List<ListarProdutoViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CarregarCategoriasNaViewBag();

        CadastrarProdutoViewModel cadastrarVm = new CadastrarProdutoViewModel(
            string.Empty,
            string.Empty,
            default,
            0
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarProdutoViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategoriasNaViewBag(); 
            return View(cadastrarVm);
        }

        CadastrarProdutoDto dto = mapeador.Map<CadastrarProdutoDto>(cadastrarVm);
        Result resultado = servicoProduto.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            CarregarCategoriasNaViewBag();
            ModelState.AddModelError(string.Empty, resultado.Errors[0].Message);
            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Result<DetalhesProdutoDto> resultado = servicoProduto.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        CarregarCategoriasNaViewBag(); 

        DetalhesProdutoDto dto = resultado.Value;
        EditarProdutoViewModel editarVm = mapeador.Map<EditarProdutoViewModel>(dto);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarProdutoViewModel editarVm)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategoriasNaViewBag(); 
            return View(editarVm);
        }

        EditarProdutoDto dto = mapeador.Map<EditarProdutoDto>(editarVm);
        Result resultado = servicoProduto.Editar(dto);

        if (resultado.IsFailed)
        {
            CarregarCategoriasNaViewBag();
            ModelState.AddModelError(string.Empty, resultado.Errors[0].Message);
            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Result<DetalhesProdutoDto> resultado = servicoProduto.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        DetalhesProdutoDto dto = resultado.Value;
        ExcluirProdutoViewModel excluirVm = mapeador.Map<ExcluirProdutoViewModel>(dto);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirProdutoViewModel excluirVm)
    {
        Result resultado = servicoProduto.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    
    private void CarregarCategoriasNaViewBag()
    {
        var categorias = servicoCategoria.SelecionarTodos();
        ViewBag.Categorias = new SelectList(categorias, "Id", "Nome");
    }
}