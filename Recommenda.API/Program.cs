using Microsoft.EntityFrameworkCore;
using Recommenda.Application.Services;
using Recommenda.Infrastructure.Persistence;


namespace Recommenda.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddDbContext<RecommendaContext>(options =>
        {
            // options.UseMySql(builder.Configuration.GetConnectionString("RecommendaMySQL"));
            options.UseOracle(builder.Configuration.GetConnectionString("RecommendaOracle"));
        });

        builder.Services.AddScoped<IMovieService, MovieService>();

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}