using Recommenda.Application.DTOs;

namespace Recommenda.Application.Services;

/// <summary>
/// Define as operações de negócio para o domínio de filmes.
/// </summary>
public interface IMovieService
{
    /// <summary>
    /// Retorna todos os filmes cadastrados.
    /// </summary>
    /// <returns>Lista de filmes no formato de resposta.</returns>
    IReadOnlyList<MovieResponse> GetAll();

    /// <summary>
    /// Busca um filme pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único do filme.</param>
    /// <returns>O filme encontrado ou null se não existir.</returns>
    MovieResponse? GetById(Guid id);

    /// <summary>
    /// Cria um novo filme a partir dos dados informados.
    /// </summary>
    /// <param name="request">Dados do filme a ser criado.</param>
    /// <returns>O filme criado no formato de resposta.</returns>
    /// <exception cref="InvalidOperationException">Quando já existe um filme com o mesmo título.</exception>
    MovieResponse Create(MovieRequest request);

    /// <summary>
    /// Verifica se existe um filme com o título informado.
    /// </summary>
    /// <param name="title">Título do filme.</param>
    /// <returns>True se o filme existe, false caso contrário.</returns>
    bool ExistsByTitle(string title);

    /// <summary>
    /// Verifica se existe um filme com o identificador informado.
    /// </summary>
    /// <param name="id">Identificador único do filme.</param>
    /// <returns>True se o filme existe, false caso contrário.</returns>
    bool ExistsById(Guid id);

    /// <summary>
    /// Remove um filme pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único do filme a ser removido.</param>
    /// <returns>True se o filme foi removido, false se não foi encontrado.</returns>
    bool Delete(Guid id);
}
