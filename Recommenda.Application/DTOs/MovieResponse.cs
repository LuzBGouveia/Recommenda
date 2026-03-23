using Recommenda.Domain.Entities;

namespace Recommenda.Application.DTOs;

/// <summary>
/// DTO de resposta para operações de filme.
/// </summary>
/// <param name="id">Identificador único do filme.</param>
/// <param name="title">Título do filme.</param>
public record MovieResponse(Guid id, string title)
{
    /// <summary>
    /// Cria um MovieResponse a partir de uma entidade Movie do domínio.
    /// </summary>
    /// <param name="movie">Entidade de domínio.</param>
    /// <returns>DTO de resposta.</returns>
    public static MovieResponse FromDomain(Movie movie) => new(movie.Id, movie.Name);
}