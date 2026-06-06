using AutoMapper;
using FluentResults;
using ListaDeComprasWeb.WebApp.Compartilhado.Apresentacao.Extensions;
using ListaDeComprasWeb.WebApp.ModuloItemLista.Aplicacao;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeComprasWeb.WebApp.ModuloItemLista.Apresentacao;

public class ItemListaController(
    ServicoItemLista servicoItemLista,
    IMapper mapeador
) : Controller
{
    [HttpGet]
    public ActionResult Listar(string listaCompraId)
    {
        Result<List<ListarItensListaDto>> resultado = servicoItemLista.SelecionarPorLista(listaCompraId);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction("Listar", "ListaCompra");
        }

        List<ListarItensListaViewModel> listarVms =
            mapeador.Map<List<ListarItensListaViewModel>>(resultado.Value);

        return View(listarVms);
    }

    [HttpGet]
    public ActionResult Cadastrar(string listaCompraId)
    {
        Result<DadosCadastroItemListaDto> resultado = servicoItemLista.SelecionarDadosCadastro(listaCompraId);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction("Listar", "ListaCompra");
        }

        DadosCadastroItemListaViewModel dadosVm =
            mapeador.Map<DadosCadastroItemListaViewModel>(resultado.Value);

        ViewBag.DadosCadastro = dadosVm;

        CadastrarItemListaViewModel cadastrarVm = new CadastrarItemListaViewModel(
            listaCompraId,
            string.Empty,
            1
        );

        return View(cadastrarVm);
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarItemListaViewModel cadastrarVm)
    {
        Result<DadosCadastroItemListaDto> resultadoDados =
            servicoItemLista.SelecionarDadosCadastro(cadastrarVm.ListaCompraId);

        if (resultadoDados.IsFailed)
        {
            TempData.AddErrorMessage(resultadoDados);

            return RedirectToAction("Listar", "ListaCompra");
        }

        ViewBag.DadosCadastro = mapeador.Map<DadosCadastroItemListaViewModel>(resultadoDados.Value);

        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarItemListaDto dto = mapeador.Map<CadastrarItemListaDto>(cadastrarVm);

        Result resultado = servicoItemLista.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);

            return View(cadastrarVm);
        }

        return RedirectToAction(nameof(Listar), new { listaCompraId = cadastrarVm.ListaCompraId });
    }

    [HttpGet]
    public ActionResult Excluir(string id)
    {
        Result<DetalhesItemListaDto> resultado = servicoItemLista.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction("Listar", "ListaCompra");
        }

        ExcluirItemListaViewModel excluirVm =
            mapeador.Map<ExcluirItemListaViewModel>(resultado.Value);

        return View(excluirVm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirItemListaViewModel excluirVm)
    {
        Result resultado = servicoItemLista.Excluir(excluirVm.Id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);

            return RedirectToAction(nameof(Listar), new { listaCompraId = excluirVm.ListaCompraId });
        }

        return RedirectToAction(nameof(Listar), new { listaCompraId = excluirVm.ListaCompraId });
    }
}