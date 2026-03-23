using Microsoft.AspNetCore.Mvc;
using Recommenda.Application.DTOs;
using Recommenda.Application.Services;

namespace Recommenda.API.Controllers;

/// <summary>
/// Controller responsável pelas operações de filmes na API.
/// Expõe endpoints para criar, listar, buscar e remover filmes.
/// </summary>
/// <remarks>
/// Base URL: /api/movie
/// Exemplo: http://localhost:5283/api/movie
/// </remarks>
[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    /// <summary>
    /// Inicializa o controller com o serviço de filmes.
    /// </summary>
    /// <param name="movieService">Implementação do serviço de filmes (injetado via DI).</param>
    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    /// <summary>
    /// Lista todos os filmes cadastrados.
    /// </summary>
    /// <returns>Lista de filmes.</returns>
    [HttpGet]
    public IActionResult GetAll()
    {
        var movies = _movieService.GetAll();
        return Ok(movies);
    }

    /// <summary>
    /// Busca um filme pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único do filme.</param>
    /// <returns>O filme encontrado ou 404 se não existir.</returns>
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        var movie = _movieService.GetById(id);
        if (movie is null)
            return NotFound();

        return Ok(movie);
    }

    /// <summary>
    /// Cria um novo filme.
    /// </summary>
    /// <param name="request">Dados do filme a ser criado.</param>
    /// <returns>O filme criado ou 400 se o título já existir.</returns>
    [HttpPost]
    public IActionResult Create([FromBody] MovieRequest request)
    {
        try
        {
            var movie = _movieService.Create(request);
            return Ok(movie);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Remove um filme pelo identificador único.
    /// </summary>
    /// <param name="id">Identificador único do filme.</param>
    /// <returns>204 se removido com sucesso ou 404 se não encontrado.</returns>
    [HttpDelete("{id:guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!_movieService.Delete(id))
            return NotFound();

        return NoContent();
    }
}
