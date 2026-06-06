using AutoMapper;
using FluentResults;
using ListaDeComprasWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using ListaDeComprasWeb.WebApp.ModuloListaCompra.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Apresentacao;

public class ListaCompraController(
    ServicoListaCompra servicoListaCompra,
    IMapper mapeador
) : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        List<ListarListasCompraDto> dtos = servicoListaCompra.SelecionarTodos();

        List<ListarListasCompraViewModel> listarVms =
            mapeador.Map<List<ListarListasCompraViewModel>>(dtos);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        CadastrarListaCompraViewModel cadastrarVm = new CadastrarListaCompraViewModel(string.Empty);

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarListaCompraViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarListaCompraDto dto = mapeador.Map<CadastrarListaCompraDto>(cadastrarVm);

        Result resultado = servicoListaCompra.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(string id)
    {
        Result<DetalhesListaCompraDto> resultado = servicoListaCompra.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        EditarListaCompraViewModel editarVm =
            mapeador.Map<EditarListaCompraViewModel>(resultado.Value);

        return View(editarVm);
    }

    [HttpPost]
    public ActionResult Editar(EditarListaCompraViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        EditarListaCompraDto dto = mapeador.Map<EditarListaCompraDto>(editarVm);

        Result resultado = servicoListaCompra.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Result<DetalhesListaCompraDto> resultado = servicoListaCompra.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        ExcluirListaCompraViewModel excluirVm =
            mapeador.Map<ExcluirListaCompraViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirListaCompraViewModel excluirVm)
    {
        Result resultado = servicoListaCompra.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Detalhes(string id)
    {
        Result<DetalhesListaCompraDto> resultado = servicoListaCompra.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar));
        }

        DetalhesListaCompraViewModel detalhesVm =
            mapeador.Map<DetalhesListaCompraViewModel>(resultado.Value);

        return View(detalhesVm);
    }
}