using System.ComponentModel.DataAnnotations;
using Recommenda.Domain.Entities;
using Recommenda.Domain.Enums;

namespace Recommenda.Application.DTOs;

/// <summary>
/// DTO de requisição para criação de filme.
/// </summary>
/// <param name="titleM">Título do filme.</param>
/// <param name="descriptionM">Descrição do filme.</param>
/// <param name="releaseDateTimeM">Data de lançamento.</param>
/// <param name="contentTypeM">Tipo do conteúdo.</param>
public record MovieRequest(
    string titleM,
    string descriptionM,
    DateTime releaseDateTimeM,

    [property: Required(ErrorMessage = "O tipo de conteúdo é obrigatório")]
    [property: EnumDataType(typeof(ContentTypeEnum), ErrorMessage = "Tipo de conteúdo inválido")]
    ContentTypeEnum contentTypeM
) : ContentRequest(titleM, descriptionM, releaseDateTimeM)
{
    // poderiamos usar o AutoMapper, mas como será pago vamos usar na mao
    
    public Movie ToDomain() => new Movie(
                                    title,
                                    description,
                                    releaseDateTime,
                                    false,
                                    []);
}