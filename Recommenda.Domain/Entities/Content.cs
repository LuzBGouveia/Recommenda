using Recommenda.Domain.Commom;
using Recommenda.Domain.Enums;

namespace Recommenda.Domain.Entities;

public abstract class Content : BaseEntity
{
    public string Name { get; private set; }

    public string Description { get; private set; }
    
    public DateTime LaunchDate { get; private set; }

    //N..N - Relacionamento
    public List<Genre> Genres { get; private set; }

    public List<Rating> Ratings { get; set; }
    
    protected Content(string name, string description, DateTime launchDate,  List<Genre> genres)
    {
        Name = name;

        if (string.IsNullOrEmpty(description)) throw new Exception("Description is empty");
        
        Description = description;
        
        if (launchDate.Year < 1895) throw new Exception("Year must be greater than 1895");
        
        LaunchDate = launchDate;
        
        Active = false;
        
        Genres = genres;
    }
}