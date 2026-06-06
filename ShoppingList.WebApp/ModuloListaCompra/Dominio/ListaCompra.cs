using ListaDeComprasWeb.WebApp.Compartilhado.Dominio;

namespace ListaDeComprasWeb.WebApp.ModuloListaCompra.Dominio;

public sealed class ListaCompra : EntidadeBase<ListaCompra>
{
    public string Nome { get; set; } = string.Empty;

    public DateTime DataCriacao { get; set; } = DateTime.Now;

    public StatusListaCompra Status { get; set; } = StatusListaCompra.Aberta;

    public ListaCompra() { }

    public ListaCompra(string nome)
    {
        Nome = nome;
        DataCriacao = DateTime.Now;
        Status = StatusListaCompra.Aberta;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        if (!Enum.IsDefined(Status))
            erros.Add("O campo \"Status\" deve conter uma seleção válida.");

        return erros;
    }

    public override void Atualizar(ListaCompra entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Status = entidadeAtualizada.Status;
    }
}