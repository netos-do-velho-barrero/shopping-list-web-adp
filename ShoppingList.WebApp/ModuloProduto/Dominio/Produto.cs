using ListaDeComprasWeb.WebApp.Compartilhado.Dominio;
using ListaDeComprasWeb.WebApp.ModuloCategoria.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloProduto.Dominio;

public sealed class Produto : EntidadeBase<Produto>
{
    public string Nome { get; set; } = string.Empty;

    public Categoria Categoria { get; set; } = null!;

    public UnidadeMedida UnidadeMedida { get; set; }

    public decimal PrecoAproximado { get; set; }

    public Produto() { }

    public Produto(
        string nome,
        Categoria categoria,
        UnidadeMedida unidadeMedida,
        decimal precoAproximado
    )
    {
        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido.");

        if (!Enum.IsDefined(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve conter uma seleção válida.");

        if (PrecoAproximado <= 0)
            erros.Add("O campo \"Preço Aproximado\" deve conter um valor maior que 0.");

        return erros;
    }

    public override void Atualizar(Produto entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Categoria = entidadeAtualizada.Categoria;
        UnidadeMedida = entidadeAtualizada.UnidadeMedida;
        PrecoAproximado = entidadeAtualizada.PrecoAproximado;
    }
}