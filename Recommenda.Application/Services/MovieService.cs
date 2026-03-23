using Recommenda.Application.DTOs;
using Recommenda.Domain.Entities;

namespace Recommenda.Application.Services;

/// <summary>
/// Implementação dos serviços de negócio para o domínio de filmes.
/// Responsável por criar, listar, buscar e remover filmes.
/// </summary>
public class MovieService : IMovieService
{
    private readonly List<Movie> _movies = [];

    /// <inheritdoc />
    public IReadOnlyList<MovieResponse> GetAll()
    {
        return _movies.Select(MovieResponse.FromDomain).ToList();
    }

    /// <inheritdoc />
    public MovieResponse? GetById(Guid id)
    {
        var movie = _movies.Find(m => m.Id == id);
        return movie is null ? null : MovieResponse.FromDomain(movie);
    }

    /// <inheritdoc />
    public MovieResponse Create(MovieRequest request)
    {
        if (ExistsByTitle(request.titleM))
            throw new InvalidOperationException("Já existe um filme com este título");

        var movie = request.ToDomain();
        _movies.Add(movie);

        return MovieResponse.FromDomain(movie);
    }

    /// <inheritdoc />
    public bool ExistsByTitle(string title)
    {
        return _movies.Exists(m => m.Name.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    /// <inheritdoc />
    public bool ExistsById(Guid id)
    {
        return _movies.Exists(m => m.Id == id);
    }

    /// <inheritdoc />
    public bool Delete(Guid id)
    {
        return _movies.RemoveAll(m => m.Id == id) > 0;
    }
}
