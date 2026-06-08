using System;
using System.ComponentModel.DataAnnotations;
using ListaDeComprasWeb.WebApp.ModuloCategoria.Dominio;


namespace ShoppingList.WebApp.ModuloCategoria.Apresentacao;

public record ListarCategoriaViewModel(
    string Id,
    string Nome,
    CorCategoria Cor
);

public record CadastrarCategoriaViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(50, ErrorMessage = "O campo \"Etiqueta\" deve conter no máximo 50 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Cor\" conter uma seleção válida na paleta de cores.")]
    CorCategoria Cor
);

public record EditarCategoriaViewModel(
    string Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido.")]
    [StringLength(50, ErrorMessage = "O campo \"Etiqueta\" deve conter no máximo 50 caracteres.")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Cor\" conter uma seleção válida na paleta de cores.")]
    CorCategoria Cor
);

public record ExcluirCategoriaViewModel(
    string Id,
    string Nome,
    CorCategoria Cor
);