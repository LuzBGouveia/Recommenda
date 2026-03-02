using Microsoft.AspNetCore.Mvc;
// using Recommenda.Domain;
// using Recommenda.Domain.Commom;
// using Recommenda.Domain.Entities;

namespace Recommenda.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }

    // public void CreateMovie()
    // {
    //     var description = "Agente Noturno 2";
    //     
    //     Movie newMovie = new
    //             Movie("Agente Noturno", description, new DateTime(2021, 12, 20));
    //     
    //     string movie = "Agente Noturno - 20/12/2021";
    //
    //     //concatenou string
    //     string movie2 = newMovie.Name + " - " + newMovie.CreatedAt; //"Agente Noturno - 20/12/2021";
    //     
    //     //interpolar 
    //     string movie3 = $"{newMovie.Name} - {newMovie.CreatedAt}"; //"Agente Noturno - 20/12/2021";
    //
    //     string movie4 = newMovie.GetFullName();
    //     
    //     string movie5 = newMovie.GetFullName2;
    //     
    //     string movie6 = newMovie.ToString(); // Recommenda.Domain.Entities.Movie
    //     
    // }
}