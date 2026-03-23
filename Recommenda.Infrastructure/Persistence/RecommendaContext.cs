using Microsoft.EntityFrameworkCore;
using Recommenda.Domain.Entities;

namespace Recommenda.Infrastructure.Persistence;

public class RecommendaContext: DbContext
{
    public RecommendaContext(DbContextOptions<RecommendaContext> optionsRecommenda) : base(optionsRecommenda)
    {
        
    }
    
    public DbSet<Movie> Movies { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
}