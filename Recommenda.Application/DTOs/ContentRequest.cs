using System.ComponentModel.DataAnnotations;

namespace Recommenda.Application.DTOs;

/// <summary>
/// DTO base de requisição para conteúdo (filme, série, etc.).
/// </summary>
/// <param name="title">Título do conteúdo.</param>
/// <param name="description">Descrição do conteúdo.</param>
/// <param name="releaseDateTime">Data de lançamento.</param>
public abstract record ContentRequest(
    [property: Required(ErrorMessage = "O título é obrigatório")]
    [property: StringLength(200, MinimumLength = 2, ErrorMessage = "O título deve ter entre 2 e 200 caracteres")]
    string title,

    [property: Required(ErrorMessage = "A descrição é obrigatória")]
    [property: StringLength(1000, MinimumLength = 10, ErrorMessage = "A descrição deve ter entre 10 e 1000 caracteres")]
    string description,

    [property: Required(ErrorMessage = "A data de lançamento é obrigatória")]
    [property: Range(typeof(DateTime), "1888-01-01", "2100-12-31", ErrorMessage = "A data deve estar entre 1888 e 2100")]
    DateTime releaseDateTime);