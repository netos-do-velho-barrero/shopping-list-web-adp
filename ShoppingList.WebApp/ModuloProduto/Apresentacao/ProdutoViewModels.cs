
using System.ComponentModel.DataAnnotations;
using ListaDeComprasWeb.WebApp.ModuloProduto.Dominio;

namespace ShoppingList.WebApp.ModuloProduto.Apresentacao;

public record ListarProdutoViewModel(string Id,
 string Nome,
 string CategoriaNome,
 decimal PrecoAproximado
 );

public record CadastrarProdutoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    string CategoriaId,

    [Required(ErrorMessage = "O campo \"Unidade de Medida\" deve conter uma seleção válida.")]
    UnidadeMedida UnidadeMedida,

    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Preço Aproximado\" deve conter um valor maior que 0.")]
    decimal PrecoAproximado
);

public record EditarProdutoViewModel(
    [Required(ErrorMessage = "O campo \"Id\" é obrigatório.")]
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Categoria\" deve ser preenchido.")]
    string CategoriaId,

    [Required(ErrorMessage = "O campo \"Unidade de Medida\" deve conter uma seleção válida.")]
    UnidadeMedida UnidadeMedida,

    [Range(0.01, double.MaxValue, ErrorMessage = "O campo \"Preço Aproximado\" deve conter um valor maior que 0.")]
    decimal PrecoAproximado
);

public record ExcluirProdutoViewModel(string Id, 
    string Nome,
    string CategoriaNome,
    UnidadeMedida UnidadeMedida,
    decimal PrecoAproximado
    );